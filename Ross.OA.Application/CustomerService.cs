using Ross.OA.EntityFramework.Model;
using Ross.OA.Repositories;

namespace Ross.OA.Application
{
    public class CustomerService : RossOAppBase
    {
        public readonly IRepository<Customer, int> Reposity;
        public CustomerService()
        {
            Reposity = new Repository<Customer, int>(dbContext);
        }
    }
}
