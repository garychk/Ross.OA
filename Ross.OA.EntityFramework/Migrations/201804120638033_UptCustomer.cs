namespace Ross.OA.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UptCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customer", "SalesRepCode", c => c.String(maxLength: 8));
            AlterColumn("dbo.Customer", "CustName", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customer", "CustName", c => c.String(nullable: false, maxLength: 20));
            DropColumn("dbo.Customer", "SalesRepCode");
        }
    }
}
