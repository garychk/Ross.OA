namespace Ross.OA.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEntityProject : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProjectDetail",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Company = c.String(maxLength: 50),
                        ProjectNum = c.String(maxLength: 50),
                        ProdQty = c.Decimal(nullable: false, precision: 18, scale: 2),
                        JobNum = c.String(maxLength: 50),
                        EquipmentModel = c.String(maxLength: 50),
                        SaleQty = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SalesPerson = c.String(maxLength: 50),
                        OrderDate = c.DateTime(nullable: false, storeType: "date"),
                        PromiseDate = c.DateTime(nullable: false, storeType: "date"),
                        ConsultDate = c.DateTime(nullable: false, storeType: "date"),
                        DrawDesignPerson = c.String(maxLength: 50),
                        DrawPlan = c.DateTime(nullable: false),
                        DrawSubDate = c.DateTime(nullable: false),
                        SaleConfirm = c.DateTime(nullable: false),
                        MachinePlan = c.DateTime(nullable: false),
                        MachineDrawing = c.DateTime(nullable: false),
                        ElecPlan = c.DateTime(nullable: false),
                        ElecDrawing = c.DateTime(nullable: false),
                        PoWeldingPlan = c.DateTime(nullable: false),
                        PoWeldingPrep = c.DateTime(nullable: false),
                        PoPlan = c.DateTime(nullable: false),
                        PoPrep = c.DateTime(nullable: false),
                        ProdWeldingPlan = c.DateTime(nullable: false),
                        ProdWeldingPrep = c.DateTime(nullable: false),
                        MetalPlan = c.DateTime(nullable: false),
                        MetalPrep = c.DateTime(nullable: false),
                        MachiningPlan = c.DateTime(nullable: false),
                        MachiningPrep = c.DateTime(nullable: false),
                        MtlPlan = c.DateTime(nullable: false),
                        MtlPrep = c.DateTime(nullable: false),
                        PrepPlan = c.DateTime(nullable: false),
                        PrepOver = c.DateTime(nullable: false),
                        SATOver = c.DateTime(nullable: false),
                        SaleDeliver = c.DateTime(nullable: false),
                        EngineerPlan = c.DateTime(nullable: false),
                        EngineerOver = c.DateTime(nullable: false),
                        OperateStage = c.String(maxLength: 50),
                        RespDept = c.String(maxLength: 50),
                        DetailInfo = c.String(maxLength: 500),
                        FocusInfo = c.String(maxLength: 500),
                        Remarks = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ProjectDetail");
        }
    }
}
