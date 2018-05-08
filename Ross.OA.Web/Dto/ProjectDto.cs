using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ross.OA.Web.Dto
{
    public class ProjectDetailDto
    {
        public long Id { get; set; }
        public string Company { get; set; }
        public string ProjectNum { get; set; }

        public decimal ProdQty { get; set; }

        public string JobNum { get; set; }

        public string EquipmentModel { get; set; }
        public decimal SaleQty { get; set; }

        public string SalesPerson { get; set; }
        public string OrderDate { get; set; }
        public string PromiseDate { get; set; }
        /// <summary>
        /// 协商日期
        /// </summary>
        public string ConsultDate { get; set; }
        /// <summary>
        /// 设计师
        /// </summary>

        public string DrawDesignPerson { get; set; }
        /// <summary>
        /// 确认图计划
        /// </summary>
        public string DrawPlan { get; set; }
        /// <summary>
        /// 确认图提交日期
        /// </summary>
        public string DrawSubDate { get; set; }
        /// <summary>
        /// 销售确认
        /// </summary>
        public string SaleConfirm { get; set; }
        /// <summary>
        /// 机械计划
        /// </summary>
        public string MachinePlan { get; set; }
        /// <summary>
        /// 机械下图
        /// </summary>
        public string MachineDrawing { get; set; }
        /// <summary>
        /// 电气计划
        /// </summary>
        public string ElecPlan { get; set; }
        /// <summary>
        /// 电气下图
        /// </summary>
        public string ElecDrawing { get; set; }
        /// <summary>
        /// 采购焊前计划
        /// </summary>
        public string PoWeldingPlan { get; set; }
        /// <summary>
        /// 采购焊前齐套
        /// </summary>
        public string PoWeldingPrep { get; set; }
        /// <summary>
        /// 采购计划
        /// </summary>
        public string PoPlan { get; set; }
        /// <summary>
        /// 采购齐套
        /// </summary>
        public string PoPrep { get; set; }
        /// <summary>
        /// 生产焊前计划
        /// </summary>
        public string ProdWeldingPlan { get; set; }
        /// <summary>
        /// 生产焊前齐套
        /// </summary>
        public string ProdWeldingPrep { get; set; }
        /// <summary>
        /// 钣金计划
        /// </summary>
        public string MetalPlan { get; set; }
        /// <summary>
        /// 钣金齐套
        /// </summary>
        public string MetalPrep { get; set; }
        /// <summary>
        /// 机加计划
        /// </summary>
        public string MachiningPlan { get; set; }
        /// <summary>
        /// 机加齐套
        /// </summary>
        public string MachiningPrep { get; set; }
        /// <summary>
        /// 物料计划
        /// </summary>
        public string MtlPlan { get; set; }
        /// <summary>
        /// 物料齐套
        /// </summary>
        public string MtlPrep { get; set; }
        /// <summary>
        /// 装配计划
        /// </summary>
        public string PrepPlan { get; set; }
        /// <summary>
        /// 装配完成
        /// </summary>
        public string PrepOver { get; set; }
        /// <summary>
        /// SAT完成
        /// </summary>
        public string SATOver { get; set; }
        /// <summary>
        /// 销售发货
        /// </summary>
        public string SaleDeliver { get; set; }
        /// <summary>
        /// 工程计划
        /// </summary>
        public string EngineerPlan { get; set; }
        /// <summary>
        /// 工程完成
        /// </summary>
        public string EngineerOver { get; set; }
        /// <summary>
        /// 运营阶段
        /// </summary>

        public string OperateStage { get; set; }
        /// <summary>
        /// 责任部门
        /// </summary>

        public string RespDept { get; set; }
        /// <summary>
        /// 详情
        /// </summary>
        public string DetailInfo { get; set; }
        /// <summary>
        /// 关注重点
        /// </summary>
        public string FocusInfo { get; set; }
        /// <summary>
        /// 备注
        /// </summary>            
        public string Remarks { get; set; }
    }
}