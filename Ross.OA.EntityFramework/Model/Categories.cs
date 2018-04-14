using Ross.OA.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ross.OA.EntityFramework.Model
{
    [Table("Categories")]
    public class Categories : Entity<int>, IMustHaveCompany, ISoftDelete
    {
        [Required, MaxLength(8)]
        public string Company { get; set; }
        [Required, MaxLength(50)]
        public virtual string CategoryName { get; set; }
        [Required, MaxLength(50)]
        public virtual string CategoryIndex { get; set; }
        [Required, MaxLength(50)]
        public virtual string Layout { get; set; }
        [Required]
        public virtual int ParentId { get; set; }
        [Required]
        public virtual int Childs { get; set; }
        [Required]
        public virtual int Level { get; set; }
        [Required]
        public bool IsHide { get; set; }
        [MaxLength(50)]
        public string Icons { get; set; }
        [MaxLength(500)]
        public string LinkUrl { get; set; }
        [Column(TypeName = "text")]
        public string Intro { get; set; }
        public bool IsDeleted { get; set; }
        
    }
}
