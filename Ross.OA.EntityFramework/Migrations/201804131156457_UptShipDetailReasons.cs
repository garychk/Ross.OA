namespace Ross.OA.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UptShipDetailReasons : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ShipDetail", "Reasons");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ShipDetail", "Reasons", c => c.String(unicode: false, storeType: "text"));
        }
    }
}
