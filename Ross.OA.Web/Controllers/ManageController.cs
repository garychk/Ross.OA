using AutoMapper;
using Ross.OA.Application;
using Ross.OA.Dto;
using Ross.OA.EntityFramework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ross.OA.Web.Controllers
{
    public class ManageController : Controller
    {
        public JsonResult Login(string UserName, string Password, string CompCode)
        {
            ResultDto<string> result = new ResultDto<string>();
            using (EmployeeService EmpServ = new EmployeeService())
            {
                try
                {
                    var model = EmpServ.ReposityEmp.GetAllList(o => o.UserName == UserName).FirstOrDefault();
                    if (model != null)
                    {
                        if (model.Password == Password)
                        {
                            result.code = 100;
                            result.message = "ok";
                            AppBase.SetCookie("Company", CompCode, 5);
                            AppBase.SetCookie("EmpId", model.Id.ToString(), 5);
                            AppBase.SetCookie("EmpName", model.UserName, 5);
                            AppBase.SetCookie("EmpUserId", model.UserId.ToString(), 5);
                        }
                        else
                        {
                            result.code = 102;
                            result.message = "password error";
                        }
                    }
                    else
                    {
                        result.code = 101;
                        result.message = "object not exist";
                    }
                }
                catch (Exception ex)
                {
                    result.code = 500;
                    result.message = ex.Message;
                }
            }
            return Json(result);
        }
        public JsonResult Logout()
        {
            ResultDto<string> result = new ResultDto<string>();
            try
            {
                AppBase.DelCookie("EmpId", "");
                AppBase.DelCookie("EmpName", "");
                AppBase.DelCookie("EmpUserId", "");
                AppBase.DelCookie("Company", "");
                result.code = 100;
            }
            catch (Exception ex)
            {
                result.code = 500;
                result.message = ex.Message;
            }
            return Json(result);
        }
        public JsonResult GetComps()
        {
            using (CompanyService ObjServ = new CompanyService())
            {
                var result = ObjServ.Reposity.GetAllList(o => !o.IsDeleted && o.IsActive);
                var lists = Mapper.Map<List<Dto.CompanyDto>>(result);
                return Json(lists);
            }
        }
        public static void InitSystem()
        {
            EmployeeService EmpServ = new EmployeeService();
            if (EmpServ.ReposityEmp.Count() <= 0)
            {
                var dept = EmpServ.ReposityDept.Insert(new Depart()
                {
                    DepartCode = "IT",
                    DepartName = "IT",
                    Company = "001",
                    IsActive = true,
                    IsDeleted = false
                });
                if (dept != null)
                {
                    EmpServ.ReposityEmp.Insert(new Employee()
                    {
                        Company = "001",
                        UserId = 1001,
                        UserName = "admin",
                        Password = "admin",
                        DepartId = dept.Id,
                        CreationTime = DateTime.Now,
                        IsDeleted = false
                    });
                }
            }
            EmpServ.Dispose();
        }
    }
}