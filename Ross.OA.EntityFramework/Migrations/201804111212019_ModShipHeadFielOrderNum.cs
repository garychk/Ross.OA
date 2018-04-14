namespace Ross.OA.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModShipHeadFielOrderNum : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ShipHead", "OrderNum", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ShipHead", "OrderNum", c => c.String(nullable: false, maxLength: 20));
        }
    }
}
