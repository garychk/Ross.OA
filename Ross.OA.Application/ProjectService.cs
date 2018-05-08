using Ross.OA.Dto;
using Ross.OA.EntityFramework.Model;
using Ross.OA.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;


namespace Ross.OA.Application
{
    public class ProjectService: RossOAppBase
    {
        public readonly IRepository<ProjectDetail, long> Reposity;
        public ProjectService()
        {
            Reposity = new Repository<ProjectDetail, long>(dbContext);
        }
    }
}
