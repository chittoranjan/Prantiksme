namespace PrantiksmeApp.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmployeeModelAppUserTypeIdAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "AppUserTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Employees", "AppUserTypeId");
            AddForeignKey("dbo.Employees", "AppUserTypeId", "dbo.AppUserTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "AppUserTypeId", "dbo.AppUserTypes");
            DropIndex("dbo.Employees", new[] { "AppUserTypeId" });
            DropColumn("dbo.Employees", "AppUserTypeId");
        }
    }
}
