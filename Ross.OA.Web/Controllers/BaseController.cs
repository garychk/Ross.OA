using Ross.OA.EntityFramework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ross.OA.Web.Controllers
{
    public class BaseController : Controller
    {
        public string Company = AppBase.CookieVal("Company");
        /// <summary>
        /// 员工ID
        /// </summary>
        public int EmpId = AppBase.GetEmpId();
        public log4net.ILog log = log4net.LogManager.GetLogger("Ross.OA.Web.Controllers"); 
    }
}