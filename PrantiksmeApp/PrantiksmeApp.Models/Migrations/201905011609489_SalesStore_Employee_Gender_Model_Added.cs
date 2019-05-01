namespace PrantiksmeApp.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SalesStore_Employee_Gender_Model_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        MiddleName = c.String(),
                        LastName = c.String(nullable: false),
                        ContactNo = c.String(nullable: false),
                        NIDNo = c.String(),
                        Address = c.String(nullable: false),
                        Email = c.String(),
                        Photo = c.Binary(),
                        ProprietorId = c.Long(),
                        SalesStoreId = c.Long(),
                        AppUserId = c.Long(nullable: false),
                        GenderId = c.Int(nullable: false),
                        UniversalCode = c.String(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        CreatedBy = c.Long(nullable: false),
                        ModifiedOn = c.DateTime(),
                        ModifiedBy = c.Long(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AppUsers", t => t.AppUserId)
                .ForeignKey("dbo.Genders", t => t.GenderId)
                .ForeignKey("dbo.SalesStores", t => t.SalesStoreId)
                .Index(t => t.SalesStoreId)
                .Index(t => t.AppUserId)
                .Index(t => t.GenderId);
            
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SalesStores",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        TradeLicenseNo = c.String(),
                        ContactNo = c.String(nullable: false),
                        UniversalCode = c.String(nullable: false),
                        ProprietorId = c.Long(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        CreatedBy = c.Long(nullable: false),
                        ModifiedOn = c.DateTime(),
                        ModifiedBy = c.Long(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "SalesStoreId", "dbo.SalesStores");
            DropForeignKey("dbo.Employees", "GenderId", "dbo.Genders");
            DropForeignKey("dbo.Employees", "AppUserId", "dbo.AppUsers");
            DropIndex("dbo.Employees", new[] { "GenderId" });
            DropIndex("dbo.Employees", new[] { "AppUserId" });
            DropIndex("dbo.Employees", new[] { "SalesStoreId" });
            DropTable("dbo.SalesStores");
            DropTable("dbo.Genders");
            DropTable("dbo.Employees");
        }
    }
}
