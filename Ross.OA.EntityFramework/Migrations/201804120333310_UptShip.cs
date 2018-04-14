namespace Ross.OA.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UptShip : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ShipHead", "ContractNum", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.ShipHead", "Comment", c => c.String(unicode: false, storeType: "text"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ShipHead", "Comment");
            DropColumn("dbo.ShipHead", "ContractNum");
        }
    }
}
