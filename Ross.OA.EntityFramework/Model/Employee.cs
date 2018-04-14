using Ross.OA.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ross.OA.EntityFramework.Model
{
    [Table("Employee")]
    public class Employee : Entity<int>, IHasCreationTime,ISoftDelete, IMustHaveCompany
    {
        [Required, MaxLength(8)]
        public string Company { get; set; }
        public int UserId { get; set; }
        [Required, MaxLength(50)]
        public string UserName { get; set; }
        [Required, MaxLength(50)]
        public string Password { get; set; }
        [MaxLength(500)]
        public string Powers { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(50)]
        public string Phone { get; set; }
        [MaxLength(100)]
        public string Address { get; set; }
        [MaxLength(10)]
        public string Position { get; set; }
        [MaxLength(8)]
        public string Sex { get; set; }
        public int DepartId { get; set; }
        [ForeignKey("DepartId")]
        public Depart Depart { get; set; }
        public DateTime CreationTime { get; set; }
        public bool IsDeleted { get; set; }
        public Employee()
        {
            CreationTime = DateTime.Now;
        }
    }
}
