using Ross.OA.EntityFramework.Model;
using Ross.OA.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ross.OA.Application
{
    public class AffairService : RossOAppBase
    {
        public readonly IRepository<Affairs, long> Reposity;
        public AffairService()
        {
            Reposity = new Repository<Affairs, long>(dbContext);
        }
    }
}
