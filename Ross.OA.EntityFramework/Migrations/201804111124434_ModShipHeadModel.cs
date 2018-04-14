namespace Ross.OA.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModShipHeadModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ShipHead", "PromiseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.ShipHead", "RespDepartCodes", c => c.String(maxLength: 200));
            AddColumn("dbo.ShipHead", "RevNum", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ShipHead", "RevNum");
            DropColumn("dbo.ShipHead", "RespDepartCodes");
            DropColumn("dbo.ShipHead", "PromiseDate");
        }
    }
}
