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
    [Filters.FilterCheckLogin]
    public class ShipController : BaseController, IControllerBase<ShipHead, long>
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Detail()
        {
            return View();
        }
        public ActionResult Edit(int id = 0)
        {
            ViewBag.Id = id;
            return View();
        }
        public JsonResult Del(long id)
        {
            ResultDto<string> result = new ResultDto<string>();
            try
            {
                ShipService ObjServ = new ShipService();
                ObjServ.ReposityShipH.Delete(id);
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
            ResultDto<List<Dto.ShipHdDto>> result = new ResultDto<List<Dto.ShipHdDto>>();
            ShipService ShipServ = new ShipService();
            var lists = ShipServ.GetShipWithEmp(page, pageSize, Company);
            result = Mapper.Map<ResultDto<List<Dto.ShipHdDto>>>(lists);
            ShipServ.Dispose();
            return Json(result);
        }

        public JsonResult GetDetailLists(int page, int pageSize, long shipid)
        {
            ResultDto<List<ShipDetail>> result = new ResultDto<List<ShipDetail>>();
            ShipService ShipServ = new ShipService();
            result = ShipServ.ReposityShipD.GetPageList(page, pageSize, o => o.ShipID == shipid);
            ShipServ.Dispose();
            return Json(result);
        }

        public JsonResult GetModel(long id)
        {
            Dto.ShipHdInput model = new Dto.ShipHdInput();
            using (ShipService ObjServ = new ShipService())
            {
                if (id > 0)
                {
                    var result = ObjServ.ReposityShipH.FirstOrDefault(id);
                    if (result != null)
                    {
                        model = Mapper.Map<Dto.ShipHdInput>(result);
                    }
                }
                else
                {
                    model.OrderDate = DateTime.Now.ToShortDateString();
                    model.PromiseDate = DateTime.Now.ToShortDateString();
                    model.EnterPerson = AppBase.CookieVal("EmpName");
                }
            }
            return Json(model);
        }
        public JsonResult GetShipDetail(long id)
        {
            ShipDetail model = new ShipDetail();
            using (ShipService ObjServ = new ShipService())
            {
                var result = ObjServ.ReposityShipD.FirstOrDefault(id);
                if (result != null)
                    model = result;
            }
            return Json(model);
        }

        public JsonResult InsertOrUpdateHD(Dto.ShipInput input)
        {
            ResultDto<long> result = new ResultDto<long>();
            using (ShipService ObjServ = new ShipService())
            {
                try
                {
                    var entity = Mapper.Map<ShipHead>(input.ShipHd);
                    entity.Company = Company;
                    entity.EmpId = EmpId;
                    ObjServ.ReposityShipH.InsertOrUpdate(entity);
                    result.code = 100;
                    result.message = "ok";
                    result.datas = entity.Id;
                    if (entity.Id > 0)
                    {
                        input.ShipDt.ShipID = entity.Id;
                        var result_dt = InsertOrUpdateDT(input.ShipDt);
                        if (result_dt.code != 100)
                        {
                            result.code = result_dt.code;
                            result.message = result_dt.message;
                        }
                    }
                }
                catch (Exception ex)
                {
                    result.code = 500;
                    result.message = ex.Message;
                    log.Error(ex.StackTrace);
                }
            }
            return Json(result);
        }
        public ResultDto<long> InsertOrUpdateDT(ShipDetail input)
        {
            ResultDto<long> result = new ResultDto<long>();
            using (ShipService ObjServ = new ShipService())
            {
                try
                {
                    input.Company = Company;
                    ObjServ.ReposityShipD.InsertOrUpdate(input);
                    result.code = 100;
                    result.message = "ok";
                    result.datas = input.Id;
                }
                catch (Exception ex)
                {
                    result.code = 500;
                    result.message = ex.Message;
                    log.Error(ex.StackTrace);
                }
            }
            return result;
        }

        public JsonResult GetOrderNum()
        {
            long result = 1000;
            using (ShipService ObjServ = new ShipService())
            {
                if (ObjServ.ReposityShipH.Count() > 0)
                {
                    long MaxNum = ObjServ.ReposityShipH.GetAllList().Max(o => o.OrderNum);
                    result = MaxNum + 1;
                }
            }
            return Json(result);
        }

        public JsonResult InsertOrUpdate(ShipHead input)
        {
            throw new NotImplementedException();
        }
    }
}