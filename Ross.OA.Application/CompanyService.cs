using Ross.OA.EntityFramework.Model;
using Ross.OA.Repositories;

namespace Ross.OA.Application
{
    public class CompanyService: RossOAppBase
    {
        public readonly IRepository<Company, int> Reposity;
        public CompanyService()
        {
            Reposity = new Repository<Company, int>(dbContext);
        }
    }
}
