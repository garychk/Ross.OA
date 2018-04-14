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
    [Filters.FilterCheckLogin]
    public class AffairController : BaseController, IControllerBase<Affairs, int>
    {
        public JsonResult Del(int id)
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
            var result = AffairServ.Reposity.GetPageList(page, pageSize, (o => o.Company == Company));
            AffairServ.Dispose();
            return Json(result);
        }

        public JsonResult GetModel(int id)
        {
            Affairs model = new Affairs();
            using (AffairService AffairServ = new AffairService())
            {
                var result = AffairServ.Reposity.FirstOrDefault(id);
                if (result != null)
                    model = result;
            }
            return Json(model);
        }

        // GET: Affair
        public ActionResult Index()
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
    }
}