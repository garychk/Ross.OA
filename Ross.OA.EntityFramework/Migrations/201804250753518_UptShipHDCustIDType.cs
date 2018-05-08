namespace Ross.OA.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UptShipHDCustIDType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ShipHead", "CustID", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ShipHead", "CustID", c => c.Long(nullable: false));
        }
    }
}
