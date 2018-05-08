namespace Ross.OA.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UptEntityProject2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProjectDetail", "OrderDate", c => c.DateTime(storeType: "date"));
            AlterColumn("dbo.ProjectDetail", "PromiseDate", c => c.DateTime(storeType: "date"));
            AlterColumn("dbo.ProjectDetail", "PrepPlan", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProjectDetail", "PrepPlan", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ProjectDetail", "PromiseDate", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.ProjectDetail", "OrderDate", c => c.DateTime(nullable: false, storeType: "date"));
        }
    }
}
