using Ross.OA.EntityFramework.Model;
using Ross.OA.Repositories;
using System.Data;
using System.Data.SqlClient;

namespace Ross.OA.Application
{
    public class CustomerService : RossOAppBase
    {
        public readonly IRepository<Customer, int> Reposity;
        public CustomerService()
        {
            Reposity = new Repository<Customer, int>(dbContext);
        }
        public int RunProcSyncCustomer(string Company)
        {
            var param1 = new SqlParameter { ParameterName = "Company", Value = Company, Direction = ParameterDirection.Input };
            return dbContext.Database.ExecuteSqlCommand("exec PROC_SyncCustomer @Company", param1);
        }
    }
}
