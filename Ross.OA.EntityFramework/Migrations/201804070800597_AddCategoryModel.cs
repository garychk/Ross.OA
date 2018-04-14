namespace Ross.OA.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoryModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Affairs", "Company", c => c.String(nullable: false, maxLength: 8));
            AddColumn("dbo.Part", "Company", c => c.String(nullable: false, maxLength: 8));
            AddColumn("dbo.ShipDetail", "Company", c => c.String());
            AddColumn("dbo.ShipHead", "Company", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ShipHead", "Company");
            DropColumn("dbo.ShipDetail", "Company");
            DropColumn("dbo.Part", "Company");
            DropColumn("dbo.Affairs", "Company");
        }
    }
}
