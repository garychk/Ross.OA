namespace Ross.OA.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Affairs",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Contents = c.String(storeType: "ntext"),
                        CreationTime = c.DateTime(nullable: false),
                        ApproveTime = c.DateTime(),
                        EndTime = c.DateTime(),
                        RespDepartId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        EmpId = c.Int(nullable: false),
                        RespEmpId = c.Int(nullable: false),
                        EmergGrade = c.Int(nullable: false),
                        ApproveGrade = c.Int(nullable: false),
                        ApproveStatus = c.String(maxLength: 2),
                        ParentId = c.Long(nullable: false),
                        Depth = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Depart", t => t.RespDepartId, cascadeDelete: true)
                .ForeignKey("dbo.Employee", t => t.RespEmpId, cascadeDelete: true)
                .Index(t => t.RespDepartId)
                .Index(t => t.RespEmpId);
            
            CreateTable(
                "dbo.Depart",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Company = c.String(nullable: false, maxLength: 8),
                        DepartName = c.String(nullable: false, maxLength: 12),
                        DepartCode = c.String(nullable: false, maxLength: 8),
                        Powers = c.String(maxLength: 500),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Company = c.String(nullable: false, maxLength: 8),
                        UserId = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                        Powers = c.String(maxLength: 500),
                        Email = c.String(maxLength: 50),
                        Phone = c.String(maxLength: 50),
                        Address = c.String(maxLength: 100),
                        Position = c.String(maxLength: 10),
                        Sex = c.String(maxLength: 8),
                        DepartId = c.Int(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Depart", t => t.DepartId, cascadeDelete: false)
                .Index(t => t.DepartId);
            
            CreateTable(
                "dbo.Part",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        PartNum = c.String(nullable: false, maxLength: 20),
                        PartDesc = c.String(nullable: false, maxLength: 50),
                        IUM = c.String(nullable: false, maxLength: 6),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ShipDetail",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        PartNum = c.String(nullable: false, maxLength: 50),
                        PartDesc = c.String(maxLength: 500),
                        PartType = c.String(maxLength: 50),
                        PartModel = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IUM = c.String(maxLength: 6),
                        SONum = c.String(maxLength: 20),
                        ReasonCode = c.String(maxLength: 6),
                        RespDepartCodes = c.String(maxLength: 200),
                        OpenLine = c.Boolean(nullable: false),
                        ShipID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ShipHead", t => t.ShipID, cascadeDelete: true)
                .Index(t => t.ShipID);
            
            CreateTable(
                "dbo.ShipHead",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        OrderNum = c.String(nullable: false, maxLength: 20),
                        OrderDate = c.DateTime(nullable: false),
                        CustID = c.Long(nullable: false),
                        ShipviaCode = c.String(nullable: false, maxLength: 10),
                        EnterPerson = c.String(),
                        EmpId = c.Int(nullable: false),
                        OpenOrder = c.Boolean(nullable: false),
                        ApproveStatus = c.String(maxLength: 2),
                        IsConfirm = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employee", t => t.EmpId, cascadeDelete: true)
                .Index(t => t.EmpId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShipDetail", "ShipID", "dbo.ShipHead");
            DropForeignKey("dbo.ShipHead", "EmpId", "dbo.Employee");
            DropForeignKey("dbo.Affairs", "RespEmpId", "dbo.Employee");
            DropForeignKey("dbo.Employee", "DepartId", "dbo.Depart");
            DropForeignKey("dbo.Affairs", "RespDepartId", "dbo.Depart");
            DropIndex("dbo.ShipHead", new[] { "EmpId" });
            DropIndex("dbo.ShipDetail", new[] { "ShipID" });
            DropIndex("dbo.Employee", new[] { "DepartId" });
            DropIndex("dbo.Affairs", new[] { "RespEmpId" });
            DropIndex("dbo.Affairs", new[] { "RespDepartId" });
            DropTable("dbo.ShipHead");
            DropTable("dbo.ShipDetail");
            DropTable("dbo.Part");
            DropTable("dbo.Employee");
            DropTable("dbo.Depart");
            DropTable("dbo.Affairs");
        }
    }
}
