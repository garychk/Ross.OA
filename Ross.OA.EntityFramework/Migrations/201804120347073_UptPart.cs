namespace Ross.OA.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UptPart : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Part", "PartDesc", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Part", "PartDesc", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
