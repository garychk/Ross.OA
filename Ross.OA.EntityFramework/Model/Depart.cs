using Ross.OA.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ross.OA.EntityFramework.Model
{
    [Table("Depart")]
    public class Depart : Entity<int>, ISoftDelete, IPassivable
    {
        [Required, MaxLength(8)]
        public string Company { get; set; }
        [Required, MaxLength(12)]
        public string DepartName { get; set; }
        [Required, MaxLength(8)]
        public string DepartCode { get; set; }
        [MaxLength(500)]
        public string Powers { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
