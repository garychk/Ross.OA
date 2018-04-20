using Ross.OA.EntityFramework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ross.OA.Web.Dto
{
    public class ShipDto
    {
        public ShipHdDto ShipHd { get; set; }
        public List<ShipDetail> ShipDetailList { get; set; }
    }

    public class ShipHdDto
    {
        public long Id { get; set; }
        public string Company { get; set; }
        public string ProductNum { get; set; }
        public decimal ProductQty { get; set; }
        public string OrderNum { get; set; }
        public string OrderDate { get; set; }
        public long CustID { get; set; }
        public string ShipviaCode { get; set; }
        public string EnterPerson { get; set; }
        public Employee Emp { get; set; }
        public string RevNum { get; set; }
        public string ContractNum { get; set; }
        public int affairCount { get; set; }
    }
    public class PartSelect
    {
        public string PartNum { get; set; }
        public string PartDesc { get; set; }
        public string IUM { get; set; }
    }
    public class ShipHdOutput
    {
        public long Id { get; set; }
        public string Company { get; set; }
        public long OrderNum { get; set; }
        public string OrderDate { get; set; }
        public string PromiseDate { get; set; }
        public long CustID { get; set; }
        public string ShipviaCode { get; set; }
        public string EnterPerson { get; set; }
        public int EmpId { get; set; }
        public bool OpenOrder { get; set; }
        public string ApproveStatus { get; set; }
        public bool IsConfirm { get; set; }
        public bool IsDeleted { get; set; }
        public string RespDepartCodes { get; set; }
        public string ContractNum { get; set; }
        public string RevNum { get; set; }
        public string Comment { get; set; }
        public string ShipSize { get; set; }
        public decimal ShipWeight { get; set; }
        public string ProductNum { get; set; }
        public decimal ProductQty { get; set; }
    }

    public class ShipInput
    {
        public ShipHdOutput ShipHd { get; set; }
        public ShipDetail ShipDt { get; set; }
    }

    public class ShipDetailOutput
    {
        public int RowNum { get; set; }
        public long Id { get; set; }
        public string Company { get; set; }
        public string ProductNum { get; set; }
        public string PartNum { get; set; }
        public string PartDesc { get; set; }
        public string IUM { get; set; }
        public string PartModel { get; set; }
        public decimal ShipQty { get; set; }
        public string SONum { get; set; }
        public string Reasons { get; set; }
        public string RespDepartCodes { get; set; }
        public string RespDepartNames { get; set; }
        public bool OpenLine { get; set; }
        public bool IsConfirm { get; set; }
        public string EnterPerson { get; set; }
        public int affairCount { get; set; }
    }
}