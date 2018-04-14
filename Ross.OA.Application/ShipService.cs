using Ross.OA.Dto;
using Ross.OA.EntityFramework.Model;
using Ross.OA.Repositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Ross.OA.Application
{
    public class ShipService: RossOAppBase
    {
        public readonly IRepository<ShipHead, long> ReposityShipH;
        public readonly IRepository<ShipDetail, long> ReposityShipD;
        public ShipService()
        {
            ReposityShipH = new Repository<ShipHead, long>(dbContext);
            ReposityShipD = new Repository<ShipDetail, long>(dbContext);
        }

        public ResultDto<List<ShipHead>> GetShipWithEmp(int PageIndex, int PageSize, string Company)
        {
            ResultDto<List<ShipHead>> result = new ResultDto<List<ShipHead>>();
            var query = ReposityShipH.GetPageList(PageIndex, PageSize, (o => o.Company == Company));
            result.pages = query.pages;
            result.total = query.total;
            result.datas = query.datas.AsQueryable()
                .OrderByDescending(entity => entity.OrderDate)
                .Include(entity => entity.EmpId)
                .ToList();
            return result;
        }
    }
}
