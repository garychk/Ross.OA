namespace Ross.OA.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UptAffairModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Affairs", "ContractNum", c => c.String(maxLength: 50));
            AddColumn("dbo.Affairs", "Reasons", c => c.String(storeType: "ntext"));
            AlterColumn("dbo.ShipHead", "ContractNum", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ShipHead", "ContractNum", c => c.String(nullable: false, maxLength: 20));
            DropColumn("dbo.Affairs", "Reasons");
            DropColumn("dbo.Affairs", "ContractNum");
        }
    }
}
