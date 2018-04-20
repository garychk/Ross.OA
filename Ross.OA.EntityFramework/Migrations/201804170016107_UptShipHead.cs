namespace Ross.OA.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UptShipHead : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ShipHead", "ShipSize", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.ShipHead", "ShipWeight", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ShipHead", "ShipWeight");
            DropColumn("dbo.ShipHead", "ShipSize");
        }
    }
}
