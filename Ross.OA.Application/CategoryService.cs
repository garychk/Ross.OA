using Ross.OA.EntityFramework.Model;
using Ross.OA.Repositories;

namespace Ross.OA.Application
{
    public class CategoryService: RossOAppBase
    {
        public readonly IRepository<Categories, int> Reposity;
        public CategoryService()
        {
            Reposity = new Repository<Categories, int>(dbContext);
        }
    }
}
