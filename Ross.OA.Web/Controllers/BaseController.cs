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
        public string BaseComp = AppBase.CookieVal("Company");
        public string EmpDeptName = HttpUtility.UrlDecode(AppBase.CookieVal("EmpDeptName"));
        /// <summary>
        /// 员工ID
        /// </summary>
        public int EmpId = AppBase.GetEmpId();
        public int EmpDeptId = AppBase.GetEmpDeptId();
        public string EmpName = AppBase.CookieVal("EmpName");
        public log4net.ILog log = log4net.LogManager.GetLogger("Ross.OA.Web.Controllers");

        protected override void OnException(ExceptionContext filterContext)
        {
            // 错误日志编写    
            string controllerNamer = filterContext.RouteData.Values["controller"].ToString();
            string actionName = filterContext.RouteData.Values["action"].ToString();
            string exception = filterContext.Exception.ToString();
            log.Error(controllerNamer + "" + actionName + " error:" + exception);
            // 执行基类中的OnException    
            base.OnException(filterContext);
            string loginUrl = "/Home/Error";
            filterContext.HttpContext.Response.Redirect(loginUrl, true);
        }
    }
}