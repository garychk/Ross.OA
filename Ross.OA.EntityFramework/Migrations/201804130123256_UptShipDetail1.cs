namespace Ross.OA.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UptShipDetail1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ShipDetail", "ShipQty", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.ShipDetail", "PartDesc", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.ShipDetail", "PartModel", c => c.String(maxLength: 50));
            AlterColumn("dbo.ShipDetail", "IUM", c => c.String(nullable: false, maxLength: 6));
            AlterColumn("dbo.ShipDetail", "RespDepartCodes", c => c.String(nullable: false, maxLength: 200));
            DropColumn("dbo.ShipDetail", "PartType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ShipDetail", "PartType", c => c.String(maxLength: 50));
            AlterColumn("dbo.ShipDetail", "RespDepartCodes", c => c.String(maxLength: 200));
            AlterColumn("dbo.ShipDetail", "IUM", c => c.String(maxLength: 6));
            AlterColumn("dbo.ShipDetail", "PartModel", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.ShipDetail", "PartDesc", c => c.String(maxLength: 500));
            DropColumn("dbo.ShipDetail", "ShipQty");
        }
    }
}
