using AutoMapper;
using Newtonsoft.Json;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using Ross.OA.Application;
using Ross.OA.Dto;
using Ross.OA.EntityFramework.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ross.OA.Web.Controllers
{
    [Filters.FilterCheckLogin]
    public class ShipController : BaseController, IControllerBase<ShipHead, long>
    {
        [Filters.FilterCheckPower]
        public ActionResult Index()
        {
            return View();
        }
        [Filters.FilterCheckPower]
        public ActionResult Detail(int id = 0)
        {
            ViewBag.Id = id;
            return View();
        }
        [Filters.FilterCheckPower]
        public ActionResult Edit(int id = 0)
        {
            ViewBag.Id = id;
            return View();
        }
        public ActionResult ImportDT(int id = 0)
        {
            ViewBag.ShipID = id;
            return View();
        }
        public JsonResult Del(long id)
        {
            ResultDto<string> result = new ResultDto<string>();
            try
            {
                ShipService ObjServ = new ShipService();
                var entity = ObjServ.ReposityShipH.Get(id);
                if (entity.EnterPerson.ToLower() != AppBase.CookieVal("EmpName").ToLower())
                {
                    result.code = 104;
                }
                else
                {
                    ObjServ.ReposityShipH.Delete(id);
                    result.code = 100;
                    result.message = "success";
                }
                ObjServ.Dispose();
            }
            catch (Exception ex)
            {
                result.message = ex.Message;
            }
            return Json(result);
        }
        public JsonResult DelDT(long id)
        {
            ResultDto<string> result = new ResultDto<string>();
            try
            {
                ShipService ObjServ = new ShipService();
                var entity = ObjServ.ReposityShipD.Get(id);
                if (entity.EnterPerson.ToLower() != EmpName.ToLower())
                {
                    result.code = 104;
                }
                else
                {
                    ObjServ.ReposityShipD.Delete(id);
                    result.code = 100;
                    result.message = "success";

                    if (entity != null)
                    {
                        entity.ShipHd = ObjServ.ReposityShipH.Get(entity.ShipID);
                        string[] DeptArr = entity.RespDepartCodes.Split(',');
                        foreach (string i in DeptArr)
                        {
                            int deptid = int.Parse(i);
                            AddShipDTDelLog(entity, deptid, EmpId);
                        }
                    }
                }
                ObjServ.Dispose();
            }
            catch (Exception ex)
            {
                result.message = ex.Message;
            }
            return Json(result);
        }

        public JsonResult GetLists(int page, int pageSize, string keywords = "")
        {
            ResultDto<List<Dto.ShipHdDto>> result = new ResultDto<List<Dto.ShipHdDto>>();
            ShipService ShipServ = new ShipService();
            var lists = ShipServ.GetShipWithEmp(page, pageSize, BaseComp, keywords);
            result = Mapper.Map<ResultDto<List<Dto.ShipHdDto>>>(lists);
            ShipServ.Dispose();

            if (result.datas != null)
            {
                AffairService affServ = new AffairService();
                foreach (var item in result.datas)
                {
                    item.affairCount = affServ.Reposity.GetAllList(o => o.ContractNum == item.ContractNum && o.ApproveStatus == "P" && o.RespDepartId == EmpDeptId).Count;
                }
                affServ.Dispose();
            }
            return Json(result);
        }

        public JsonResult GetDetailLists(int page, int pageSize, long shipid)
        {
            ResultDto<List<Dto.ShipDetailOutput>> result = new ResultDto<List<Dto.ShipDetailOutput>>();
            ShipService ShipServ = new ShipService();
            var shiphd = ShipServ.ReposityShipH.Get(shipid);
            var lists = ShipServ.ReposityShipD.GetPageList(page, pageSize, o => o.ShipID == shipid);
            ShipServ.Dispose();
            result = Mapper.Map<ResultDto<List<Dto.ShipDetailOutput>>>(lists);
            EmployeeService EmpSev = new EmployeeService();
            AffairService affServ = new AffairService();
            int rownum = 1;
            foreach (var item in result.datas)
            {
                item.RowNum = rownum;
                item.RespDepartNames = CvtDept(item.RespDepartCodes, EmpSev);
                item.affairCount = affServ.Reposity.GetAllList(o => o.PartNum == item.PartNum && o.ContractNum == shiphd.ContractNum && o.ApproveStatus == "P" && o.RespDepartId == EmpDeptId).Count;
                rownum++;
            }
            EmpSev.Dispose();
            affServ.Dispose();
            return Json(result);
        }
        /// <summary>
        /// 转换部门
        /// </summary>
        /// <param name="RespDepartCodes"></param>
        /// <param name="EmpSev"></param>
        /// <returns></returns>
        private string CvtDept(string RespDepartCodes, EmployeeService EmpSev)
        {
            #region 转换部门
            string respDept = "";
            try
            {
                if (!string.IsNullOrEmpty(RespDepartCodes))
                {
                    respDept = "dept";
                    var deptcode = RespDepartCodes.Split(',');
                    foreach (string code in deptcode)
                    {
                        var m = EmpSev.ReposityDept.Get(int.Parse(code));
                        if (m != null)
                        {
                            respDept += "," + m.DepartName;
                        }
                    }
                    respDept = respDept.Replace("dept,", "");
                }
            }
            catch { }
            return respDept;
            #endregion
        }

        public JsonResult GetModel(long id)
        {
            Dto.ShipHdOutput model = new Dto.ShipHdOutput();
            using (ShipService ObjServ = new ShipService())
            {
                if (id > 0)
                {
                    var result = ObjServ.ReposityShipH.FirstOrDefault(id);
                    if (result != null)
                    {
                        model = Mapper.Map<Dto.ShipHdOutput>(result);
                    }
                }
                else
                {
                    model.OrderDate = DateTime.Now.ToShortDateString();
                    model.PromiseDate = DateTime.Now.ToShortDateString();
                    model.EnterPerson = EmpName;
                }
            }
            return Json(model);
        }
        public JsonResult GetShipDetail(long id)
        {
            ShipDetail model = new ShipDetail();
            using (ShipService ObjServ = new ShipService())
            {
                var result = ObjServ.ReposityShipD.FirstOrDefault(id);
                if (result != null)
                    model = result;
            }
            model.EnterPerson = EmpName;
            return Json(model);
        }

        public JsonResult InsertOrUpdateHD(Dto.ShipHdOutput input)
        {
            ResultDto<long> result = new ResultDto<long>();
            using (ShipService ObjServ = new ShipService())
            {
                try
                {
                    long OID = input.Id;
                    var entity = Mapper.Map<ShipHead>(input);
                    //if (input.EnterPerson.ToLower() != EmpName.ToLower())
                    //{
                    //    result.code = 104;
                    //}
                    //else
                    //{

                    //}
                    entity.Company = BaseComp;
                    entity.EmpId = EmpId;
                    entity.EnterPerson = EmpName;
                    ObjServ.ReposityShipH.InsertOrUpdate(entity);
                    result.code = 100;
                    result.message = "ok";
                    result.datas = entity.Id;
                    if (entity != null)
                    {
                        string[] DeptArr = input.RespDepartCodes.Split(',');
                        foreach (string i in DeptArr)
                        {
                            int deptid = int.Parse(i);
                            AddShipHdLog(entity, deptid, EmpId, OID);
                        }
                    }
                }
                catch (Exception ex)
                {
                    result.code = 500;
                    result.message = ex.Message;
                    log.Error(ex.StackTrace);
                }
            }
            return Json(result);
        }
        public JsonResult InsertOrUpdateDT(ShipDetail input)
        {
            ResultDto<long> result = new ResultDto<long>();
            using (ShipService ObjServ = new ShipService())
            {
                try
                {
                    //if (input.EnterPerson.ToLower() != EmpName.ToLower())
                    //{
                    //    result.code = 104;
                    //}
                    //else
                    //{

                    //}
                    long OID = input.Id;
                    input.Company = BaseComp;
                    input.EnterPerson = EmpName;
                    ObjServ.ReposityShipD.InsertOrUpdate(input);
                    result.code = 100;
                    result.message = "ok";
                    result.datas = input.Id;
                    if (input != null)
                    {
                        input.ShipHd = ObjServ.ReposityShipH.Get(input.ShipID);
                        string[] DeptArr = input.RespDepartCodes.Split(',');
                        foreach (string i in DeptArr)
                        {
                            int deptid = int.Parse(i);
                            AddShipDTLog(input, deptid, EmpId, OID);
                        }
                    }
                }
                catch (Exception ex)
                {
                    result.code = 500;
                    result.message = ex.Message;
                    log.Error(ex.StackTrace);
                }
            }
            return Json(result);
        }

        public void AddShipHdLog(ShipHead entity, int deptID, int empId, long OID)
        {
            try
            {
                OutDto<ShipHead> obj = new OutDto<ShipHead>();
                obj.code = 100;
                obj.datas = entity;
                obj.message = OID > 0 ? EmpName + "对合同号" + entity.ContractNum + "更改" : EmpName + "新建合同号：" + entity.ContractNum;
                obj.num = 1;
                obj.objects = "ShipHead";

                EmployeeService empServ = new EmployeeService();
                var respEmp = empServ.ReposityEmp.GetAllList(o => o.DepartId == deptID && o.Position == "Charger").FirstOrDefault();
                if (respEmp != null)
                {
                    AffairService affairServ = new AffairService();
                    affairServ.Reposity.Insert(new Affairs()
                    {
                        Title = obj.message,
                        ApproveStatus = "P",
                        Company = BaseComp,
                        Contents = JsonConvert.SerializeObject(obj),
                        CreationTime = DateTime.Now,
                        EmergGrade = 3,
                        EmpId = empId,
                        RespEmpId = respEmp.Id,
                        RespDepartId = deptID,
                        ContractNum = entity.ContractNum,
                        PartNum = entity.ProductNum,
                        Objects = "ShipHead"
                    });
                    affairServ.Dispose();
                }
                empServ.Dispose();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        public void AddShipDTLog(ShipDetail entity, int deptID, int empId, long OID)
        {
            try
            {
                OutDto<ShipDetail> obj = new OutDto<ShipDetail>();
                obj.code = 100;
                obj.datas = entity;
                obj.message = OID > 0 ? EmpName + "对合同号" + entity.ShipHd.ContractNum + "分录项" + entity.PartNum + "更改" : EmpName + "在合同号" + entity.ShipHd.ContractNum + "上新增分录项" + entity.PartNum;
                obj.num = 1;
                obj.objects = "ShipDetail";

                EmployeeService empServ = new EmployeeService();
                var respEmp = empServ.ReposityEmp.GetAllList(o => o.DepartId == deptID && o.Position == "Charger").FirstOrDefault();
                if (respEmp != null)
                {
                    AffairService affairServ = new AffairService();
                    affairServ.Reposity.Insert(new Affairs()
                    {
                        Title = obj.message,
                        ApproveStatus = "P",
                        Company = BaseComp,
                        Contents = JsonConvert.SerializeObject(obj),
                        CreationTime = DateTime.Now,
                        EmergGrade = 3,
                        EmpId = empId,
                        RespEmpId = respEmp.Id,
                        RespDepartId = deptID,
                        ContractNum = entity.ShipHd.ContractNum,
                        PartNum = entity.PartNum,
                        Reasons = entity.Reasons,
                        Objects = "ShipDetail"
                    });
                    affairServ.Dispose();
                }
                empServ.Dispose();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        public void AddShipDTDelLog(ShipDetail entity, int deptID, int empId)
        {
            try
            {
                OutDto<ShipDetail> obj = new OutDto<ShipDetail>();
                obj.code = 100;
                obj.datas = entity;
                obj.message = EmpName + "删除合同号" + entity.ShipHd.ContractNum + "上分录项" + entity.PartNum;
                obj.num = 1;
                obj.objects = "ShipDetail";

                EmployeeService empServ = new EmployeeService();
                var respEmp = empServ.ReposityEmp.GetAllList(o => o.DepartId == deptID && o.Position == "Charger").FirstOrDefault();
                if (respEmp != null)
                {
                    AffairService affairServ = new AffairService();
                    affairServ.Reposity.Insert(new Affairs()
                    {
                        Title = obj.message,
                        ApproveStatus = "P",
                        Company = BaseComp,
                        Contents = JsonConvert.SerializeObject(obj),
                        CreationTime = DateTime.Now,
                        EmergGrade = 2,
                        EmpId = empId,
                        RespEmpId = respEmp.Id,
                        RespDepartId = deptID,
                        ContractNum = entity.ShipHd.ContractNum,
                        PartNum = entity.PartNum,
                        Reasons = entity.Reasons,
                        Objects = "ShipDetail"
                    });
                    affairServ.Dispose();
                }
                empServ.Dispose();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        public JsonResult GetOrderNum()
        {
            long result = 1000;
            using (ShipService ObjServ = new ShipService())
            {
                if (ObjServ.ReposityShipH.Count() > 0)
                {
                    long MaxNum = ObjServ.ReposityShipH.GetAllList().Max(o => o.OrderNum);
                    result = MaxNum + 1;
                }
            }
            return Json(result);
        }

        public JsonResult InsertOrUpdate(ShipHead input)
        {
            throw new NotImplementedException();
        }
        public JsonResult GetNewDetail()
        {
            ShipDetail model = new ShipDetail();
            model.EnterPerson = EmpName;
            return Json(model);
        }
        public ActionResult ImportExcel(HttpPostedFileBase file, long shipid)
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

                    ShipService shipServ = new ShipService();
                    for (int i = (sheet.FirstRowNum + 1); i <= rowCount; i++)
                    {
                        IRow row = sheet.GetRow(i);
                        ShipDetail entity = new ShipDetail();
                        if (row != null)
                        {
                            entity.Company = BaseComp;
                            entity.EnterPerson = EmpName;
                            entity.ProductNum = GetCellValue(row.Cells[2]);
                            entity.PartNum = GetCellValue(row.Cells[3]);
                            entity.PartDesc = GetCellValue(row.Cells[4]);
                            entity.PartModel = GetCellValue(row.Cells[5]);
                            entity.ShipQty = AppBase.ToDecimal(GetCellValue(row.Cells[6]));
                            entity.IUM = GetCellValue(row.Cells[7]);
                            entity.SONum = GetCellValue(row.Cells[8]);
                            entity.Reasons = GetCellValue(row.Cells[9]);
                            entity.RespDepartCodes = GetCellValue(row.Cells[10]);
                            entity.ShipID = shipid;
                            entity.IsConfirm = false;
                            entity.OpenLine = true;
                            shipServ.ReposityShipD.Insert(entity);
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
            rowhead.CreateCell(9).SetCellValue("原因");
            rowhead.CreateCell(10).SetCellValue("责任部门");

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
                row.CreateCell(9).SetCellValue(item.Reasons);
                row.CreateCell(10).SetCellValue(CvtDept(item.RespDepartCodes, EmpSev));
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
    }
}