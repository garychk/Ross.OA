namespace Ross.OA.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UptShipDetail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ShipDetail", "Reasons", c => c.String(unicode: false, storeType: "text"));
            AddColumn("dbo.ShipDetail", "IsConfirm", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ShipDetail", "IsConfirm");
            DropColumn("dbo.ShipDetail", "Reasons");
        }
    }
}
