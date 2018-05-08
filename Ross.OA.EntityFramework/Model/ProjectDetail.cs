using Ross.OA.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Ross.OA.EntityFramework.Model
{
    [Table("ProjectDetail")]
    public class ProjectDetail : Entity<long>
    {
        [MaxLength(50)]
        public string Company { get; set; }
        [MaxLength(50)]
        public string ProjectNum { get; set; }

        public decimal ProdQty { get; set; }
        [MaxLength(50)]
        public string JobNum { get; set; }
        [MaxLength(50)]
        public string EquipmentModel { get; set; }
        public decimal SaleQty { get; set; }
        [MaxLength(50)]
        public string SalesPerson { get; set; }
        [Column(TypeName = "date")]
        public DateTime? OrderDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? PromiseDate { get; set; }
        /// <summary>
        /// 协商日期
        /// </summary>
        [Column(TypeName = "date")]
        public DateTime? ConsultDate { get; set; }
        /// <summary>
        /// 设计师
        /// </summary>
        [MaxLength(50)]
        public string DrawDesignPerson { get; set; }
        /// <summary>
        /// 确认图计划
        /// </summary>
        public DateTime? DrawPlan { get; set; }
        /// <summary>
        /// 确认图提交日期
        /// </summary>
        public DateTime? DrawSubDate { get; set; }
        /// <summary>
        /// 销售确认
        /// </summary>
        public DateTime? SaleConfirm { get; set; }
        /// <summary>
        /// 机械计划
        /// </summary>
        public DateTime? MachinePlan { get; set; }
        /// <summary>
        /// 机械下图
        /// </summary>
        public DateTime? MachineDrawing { get; set; }
        /// <summary>
        /// 电气计划
        /// </summary>
        public DateTime? ElecPlan { get; set; }
        /// <summary>
        /// 电气下图
        /// </summary>
        public DateTime? ElecDrawing { get; set; }
        /// <summary>
        /// 采购焊前计划
        /// </summary>
        public DateTime? PoWeldingPlan { get; set; }
        /// <summary>
        /// 采购焊前齐套
        /// </summary>
        public DateTime? PoWeldingPrep { get; set; }
        /// <summary>
        /// 采购计划
        /// </summary>
        public DateTime? PoPlan { get; set; }
        /// <summary>
        /// 采购齐套
        /// </summary>
        public DateTime? PoPrep { get; set; }
        /// <summary>
        /// 生产焊前计划
        /// </summary>
        public DateTime? ProdWeldingPlan { get; set; }
        /// <summary>
        /// 生产焊前齐套
        /// </summary>
        public DateTime? ProdWeldingPrep { get; set; }
        /// <summary>
        /// 钣金计划
        /// </summary>
        public DateTime? MetalPlan { get; set; }
        /// <summary>
        /// 钣金齐套
        /// </summary>
        public DateTime? MetalPrep { get; set; }
        /// <summary>
        /// 机加计划
        /// </summary>
        public DateTime? MachiningPlan { get; set; }
        /// <summary>
        /// 机加齐套
        /// </summary>
        public DateTime? MachiningPrep { get; set; }
        /// <summary>
        /// 物料计划
        /// </summary>
        public DateTime? MtlPlan { get; set; }
        /// <summary>
        /// 物料齐套
        /// </summary>
        public DateTime? MtlPrep { get; set; }
        /// <summary>
        /// 装配计划
        /// </summary>
        public DateTime? PrepPlan { get; set; }
        /// <summary>
        /// 装配完成
        /// </summary>
        public DateTime? PrepOver { get; set; }
        /// <summary>
        /// SAT完成
        /// </summary>
        public DateTime? SATOver { get; set; }
        /// <summary>
        /// 销售发货
        /// </summary>
        public DateTime? SaleDeliver { get; set; }
        /// <summary>
        /// 工程计划
        /// </summary>
        public DateTime? EngineerPlan { get; set; }
        /// <summary>
        /// 工程完成
        /// </summary>
        public DateTime? EngineerOver { get; set; }
        /// <summary>
        /// 运营阶段
        /// </summary>
        [MaxLength(50)]
        public string OperateStage { get; set; }
        /// <summary>
        /// 责任部门
        /// </summary>
        [MaxLength(50)]
        public string RespDept { get; set; }
        /// <summary>
        /// 详情
        /// </summary>
        [MaxLength(500)]
        public string DetailInfo { get; set; }
        /// <summary>
        /// 关注重点
        /// </summary>
        [MaxLength(500)]
        public string FocusInfo { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [MaxLength(500)]
        public string Remarks { get; set; }
    }
}
