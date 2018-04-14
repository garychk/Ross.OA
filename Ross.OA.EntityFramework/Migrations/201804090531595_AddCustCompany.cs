namespace Ross.OA.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustCompany : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Company",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(nullable: false, maxLength: 50),
                        CompanyCode = c.String(nullable: false, maxLength: 20),
                        Address = c.String(maxLength: 500),
                        Telphone = c.String(maxLength: 20),
                        Fax = c.String(maxLength: 20),
                        Email = c.String(maxLength: 50),
                        Zipcode = c.String(maxLength: 20),
                        Taxrate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Comment = c.String(unicode: false, storeType: "text"),
                        Logo = c.String(maxLength: 50),
                        CreationTime = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Company = c.String(maxLength: 8),
                        CustID = c.String(nullable: false, maxLength: 20),
                        CustNum = c.String(nullable: false, maxLength: 20),
                        CustName = c.String(nullable: false, maxLength: 20),
                        Address1 = c.String(nullable: false, maxLength: 50),
                        Address2 = c.String(maxLength: 50),
                        Address3 = c.String(maxLength: 50),
                        Telphone = c.String(nullable: false, maxLength: 20),
                        Fax = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        City = c.String(maxLength: 50),
                        State = c.String(maxLength: 50),
                        Zip = c.String(maxLength: 10),
                        Country = c.String(maxLength: 50),
                        ShipviaCode = c.String(maxLength: 10),
                        CustURL = c.String(maxLength: 50),
                        EmpId = c.Int(nullable: false),
                        Logo = c.String(),
                        Contactor = c.String(maxLength: 50),
                        Comment = c.String(unicode: false, storeType: "text"),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employee", t => t.EmpId, cascadeDelete: true)
                .Index(t => t.EmpId);
            
            AlterColumn("dbo.ShipDetail", "Company", c => c.String(nullable: false, maxLength: 8));
            AlterColumn("dbo.ShipHead", "Company", c => c.String(nullable: false, maxLength: 8));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customer", "EmpId", "dbo.Employee");
            DropIndex("dbo.Customer", new[] { "EmpId" });
            AlterColumn("dbo.ShipHead", "Company", c => c.String());
            AlterColumn("dbo.ShipDetail", "Company", c => c.String());
            DropTable("dbo.Customer");
            DropTable("dbo.Company");
        }
    }
}
