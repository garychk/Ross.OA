using Ross.OA.EntityFramework.Model;
using Ross.OA.Repositories;


namespace Ross.OA.Application
{
    public class PartService: RossOAppBase
    {
        public readonly IRepository<Part, long> Reposity;
        public PartService()
        {
            Reposity = new Repository<Part, long>(dbContext);
        }
    }
}
