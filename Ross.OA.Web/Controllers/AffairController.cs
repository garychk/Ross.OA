using AutoMapper;
using Newtonsoft.Json;
using Ross.OA.Application;
using Ross.OA.Dto;
using Ross.OA.EntityFramework.Model;
using Ross.OA.Web.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ross.OA.Web.Controllers
{
    [Filters.FilterCheckLogin]
    public class AffairController : BaseController, IControllerBase<Affairs, long>
    {
        public JsonResult Del(long id)
        {
            ResultDto<string> result = new ResultDto<string>();
            try
            {
                AffairService AffairServ = new AffairService();
                AffairServ.Reposity.Delete(id);
                result.code = 100;
                result.message = "success";
                AffairServ.Dispose();
            }
            catch (Exception ex)
            {
                result.message = ex.Message;
            }
            return Json(result);
        }

        public JsonResult GetLists(int page, int pageSize, string keywords = "")
        {
            AffairService AffairServ = new AffairService();
            var result = AffairServ.Reposity.GetPageList(page, pageSize, (o => o.Company == BaseComp));
            AffairServ.Dispose();
            return Json(result);
        }

        public JsonResult GetListsByDept(int page, int pageSize, int deptId = 0, int empId = 0)
        {
            ResultDto<List<AffairOutput>> lists = new ResultDto<List<AffairOutput>>();
            AffairService AffairServ = new AffairService();
            var result = AffairServ.Reposity.GetPageList(page, pageSize, (o => o.Company == BaseComp && o.RespDepartId == EmpDeptId));
            if (deptId > 0 && result.datas != null)
            {
                result.datas = result.datas.Where(o => o.RespDepartId == deptId).ToList();
            }
            if (empId > 0 && result.datas != null)
            {
                result.datas = result.datas.Where(o => o.EmpId == empId).ToList();
            }
            result.datas = result.datas.OrderByDescending(o => o.CreationTime).ToList();
            AffairServ.Dispose();
            lists = Mapper.Map<ResultDto<List<AffairOutput>>>(result);
            if (lists.datas != null)
            {
                foreach (var item in lists.datas)
                {
                    item.FromNowTime = AppBase.DateStringFromNow(DateTime.Parse(item.CreationTime));
                }
            }
            return Json(lists);
        }

        public JsonResult GetAffairs(string contractnum, string partnum)
        {
            ResultDto<List<AffairOutput>> result = new ResultDto<List<AffairOutput>>();
            AffairService AffairServ = new AffairService();
            var items = AffairServ.Reposity.GetAllList(o => o.Company == BaseComp && o.RespDepartId == EmpDeptId);
            if (!string.IsNullOrEmpty(contractnum))
            {
                items = items.Where(o => o.ContractNum == contractnum).ToList();
            }
            if (!string.IsNullOrEmpty(partnum))
            {
                items = items.Where(o => o.PartNum == partnum).ToList();
            }
            items = items.OrderByDescending(o => o.CreationTime).ToList();
            AffairServ.Dispose();
            result.datas = Mapper.Map<List<AffairOutput>>(items);
            result.code = 100;
            result.total = items.Count;
            result.message = "ok";
            if (result.datas != null)
            {
                foreach (var item in result.datas)
                {
                    item.FromNowTime = AppBase.DateStringFromNow(DateTime.Parse(item.CreationTime));
                }
            }
            return Json(result);
        }

        public JsonResult GetModel(long id)
        {
            Affairs model = new Affairs();
            using (AffairService AffairServ = new AffairService())
            {
                var result = AffairServ.Reposity.FirstOrDefault(id);
                if (result != null)
                    model = result;
            }
            var data = Mapper.Map<AffairOutput>(model);
            EmployeeService EmpServ = new EmployeeService();
            data.RespDepart = EmpServ.ReposityDept.Get(data.RespDepartId);
            EmpServ.Dispose();
            return Json(data);
        }
        [Filters.FilterCheckPower]
        public ActionResult Index()
        {
            return View();
        }
        [Filters.FilterCheckPower]
        public ActionResult Detail(long id)
        {
            ViewBag.Id = id;
            return View();
        }
        [Filters.FilterCheckPower]
        public ActionResult Lists()
        {
            return View();
        }

        public JsonResult InsertOrUpdate(Affairs input)
        {
            using (AffairService AffairServ = new AffairService())
            {
                var result = AffairServ.Reposity.InsertOrUpdate(input);
                return Json(result);
            }
        }

        public JsonResult ChangeStatus(long id, string status)
        {
            ResultDto<long> result = new ResultDto<long>();
            try
            {
                using (AffairService AffairServ = new AffairService())
                {
                    var model = AffairServ.Reposity.Get(id);
                    if (model.RespDepartId == EmpDeptId)
                    {
                        model.ApproveStatus = status;
                        AffairServ.Reposity.InsertOrUpdate(model);
                        result.code = 100;
                        result.message = "ok";
                        result.datas = model.Id;
                    }
                    else
                    {
                        result.code = 104;
                    }
                }
            }
            catch (Exception ex)
            {
                result.code = 500;
                result.message = ex.Message;
            }
            return Json(result);
        }
    }
}