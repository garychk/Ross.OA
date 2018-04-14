namespace Ross.OA.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoryModel2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Company = c.String(nullable: false, maxLength: 8),
                        CategoryName = c.String(nullable: false, maxLength: 50),
                        CategoryIndex = c.String(nullable: false, maxLength: 50),
                        Layout = c.String(nullable: false, maxLength: 50),
                        ParentId = c.Int(nullable: false),
                        Childs = c.Int(nullable: false),
                        Level = c.Int(nullable: false),
                        IsHide = c.Boolean(nullable: false),
                        Icons = c.String(maxLength: 50),
                        LinkUrl = c.String(maxLength: 500),
                        Intro = c.String(unicode: false, storeType: "text"),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Categories");
        }
    }
}
