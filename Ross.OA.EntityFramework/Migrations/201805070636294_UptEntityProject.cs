namespace Ross.OA.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UptEntityProject : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProjectDetail", "ConsultDate", c => c.DateTime(storeType: "date"));
            AlterColumn("dbo.ProjectDetail", "DrawPlan", c => c.DateTime());
            AlterColumn("dbo.ProjectDetail", "DrawSubDate", c => c.DateTime());
            AlterColumn("dbo.ProjectDetail", "SaleConfirm", c => c.DateTime());
            AlterColumn("dbo.ProjectDetail", "MachinePlan", c => c.DateTime());
            AlterColumn("dbo.ProjectDetail", "MachineDrawing", c => c.DateTime());
            AlterColumn("dbo.ProjectDetail", "ElecPlan", c => c.DateTime());
            AlterColumn("dbo.ProjectDetail", "ElecDrawing", c => c.DateTime());
            AlterColumn("dbo.ProjectDetail", "PoWeldingPlan", c => c.DateTime());
            AlterColumn("dbo.ProjectDetail", "PoWeldingPrep", c => c.DateTime());
            AlterColumn("dbo.ProjectDetail", "PoPlan", c => c.DateTime());
            AlterColumn("dbo.ProjectDetail", "PoPrep", c => c.DateTime());
            AlterColumn("dbo.ProjectDetail", "ProdWeldingPlan", c => c.DateTime());
            AlterColumn("dbo.ProjectDetail", "ProdWeldingPrep", c => c.DateTime());
            AlterColumn("dbo.ProjectDetail", "MetalPlan", c => c.DateTime());
            AlterColumn("dbo.ProjectDetail", "MetalPrep", c => c.DateTime());
            AlterColumn("dbo.ProjectDetail", "MachiningPlan", c => c.DateTime());
            AlterColumn("dbo.ProjectDetail", "MachiningPrep", c => c.DateTime());
            AlterColumn("dbo.ProjectDetail", "MtlPlan", c => c.DateTime());
            AlterColumn("dbo.ProjectDetail", "MtlPrep", c => c.DateTime());
            AlterColumn("dbo.ProjectDetail", "PrepOver", c => c.DateTime());
            AlterColumn("dbo.ProjectDetail", "SATOver", c => c.DateTime());
            AlterColumn("dbo.ProjectDetail", "SaleDeliver", c => c.DateTime());
            AlterColumn("dbo.ProjectDetail", "EngineerPlan", c => c.DateTime());
            AlterColumn("dbo.ProjectDetail", "EngineerOver", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProjectDetail", "EngineerOver", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ProjectDetail", "EngineerPlan", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ProjectDetail", "SaleDeliver", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ProjectDetail", "SATOver", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ProjectDetail", "PrepOver", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ProjectDetail", "MtlPrep", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ProjectDetail", "MtlPlan", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ProjectDetail", "MachiningPrep", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ProjectDetail", "MachiningPlan", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ProjectDetail", "MetalPrep", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ProjectDetail", "MetalPlan", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ProjectDetail", "ProdWeldingPrep", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ProjectDetail", "ProdWeldingPlan", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ProjectDetail", "PoPrep", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ProjectDetail", "PoPlan", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ProjectDetail", "PoWeldingPrep", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ProjectDetail", "PoWeldingPlan", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ProjectDetail", "ElecDrawing", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ProjectDetail", "ElecPlan", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ProjectDetail", "MachineDrawing", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ProjectDetail", "MachinePlan", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ProjectDetail", "SaleConfirm", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ProjectDetail", "DrawSubDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ProjectDetail", "DrawPlan", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ProjectDetail", "ConsultDate", c => c.DateTime(nullable: false, storeType: "date"));
        }
    }
}
