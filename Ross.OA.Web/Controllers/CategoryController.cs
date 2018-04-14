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
    public class CategoryController : BaseController, IControllerBase<Categories, int>
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Edit(int id)
        {
            ViewBag.Id = id;
            return View();
        }
        public JsonResult Del(int id)
        {
            ResultDto<string> result = new ResultDto<string>();
            try
            {
                CategoryService Category = new CategoryService();
                Category.Reposity.Delete(id);
                result.code = 100;
                result.message = "success";
                Category.Dispose();
            }
            catch (Exception ex)
            {
                result.message = ex.Message;
            }
            return Json(result);
        }

        public JsonResult GetLists(int page, int pageSize, string keywords = "")
        {
            CategoryService Category = new CategoryService();
            var result = Category.Reposity.GetPageList(page, pageSize, (o => o.Company == Company));
            Category.Dispose();
            return Json(result);
        }

        public JsonResult GetModel(int id)
        {
            Categories model = new Categories();
            using (CategoryService Category = new CategoryService())
            {
                var result = Category.Reposity.FirstOrDefault(id);
                if (result != null)
                    model = result;
            }
            return Json(model);
        }
        public JsonResult GetModelWithParents(int id)
        {
            CategoryWithParents dto = new CategoryWithParents();
            Categories entity = new Categories();
            CategoryService Category = new CategoryService();
            var result = Category.Reposity.FirstOrDefault(id);
            if (result != null)
                entity = result;
            dto.Category = entity;
            dto.ParentLists = GetCategoryTree(Company);
            return Json(dto);
        }

        public JsonResult InsertOrUpdate(Categories input)
        {
            ResultDto<Categories> result = new ResultDto<Categories>();
            try {
                List<Categories> AllCate = new List<Categories>();
                CategoryService CategoryRead = new CategoryService();
                CategoryService Category = new CategoryService();
                AllCate = CategoryRead.Reposity.GetAllList(o => o.Company == Company);
                input.Company = Company;
                input.Level = CsmLevel(input.ParentId, AllCate);
                result.datas = Category.Reposity.InsertOrUpdate(input);
                Category.Dispose();
                CategoryRead.Dispose();
                result.code = 100;
                result.message = "ok";
            } catch(Exception ex) {
                result.code = 500;
                result.message = ex.Message + "; " + ex.StackTrace;
            }            
            return Json(result);
        }
        public int CsmLevel(int parentid, List<Categories> Categorys, int result = 0)
        {
            var parent = Categorys.Where(o => o.Id == parentid).FirstOrDefault();
            if (parent == null)
            {
                return result;
            }
            else
            {
                result++;
                return CsmLevel(parent.ParentId, Categorys, result);
            }
        }

        public JsonResult GetTreeList(string layout = "")
        {
            ResultDto<List<CategoryTree>> result = new ResultDto<List<CategoryTree>>();
            var lists = GetCategoryTree(Company);
            if (!string.IsNullOrEmpty(layout))
            {
                lists = lists.Where(o => o.Layout == layout).ToList();
            }
            result.datas = lists;
            result.code = 100;
            result.total = lists.Count;
            return Json(result);
        }

        public List<CategoryTree> GetCategoryTree(string Company = "")
        {
            CategoryService Category = new CategoryService();
            var result = Category.Reposity.GetAllList();
            if (!string.IsNullOrEmpty(Company))
            {
                result = result.Where(o => o.Company == Company).ToList();
            }
            List<Categories> lists = new List<Categories>();
            CreateTree(lists, result);
            var elist = Mapper.Map<List<Dto.CategoryTree>>(lists);
            foreach (var item in elist)
            {
                string prev = "";
                if (item.Level > 0)
                {
                    prev = "└";
                    for (int i = 0; i < item.Level; i++)
                    {
                        prev += "┴";
                    }
                }
                item.PrevStr = prev;
            }
            Category.Dispose();
            return elist;
        }

        public void CreateTree(List<Categories> lists, List<Categories> Categorys, int partntid = 0)
        {
            var items = Categorys.Where(o => o.ParentId == partntid).ToList();
            foreach (var item in items)
            {
                lists.Add(item);
                if (Categorys.Where(o => o.ParentId == item.Id).Count() > 0)
                {
                    CreateTree(lists, Categorys, item.Id);
                }
            }
        }
    }
}