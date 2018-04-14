using AutoMapper;
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
    public class CompanyController : BaseController, IControllerBase<Company, int>
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Edit(int id = 0)
        {
            ViewBag.Id = id;
            return View();
        }
        public JsonResult Del(int id)
        {
            ResultDto<string> result = new ResultDto<string>();
            try
            {
                CompanyService ObjServ = new CompanyService();
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

        public JsonResult GetLists(int page, int pageSize, string keywords = "")
        {
            CompanyService ObjServ = new CompanyService();
            var result = ObjServ.Reposity.GetPageList(page, pageSize, (o => !o.IsDeleted));
            ObjServ.Dispose();
            return Json(result);
        }

        public JsonResult GetModel(int id)
        {
            Company model = new Company();
            using (CompanyService ObjServ = new CompanyService())
            {
                var result = ObjServ.Reposity.FirstOrDefault(id);
                if (result != null)
                    model = result;
            }
            return Json(model);
        }

        public JsonResult InsertOrUpdate(Company input)
        {
            ResultDto<int> result = new ResultDto<int>();
            using (CompanyService ObjServ = new CompanyService())
            {
                try
                {
                    input.CreationTime = DateTime.Now;
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
    }
}