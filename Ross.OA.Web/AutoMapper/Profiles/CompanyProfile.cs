using AutoMapper;
using Ross.OA.EntityFramework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ross.OA.Web.AutoMapper.Profiles
{
    public class EntityProfile: Profile
    {
        public EntityProfile()
        {
            CreateMap<Company, Dto.CompanyDto>();
            CreateMap<Employee, Dto.EmployeeDto>();
            CreateMap<Dto.EmployeeInput, Employee>();
            CreateMap<ProjectDetail, Dto.ProjectDetailDto>();
        }
    }
}