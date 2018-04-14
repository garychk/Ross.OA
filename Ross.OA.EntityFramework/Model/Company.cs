using Ross.OA.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ross.OA.EntityFramework.Model
{
    [Table("Company")]
    public class Company : Entity<int>, ISoftDelete, IHasCreationTime
    {
        [Required, MaxLength(50)]
        public string CompanyName { get; set; }
        [Required, MaxLength(20)]
        public string CompanyCode { get; set; }
        [MaxLength(500)]
        public string Address { get; set; }
        [MaxLength(20)]
        public string Telphone { get; set; }
        [MaxLength(20)]
        public string Fax { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(20)]
        public string Zipcode { get; set; }
        public decimal Taxrate { get; set; }
        [Column(TypeName = "text")]
        public string Comment { get; set; }
        [MaxLength(50)]
        public string Logo { get; set; }
        public DateTime CreationTime { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
    }
}
