using Ross.OA.Dto;
using Ross.OA.EntityFramework.Model;
using Ross.OA.Repositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Ross.OA.Application
{
    public class ShipService : RossOAppBase
    {
        public readonly IRepository<ShipHead, long> ReposityShipH;
        public readonly IRepository<ShipDetail, long> ReposityShipD;
        public ShipService()
        {
            ReposityShipH = new Repository<ShipHead, long>(dbContext);
            ReposityShipD = new Repository<ShipDetail, long>(dbContext);
        }

        public ResultDto<List<ShipHead>> GetShipWithEmp(int PageIndex, int PageSize, string Company, string keywords = "")
        {
            ResultDto<List<ShipHead>> result = new ResultDto<List<ShipHead>>();
            if (!string.IsNullOrEmpty(keywords)) {
                result = ReposityShipH.GetPageList(PageIndex, PageSize, (o => o.Company == Company && (o.ContractNum.Contains(keywords) || o.ProductNum.Contains(keywords) )));
            }
            else
            {
                result = ReposityShipH.GetPageList(PageIndex, PageSize, (o => o.Company == Company));
            }
            result.datas = result.datas.AsQueryable()
                .OrderByDescending(entity => entity.OrderDate)
                .Include(entity => entity.EmpId)
                .ToList();
            return result;
        }
    }
}
