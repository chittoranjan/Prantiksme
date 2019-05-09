namespace PrantiksmeApp.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerAndEmployeeModelUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Email", c => c.String());
            AddColumn("dbo.Employees", "DateOfBirth", c => c.DateTime());
            AddColumn("dbo.Employees", "JoiningDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "JoiningDate");
            DropColumn("dbo.Employees", "DateOfBirth");
            DropColumn("dbo.Customers", "Email");
        }
    }
}
