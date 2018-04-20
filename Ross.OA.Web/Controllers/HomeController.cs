using Ross.OA.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ross.OA.Web.Controllers
{
    public class HomeController : BaseController
    {
        [Filters.FilterCheckLogin]
        public ActionResult Index()
        {
            ViewBag.AdminName = AppBase.CookieVal("EmpName");
            using (CompanyService ObjServ = new CompanyService())
            {
                var CompObj = ObjServ.Reposity.GetAllList(o => o.CompanyCode == Company).FirstOrDefault();
                if (CompObj != null)
                    ViewBag.CompanyName = CompObj.CompanyName;
            }
            return View();
        }
        [Filters.FilterCheckLogin]
        public ActionResult Dashboard()
        {
            return View();
        }
        [Filters.FilterCheckLogin]
        public ActionResult UpdatePsw()
        {
            ViewBag.EmpId = EmpId;
            return View();
        }
        [Filters.FilterCheckLogin]
        public ActionResult MailBox()
        {
            ViewBag.EmpId = EmpId;
            return View();
        }
        [Filters.FilterCheckLogin]
        public ActionResult SysConfig()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
    }
}