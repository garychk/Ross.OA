using Ross.OA.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ross.OA.EntityFramework.Model
{
    [Table("Customer")]
    public class Customer : Entity<int>, ISoftDelete, IMustHaveCompany
    {
        [MaxLength(8)]
        public string Company { get; set; }
        [Required, MaxLength(20)]
        public string CustID { get; set; }
        [Required, MaxLength(20)]
        public string CustNum { get; set; }
        [Required, MaxLength(50)]
        public string CustName { get; set; }
        [Required, MaxLength(50)]
        public string Address1 { get; set; }
        [MaxLength(50)]
        public string Address2 { get; set; }
        [MaxLength(50)]
        public string Address3 { get; set; }
        [Required, MaxLength(20)]
        public string Telphone { get; set; }
        [MaxLength(50)]
        public string Fax { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(50)]
        public string City { get; set; }
        [MaxLength(50)]
        public string State { get; set; }
        [MaxLength(10)]
        public string Zip { get; set; }
        [MaxLength(50)]
        public string Country { get; set; }
        [MaxLength(10)]
        public string ShipviaCode { get; set; }
        [MaxLength(50)]
        public string CustURL { get; set; }
        public int EmpId { get; set; }
        [ForeignKey("EmpId")]
        public Employee Emp { get; set; }
        [MaxLength(8)]
        public string SalesRepCode { get; set; }
        public string Logo { get; set; }
        [MaxLength(50)]
        public string Contactor { get; set; }        
        [Column(TypeName = "text")]
        public string Comment { get; set; }
        public bool IsDeleted { get; set; }
    }
}
