using Ross.OA.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ross.OA.EntityFramework.Model
{
    [Table("ShipDetail")]
    public class ShipDetail : Entity<long>, IMustHaveCompany
    {
        [Required, MaxLength(8)]
        public string Company { get; set; }
        [Required, StringLength(50)]
        public string ProductNum { get; set; }
        [Required, StringLength(50)]
        public string PartNum { get; set; }
        [Required, StringLength(500)]
        public string PartDesc { get; set; }
        [StringLength(50)]
        public string PartModel { get; set; }
        [Required]
        public decimal ShipQty { get; set; }
        [Required, StringLength(6)]
        public string IUM { get; set; }
        [StringLength(20)]
        public string SONum { get; set; }
        [StringLength(6)]
        public string ReasonCode { get; set; }
        [Column(TypeName = "ntext")]
        public string Reasons { get; set; }
        [Required, StringLength(200)]
        public string RespDepartCodes { get; set; }
        [DefaultValue(1)]
        public bool OpenLine { get; set; }
        [Required]
        public long ShipID { get; set; }
        [ForeignKey("ShipID")]
        public ShipHead ShipHd { get; set; }
        public bool IsConfirm { get; set; }
        [StringLength(20)]
        public string EnterPerson { get; set; }

    }
}
