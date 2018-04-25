using Ross.OA.EntityFramework.Model;
using Ross.OA.Repositories;
using System.Data;
using System.Data.SqlClient;

namespace Ross.OA.Application
{
    public class PartService : RossOAppBase
    {
        public readonly IRepository<Part, long> Reposity;
        public PartService()
        {
            Reposity = new Repository<Part, long>(dbContext);
        }

        public int RunProcSyncPart(string Company, bool IsDel)
        {
            var param1 = new SqlParameter { ParameterName = "Company", Value = Company, Direction = ParameterDirection.Input };
            var param2 = new SqlParameter { ParameterName = "IsDel", Value = IsDel, Direction = ParameterDirection.Input };
            return dbContext.Database.ExecuteSqlCommand("exec PROC_SyncPart @Company,@IsDel", param1, param2);
        }
    }
}
