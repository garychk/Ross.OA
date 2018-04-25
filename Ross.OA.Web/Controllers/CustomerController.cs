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
    public class CustomerController : BaseController, IControllerBase<Customer, int>
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

        public JsonResult GetModel(int id)
        {
            Customer model = new Customer();
            using (CustomerService ObjServ = new CustomerService())
            {
                var result = ObjServ.Reposity.FirstOrDefault(id);
                if (result != null)
                    model = result;
            }
            return Json(model);
        }

        public JsonResult InsertOrUpdate(Customer input)
        {
            ResultDto<int> result = new ResultDto<int>();
            using (CustomerService ObjServ = new CustomerService())
            {
                try
                {
                    input.Company = BaseComp;
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
        public JsonResult GetLists(int page, int pageSize, string keywords = "")
        {
            CustomerService CustServ = new CustomerService();
            ResultDto<List<Customer>> result = new ResultDto<List<Customer>>();
            if (!string.IsNullOrEmpty(keywords))
            {
                result = CustServ.Reposity.GetPageList(page, pageSize, (o => o.Company == BaseComp && (o.CustName.Contains(keywords) || o.CustID == keywords || o.CustNum == keywords)));
            }
            else
            {
                result = CustServ.Reposity.GetPageList(page, pageSize, (o => o.Company == BaseComp));
            }
            CustServ.Dispose();
            return Json(result);
        }

        public JsonResult Del(int id)
        {
            ResultDto<string> result = new ResultDto<string>();
            try
            {
                CustomerService ObjServ = new CustomerService();
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
        public JsonResult SyncCustomer()
        {
            ResultDto<int> result = new ResultDto<int>();
            try
            {
                CustomerService ObjServ = new CustomerService();
                result.code = 100;
                result.datas = ObjServ.RunProcSyncCustomer(BaseComp);
                ObjServ.Dispose();
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