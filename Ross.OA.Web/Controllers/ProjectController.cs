using AutoMapper;
using Newtonsoft.Json;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using Ross.OA.Application;
using Ross.OA.Dto;
using Ross.OA.EntityFramework.Model;
using Ross.OA.Web.Dto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ross.OA.Web.Controllers
{
    [Filters.FilterCheckLogin]
    public class ProjectController : BaseController, IControllerBase<ProjectDetail, long>
    {
        [Filters.FilterCheckPower]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ImportFile()
        {
            return View();
        }
        public JsonResult Del(long id)
        {
            ResultDto<string> result = new ResultDto<string>();
            try
            {
                ProjectService ObjServ = new ProjectService();
                ObjServ.Reposity.Delete(id);
                result.code = 100;
                result.message = "success";
                ObjServ.Dispose();
            }
            catch (Exception ex)
            {
                result.message = ex.Message;
            }
            return Json(result);
        }

        public JsonResult GetLists(int page, int pageSize, string keywords)
        {
            ProjectService ObjServ = new ProjectService();
            ResultDto<List<ProjectDetail>> result = new ResultDto<List<ProjectDetail>>();
            if (!string.IsNullOrEmpty(keywords))
            {
                result = ObjServ.Reposity.GetPageList(page, pageSize, (o => o.Company == BaseComp && (o.ProjectNum.Contains(keywords) || o.JobNum.Contains(keywords))));
            }
            else
            {
                result = ObjServ.Reposity.GetPageList(page, pageSize, (o => o.Company == BaseComp));
            }
            var datas = Mapper.Map<ResultDto<List<ProjectDetailDto>>>(result);
            ObjServ.Dispose();
            return Json(datas);
        }

        public JsonResult GetModel(long id)
        {
            ProjectDetailDto model = new ProjectDetailDto();
            using (ProjectService ObjServ = new ProjectService())
            {
                var result = ObjServ.Reposity.FirstOrDefault(id);
                if (result != null)
                {
                    model = Mapper.Map<ProjectDetailDto>(result);
                }
            }
            return Json(model);
        }

        public JsonResult InsertOrUpdate(ProjectDetail input)
        {
            ResultDto<int> result = new ResultDto<int>();
            using (ProjectService ObjServ = new ProjectService())
            {
                try
                {
                    input.Company = BaseComp;
                    ObjServ.Reposity.InsertOrUpdate(input);
                    result.code = 100;
                    result.message = "ok";
                }
                catch (Exception ex)
                {
                    result.code = 500;
                    result.message = ex.Message;
                }
            }
            return Json(result);
        }
        public ActionResult ImportExcel(HttpPostedFileBase file)
        {
            ResultDto<string> result = new ResultDto<string>();
            try
            {
                if (file == null)
                {
                    result.code = 101;
                    result.message = "请选择上传的Excel文件";
                }
                else
                {
                    Stream inputStream = file.InputStream;
                    HSSFWorkbook hssfworkbook = new HSSFWorkbook(inputStream);
                    ISheet sheet = hssfworkbook.GetSheetAt(0);
                    IRow headerRow = sheet.GetRow(0);
                    int cellCount = headerRow.LastCellNum;
                    int rowCount = sheet.LastRowNum;

                    ProjectService ObjServ = new ProjectService();
                    for (int i = (sheet.FirstRowNum + 1); i <= rowCount; i++)
                    {
                        IRow row = sheet.GetRow(i);
                        ProjectDetail entity = new ProjectDetail();
                        if (row != null)
                        {
                            entity.Company = BaseComp;
                            entity.ProjectNum = GetCellValue(row.Cells[0]);
                            entity.ProdQty = GetDecCellVal(row.Cells[1]);
                            entity.JobNum = GetCellValue(row.Cells[2]);
                            entity.EquipmentModel = GetCellValue(row.Cells[3]);
                            entity.SaleQty = GetDecCellVal(row.Cells[4]);
                            entity.SalesPerson = GetCellValue(row.Cells[5]);
                            entity.OrderDate = GetDateCellVal(row.Cells[6]);
                            entity.PromiseDate = GetDateCellVal(row.Cells[7]);
                            entity.ConsultDate = GetDateCellVal(row.Cells[8]);
                            entity.DrawDesignPerson = GetCellValue(row.Cells[9]);
                            entity.DrawPlan = GetDateCellVal(row.Cells[10]);
                            entity.DrawSubDate = GetDateCellVal(row.Cells[11]);
                            entity.SaleConfirm = GetDateCellVal(row.Cells[12]);
                            entity.MachinePlan = GetDateCellVal(row.Cells[13]);
                            entity.MachineDrawing = GetDateCellVal(row.Cells[14]);
                            entity.ElecPlan = GetDateCellVal(row.Cells[15]);
                            entity.ElecDrawing = GetDateCellVal(row.Cells[16]);
                            entity.PoWeldingPlan = GetDateCellVal(row.Cells[17]);
                            entity.PoWeldingPrep = GetDateCellVal(row.Cells[18]);
                            entity.PoPlan = GetDateCellVal(row.Cells[19]);
                            entity.PoPrep = GetDateCellVal(row.Cells[20]);
                            entity.ProdWeldingPlan = GetDateCellVal(row.Cells[21]);
                            entity.ProdWeldingPrep = GetDateCellVal(row.Cells[22]);
                            entity.MetalPlan = GetDateCellVal(row.Cells[23]);
                            entity.MetalPrep = GetDateCellVal(row.Cells[24]);
                            entity.MachiningPlan = GetDateCellVal(row.Cells[25]);
                            entity.MachiningPrep = GetDateCellVal(row.Cells[26]);
                            entity.MtlPlan = GetDateCellVal(row.Cells[27]);
                            entity.MtlPrep = GetDateCellVal(row.Cells[28]);
                            entity.PrepPlan = GetDateCellVal(row.Cells[29]);
                            entity.PrepOver = GetDateCellVal(row.Cells[30]);
                            entity.SATOver = GetDateCellVal(row.Cells[31]);
                            entity.SaleDeliver = GetDateCellVal(row.Cells[32]);
                            entity.EngineerPlan = GetDateCellVal(row.Cells[33]);
                            entity.EngineerOver = GetDateCellVal(row.Cells[34]);
                            entity.OperateStage = GetCellValue(row.Cells[35]);
                            entity.RespDept = GetCellValue(row.Cells[36]);
                            entity.DetailInfo = GetCellValue(row.Cells[37]);
                            entity.FocusInfo = GetCellValue(row.Cells[38]);
                            entity.Remarks = GetCellValue(row.Cells[39]);
                            ObjServ.Reposity.Insert(entity);
                        }
                    }
                    result.code = 100;
                    result.message = "上传成功";
                }

            }
            catch (Exception ex)
            {
                log.Error(ex.Message + ex.StackTrace);
                result.code = 101;
                result.message = "导入失败，错误原因：" + ex.Message;
            }
            return Json(result);
        }
        public FileResult ExportExcel(long shipid)
        {
            HSSFWorkbook book = new HSSFWorkbook();
            ISheet sheet1 = book.CreateSheet("Sheet1");
            ShipService ShipServ = new ShipService();
            EmployeeService EmpSev = new EmployeeService();

            var DataLists = ShipServ.ReposityShipD.GetAllList(o => o.ShipID == shipid);
            var ShipHD = ShipServ.ReposityShipH.Get(shipid);

            string ContractNum = ShipHD.ContractNum;
            string ProdNum = ShipHD.ProductNum;

            IRow rowhead = sheet1.CreateRow(0);
            rowhead.CreateCell(0).SetCellValue("编号");
            rowhead.CreateCell(1).SetCellValue("合同号");
            rowhead.CreateCell(2).SetCellValue("产品号");
            rowhead.CreateCell(3).SetCellValue("物料编码");
            rowhead.CreateCell(4).SetCellValue("名称");
            rowhead.CreateCell(5).SetCellValue("型号");
            rowhead.CreateCell(6).SetCellValue("数量");
            rowhead.CreateCell(7).SetCellValue("单位");
            rowhead.CreateCell(8).SetCellValue("SO号");
            rowhead.CreateCell(9).SetCellValue("PO号");
            rowhead.CreateCell(10).SetCellValue("运输方式");
            rowhead.CreateCell(11).SetCellValue("包装方式");

            int RowNum = 0;
            foreach (var item in DataLists)
            {
                IRow row = sheet1.CreateRow(RowNum + 1);
                row.CreateCell(0).SetCellValue(RowNum + 1);
                row.CreateCell(1).SetCellValue(ContractNum);
                row.CreateCell(2).SetCellValue(item.ProductNum);
                row.CreateCell(3).SetCellValue(item.PartNum);
                row.CreateCell(4).SetCellValue(item.PartDesc);
                row.CreateCell(5).SetCellValue(item.PartModel);
                row.CreateCell(6).SetCellValue(item.ShipQty.ToString());
                row.CreateCell(7).SetCellValue(item.IUM);
                row.CreateCell(8).SetCellValue(item.SONum);
                row.CreateCell(9).SetCellValue(ShipHD.PONum);
                row.CreateCell(10).SetCellValue(ShipHD.ShipviaCode);
                row.CreateCell(11).SetCellValue(ShipHD.PackageType);
                RowNum++;
            }

            MemoryStream ms = new MemoryStream();
            book.Write(ms);
            ms.Seek(0, SeekOrigin.Begin);
            ShipServ.Dispose();
            EmpSev.Dispose();
            return File(ms, "application/vnd.ms-excel", "SHIP" + ContractNum + "-" + ProdNum + ".xls");
        }
        private string GetCellValue(ICell cell)
        {
            if (cell == null)
                return string.Empty;
            switch (cell.CellType)
            {
                case CellType.Blank:
                    return string.Empty;
                case CellType.Boolean:
                    return cell.BooleanCellValue.ToString();
                case CellType.Error:
                    return cell.ErrorCellValue.ToString();
                case CellType.Numeric:
                case CellType.Unknown:
                default:
                    return cell.ToString();//This is a trick to get the correct value of the cell. NumericCellValue will return a numeric value no matter the cell value is a date or a number
                case CellType.String:
                    return cell.StringCellValue;
                case CellType.Formula:
                    try
                    {
                        HSSFFormulaEvaluator e = new HSSFFormulaEvaluator(cell.Sheet.Workbook);
                        e.EvaluateInCell(cell);
                        return cell.ToString();
                    }
                    catch
                    {
                        return cell.NumericCellValue.ToString();
                    }
            }
        }
        private DateTime? GetDateCellVal(ICell cell)
        {
            try
            {
                return Convert.ToDateTime(GetCellValue(cell));
            }
            catch { return null; }
        }
        private decimal GetDecCellVal(ICell cell)
        {
            try
            {
                return Convert.ToDecimal(GetCellValue(cell));
            }
            catch { return 0; }
        }
    }
}