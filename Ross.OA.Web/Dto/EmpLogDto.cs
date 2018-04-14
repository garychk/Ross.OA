using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ross.OA.Web.Dto
{
    public class EmpLogDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<CompanyDto> Companys { get; set; }
       
    }
    public class CompanyDto
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string CompanyCode { get; set; }
    }
}