namespace Ross.OA.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UptShipHDCustIDType2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ShipHead", "CustID", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ShipHead", "CustID", c => c.String());
        }
    }
}
