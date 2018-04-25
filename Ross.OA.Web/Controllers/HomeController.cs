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
            ViewBag.AdminName = EmpName;
            ViewBag.Depart = EmpDeptName;
            using (CompanyService ObjServ = new CompanyService())
            {
                var CompObj = ObjServ.Reposity.GetAllList(o => o.CompanyCode == BaseComp).FirstOrDefault();
                ViewBag.CompanyName = CompObj != null ? CompObj.CompanyName : "";
            }
            return View();
        }
        [Filters.FilterCheckLogin]
        public ActionResult Dashboard()
        {
            ViewBag.EmpId = EmpId;
            ViewBag.EmpDeptId = EmpDeptId;
            ShipService shipServ = new ShipService();
            CustomerService custServ = new CustomerService();
            PartService partServ = new PartService();
            AffairService affairServ = new AffairService();
            ViewBag.CountShipment = shipServ.ReposityShipH.Count();
            ViewBag.CountCustomer = custServ.Reposity.Count();
            ViewBag.CountParts = partServ.Reposity.Count();
            int num1 = affairServ.Reposity.GetAllList(o => o.ApproveStatus == "A" && o.RespDepartId == EmpDeptId).Count;
            int num2 = affairServ.Reposity.GetAllList(o => o.RespDepartId == EmpDeptId).Count;
            ViewBag.AffairRate = Math.Round((num2 != 0 ? (float)num1 / num2 : 0) * 100);
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
        [Filters.FilterCheckPower]
        public ActionResult SysConfig()
        {
            return View();
        }

        public ActionResult PowerOff()
        {
            return View();
        }
        public ActionResult Error()
        {
            return View();
        }
        [Filters.FilterCheckPower]
        public ActionResult PowerConfig()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
    }
}