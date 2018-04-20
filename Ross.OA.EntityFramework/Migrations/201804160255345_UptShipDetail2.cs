namespace Ross.OA.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UptShipDetail2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ShipDetail", "EnterPerson", c => c.String(maxLength: 20));
            AlterColumn("dbo.ShipHead", "EnterPerson", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ShipHead", "EnterPerson", c => c.String());
            DropColumn("dbo.ShipDetail", "EnterPerson");
        }
    }
}
