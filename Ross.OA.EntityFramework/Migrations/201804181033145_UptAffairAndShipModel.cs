namespace Ross.OA.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UptAffairAndShipModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Affairs", "PartNum", c => c.String(maxLength: 50));
            AddColumn("dbo.ShipHead", "ProductQty", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ShipHead", "ProductQty");
            DropColumn("dbo.Affairs", "PartNum");
        }
    }
}
