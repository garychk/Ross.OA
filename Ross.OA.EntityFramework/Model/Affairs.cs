using Ross.OA.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ross.OA.EntityFramework.Model
{
    [Table("Affairs")]
    public class Affairs : Entity<long>, ISoftDelete, IHasCreationTime, IMustHaveCompany
    {
        [Required, MaxLength(8)]
        public string Company { get; set; }
        [Required, MaxLength(50)]
        public string Title { get; set; }
        [Column(TypeName = "ntext")]
        public string Contents { get; set; }
        [MaxLength(50)]
        public string ContractNum { get; set; }
        [MaxLength(50)]
        public string PartNum { get; set; }
        [Column(TypeName = "ntext")]
        public string Reasons { get; set; }
        [Required]
        public DateTime CreationTime { get; set; }
        /// <summary>
        /// 审核日期
        /// </summary>
        public DateTime? ApproveTime { get; set; }
        /// <summary>
        /// 结束日期
        /// </summary>
        public DateTime? EndTime { get; set; }
        public int RespDepartId { get; set; }
        /// <summary>
        /// 责任部门
        /// </summary>
        [ForeignKey("RespDepartId")]
        public Depart RespDepart { get; set; }
        public bool IsDeleted { get; set; }
        /// <summary>
        /// 员工ID
        /// </summary>
        public int EmpId { get; set; }
        /// <summary>
        /// 责任员工
        /// </summary>
        public int RespEmpId { get; set; }
        [ForeignKey("RespEmpId")]
        public Employee RespEmp { get; set; }
        /// <summary>
        /// 紧急等级，1 -非常紧急，2 -紧急，3 -中等，4 -日常
        /// </summary>
        [DefaultValue(1)]
        public int EmergGrade { get; set; }
        /// <summary>
        /// 审核等级
        /// </summary>
        [DefaultValue(1)]
        public int ApproveGrade { get; set; }
        /// <summary>
        /// 审核状态，U -未提交审批，P -待批准，A -批准，R -被拒绝
        /// </summary>
        [MaxLength(2), DefaultValue("U")]
        public string ApproveStatus { get; set; }
        [DefaultValue(0)]
        public long ParentId { get; set; }
        public int Depth { get; set; }        
    }
}
