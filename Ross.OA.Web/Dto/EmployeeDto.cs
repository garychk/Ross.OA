using Ross.OA.EntityFramework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ross.OA.Web.Dto
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Company { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Position { get; set; }
        public string Sex { get; set; }
        public int DepartId { get; set; }
        public Depart Depart { get; set; }
        public string CreationTime { get; set; }
        public bool IsDeleted { get; set; }
    }
    public class EmployeeInput
    {
        public int Id { get; set; }
        public string Company { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Position { get; set; }
        public string Sex { get; set; }
        public int DepartId { get; set; }
        public string CreationTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}