using Ross.OA.EntityFramework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ross.OA.Web.Dto
{
    public class AffairOutput
    {
        public long Id { get; set; }
        public string Company { get; set; }
        public string Title { get; set; }
        public string Contents { get; set; }
        public string ContractNum { get; set; }
        public string PartNum { get; set; }
        public string Reasons { get; set; }
        public string CreationTime { get; set; }
        public string ApproveTime { get; set; }
        public string EndTime { get; set; }
        public string FromNowTime { get; set; }
        public int RespDepartId { get; set; }
        public bool IsDeleted { get; set; }
        public int EmpId { get; set; }
        public int RespEmpId { get; set; }
        public Depart RespDepart { get; set; }
        /// <summary>
        /// 紧急等级，1 -非常紧急，2 -紧急，3 -中等，4 -日常
        /// </summary>
        public int EmergGrade { get; set; }
        /// <summary>
        /// 审核等级
        /// </summary>
        public int ApproveGrade { get; set; }
        /// <summary>
        /// 审核状态，U -未提交审批，P -待批准，A -批准，R -被拒绝
        /// </summary>
        public string ApproveStatus { get; set; }
    }

    public class AffairWithShip
    {
        public AffairOutput Affair { get; set; }
        public ShipHead ShipHd { get; set; }
        public ShipDetail ShipDT { get; set; }
    }
}