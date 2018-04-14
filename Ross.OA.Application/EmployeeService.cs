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
    public class EmployeeService: RossOAppBase
    {
        public readonly IRepository<Employee, int> ReposityEmp;
        public readonly IRepository<Depart, int> ReposityDept;
        public EmployeeService()
        {
            ReposityEmp = new Repository<Employee, int>(dbContext);
            ReposityDept = new Repository<Depart, int>(dbContext);
        }

        public ResultDto<List<Employee>> GetEmployeeWithDept(int PageIndex, int PageSize, Expression<Func<Employee, bool>> predicate)
        {
            var result = ReposityEmp.GetPageList(PageIndex, PageSize, predicate);
            result.datas = result.datas.AsQueryable()
                .OrderByDescending(entity => entity.Id)
                .Include(entity => entity.DepartId)
                .ToList();
            return result;
        }
    }
}
