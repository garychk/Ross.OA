using Ross.OA.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ross.OA.Web.Filters
{
    public class FilterCheckPower : ActionFilterAttribute
    {
        public int RoleGrade { get; set; }
        public string MenuName { get; set; }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (AppBase.CookieVal("EmpName") != "admin")
            {
                bool hasPower = false;
                int deptid = AppBase.GetEmpDeptId();

                var controllerName = (filterContext.RouteData.Values["controller"]).ToString();
                var actionName = (filterContext.RouteData.Values["action"]).ToString();
                MenuName = controllerName + actionName;

                EmployeeService EmpSev = new EmployeeService();
                var Dept = EmpSev.ReposityDept.Get(deptid);
                if (Dept != null && Dept.Powers != null)
                {
                    hasPower = Dept.Powers.Contains(MenuName);
                }
                if (!hasPower)
                {
                    string loginUrl = "/Home/PowerOff";
                    filterContext.HttpContext.Response.Redirect(loginUrl, true);
                }
                EmpSev.Dispose();
            }
        }
    }
}