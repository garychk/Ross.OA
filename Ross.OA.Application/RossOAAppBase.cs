using Ross.OA.EntityFramework.Model;
using Ross.OA.Repositories;
using System;

namespace Ross.OA.Application
{
    public class RossOAppBase: IDisposable
    {
        protected EntityFramework.RossOADbContext dbContext;
        public RossOAppBase()
        {
            dbContext = new EntityFramework.RossOADbContext();
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}
