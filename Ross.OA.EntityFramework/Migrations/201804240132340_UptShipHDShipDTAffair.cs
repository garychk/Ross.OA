namespace Ross.OA.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UptShipHDShipDTAffair : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Affairs", "Objects", c => c.String(maxLength: 50));
            AddColumn("dbo.ShipDetail", "TypeCode", c => c.String(maxLength: 2));
            AddColumn("dbo.ShipHead", "PONum", c => c.Int(nullable: false));
            AddColumn("dbo.ShipHead", "TransportSN", c => c.String(maxLength: 50));
            AddColumn("dbo.ShipHead", "FollowUpUser", c => c.String(maxLength: 50));
            AddColumn("dbo.ShipHead", "PackageType", c => c.String(maxLength: 10));
            AddColumn("dbo.ShipHead", "OTSContact", c => c.String(maxLength: 50));
            AddColumn("dbo.ShipHead", "OTSName", c => c.String(maxLength: 50));
            AddColumn("dbo.ShipHead", "OTSAddress", c => c.String(maxLength: 50));
            AddColumn("dbo.ShipHead", "OTSPhone", c => c.String(maxLength: 50));
            AddColumn("dbo.ShipHead", "OTSFax", c => c.String(maxLength: 50));
            AddColumn("dbo.ShipHead", "OTSZip", c => c.String(maxLength: 50));
            AddColumn("dbo.ShipHead", "JoinSign", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ShipHead", "JoinSign");
            DropColumn("dbo.ShipHead", "OTSZip");
            DropColumn("dbo.ShipHead", "OTSFax");
            DropColumn("dbo.ShipHead", "OTSPhone");
            DropColumn("dbo.ShipHead", "OTSAddress");
            DropColumn("dbo.ShipHead", "OTSName");
            DropColumn("dbo.ShipHead", "OTSContact");
            DropColumn("dbo.ShipHead", "PackageType");
            DropColumn("dbo.ShipHead", "FollowUpUser");
            DropColumn("dbo.ShipHead", "TransportSN");
            DropColumn("dbo.ShipHead", "PONum");
            DropColumn("dbo.ShipDetail", "TypeCode");
            DropColumn("dbo.Affairs", "Objects");
        }
    }
}
