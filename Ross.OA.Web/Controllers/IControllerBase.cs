using System.Web.Mvc;

namespace Ross.OA.Web.Controllers
{
    public interface IControllerBase<T, TPrimaryKey>
    {
        JsonResult GetModel(TPrimaryKey id);
        JsonResult InsertOrUpdate(T input);
        JsonResult GetLists(int page, int pageSize,string keywords);
        JsonResult Del(TPrimaryKey id);

    }
}
