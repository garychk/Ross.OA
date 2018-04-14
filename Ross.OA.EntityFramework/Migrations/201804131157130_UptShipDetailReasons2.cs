namespace Ross.OA.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UptShipDetailReasons2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ShipDetail", "Reasons", c => c.String(storeType: "ntext"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ShipDetail", "Reasons");
        }
    }
}
