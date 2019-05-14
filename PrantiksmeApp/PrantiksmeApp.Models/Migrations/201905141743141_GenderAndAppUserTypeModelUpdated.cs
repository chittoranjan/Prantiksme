namespace PrantiksmeApp.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GenderAndAppUserTypeModelUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AppUserTypes", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Genders", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Genders", "IsDeleted");
            DropColumn("dbo.AppUserTypes", "IsDeleted");
        }
    }
}
