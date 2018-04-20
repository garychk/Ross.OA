namespace Ross.OA.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UptShipHead2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ShipDetail", "ProductNum", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.ShipHead", "ProductNum", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.ShipHead", "ShipSize", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ShipHead", "ShipSize", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.ShipHead", "ProductNum");
            DropColumn("dbo.ShipDetail", "ProductNum");
        }
    }
}
