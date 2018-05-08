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
    public class EmployeeController : BaseController, IControllerBase<Employee, int>
    {
        [Filters.FilterCheckPower]
        public ActionResult Index()
        {
            return View();
        }
        [Filters.FilterCheckPower]
        public ActionResult Edit(int id)
        {
            ViewBag.Id = id;
            return View();
        }
        public ActionResult EditDept(int id)
        {
            ViewBag.Id = id;
            return View();
        }
        public JsonResult Del(int id)
        {
            ResultDto<string> result = new ResultDto<string>();
            try
            {
                EmployeeService EmpServ = new EmployeeService();
                var entity = EmpServ.ReposityEmp.Get(id);
                entity.IsDeleted = true;
                EmpServ.ReposityEmp.Update(entity);
                result.code = 100;
                result.message = "success";
                EmpServ.Dispose();
            }
            catch (Exception ex)
            {
                result.message = ex.Message;
            }
            return Json(result);
        }
        public JsonResult DelDeptSoft(int id)
        {
            ResultDto<string> result = new ResultDto<string>();
            try
            {
                EmployeeService EmpServ = new EmployeeService();
                var dept = EmpServ.ReposityDept.Get(id);
                dept.IsDeleted = true;
                EmpServ.ReposityDept.Update(dept);
                result.code = 100;
                result.message = "success";
                EmpServ.Dispose();
            }
            catch (Exception ex)
            {
                result.message = ex.Message;
            }
            return Json(result);
        }
        public JsonResult GetLists(int page, int pageSize, string keywords = "")
        {
            EmployeeService EmpServ = new EmployeeService();
            ResultDto<List<Employee>> result = new ResultDto<List<Employee>>();
            if (string.IsNullOrEmpty(keywords))
                result = EmpServ.ReposityEmp.GetPageList(page, pageSize, (o => o.Company == BaseComp));
            else
                result = EmpServ.ReposityEmp.GetPageList(page, pageSize, (o => o.Company == BaseComp && (o.UserName.Contains(keywords))));
            var datas = Mapper.Map<ResultDto<List<EmployeeDto>>>(result);
            EmpServ.Dispose();
            return Json(datas);
        }
        public JsonResult GetListsDept(int page, int pageSize, string keywords = "")
        {
            EmployeeService EmpServ = new EmployeeService();
            ResultDto<List<Depart>> result = new ResultDto<List<Depart>>();
            if (string.IsNullOrEmpty(keywords))
                result = EmpServ.ReposityDept.GetPageList(page, pageSize, (o => o.Company == BaseComp && o.IsDeleted == false));
            else
                result = EmpServ.ReposityDept.GetPageList(page, pageSize, (o => o.Company == BaseComp && o.IsDeleted == false && (o.DepartCode.Contains(keywords) || o.DepartName.Contains(keywords))));
            EmpServ.Dispose();
            return Json(result);
        }
        public JsonResult GetModel(int id)
        {
            ResultDto<EmployeeDto> result = new ResultDto<EmployeeDto>();
            try {
                using (EmployeeService EmpServ = new EmployeeService())
                {
                    Employee model = new Employee();
                    var entity = EmpServ.ReposityEmp.FirstOrDefault(id);
                    if (entity != null)
                        model = entity;
                    result.code = 100;
                    result.datas = Mapper.Map<EmployeeDto>(model);
                }
            }catch(Exception ex)
            {
                result.code = 500;
                result.message = ex.Message;
                log.Error(ex.Message);
            }
            return Json(result);
        }
        public JsonResult GetModelDept(int id = 0)
        {
            Depart model = new Depart();
            using (EmployeeService EmpServ = new EmployeeService())
            {
                var result = EmpServ.ReposityDept.FirstOrDefault(id);
                if (result != null)
                    model = result;
            }
            return Json(model);
        }
        public JsonResult DoEdit(EmployeeInput input)
        {
            ResultDto<int> result = new ResultDto<int>();
            using (EmployeeService EmpServ = new EmployeeService())
            {
                try
                {
                    input.Company = BaseComp;
                    var entity = Mapper.Map<Employee>(input);
                    EmpServ.ReposityEmp.InsertOrUpdate(entity);
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
        public JsonResult InsertOrUpdateDept(Depart input)
        {
            ResultDto<int> result = new ResultDto<int>();
            using (EmployeeService EmpServ = new EmployeeService())
            {
                try
                {
                    input.Company = BaseComp;
                    EmpServ.ReposityDept.InsertOrUpdate(input);
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

        public JsonResult UpdateDeptPower(int DeptId, string Powers)
        {
            ResultDto<int> result = new ResultDto<int>();
            using (EmployeeService EmpServ = new EmployeeService())
            {
                try
                {
                    var entity = EmpServ.ReposityDept.Get(DeptId);
                    entity.Powers = Powers;
                    EmpServ.ReposityDept.InsertOrUpdate(entity);
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

        public JsonResult InsertOrUpdate(Employee input)
        {
            throw new NotImplementedException();
        }
    }
}