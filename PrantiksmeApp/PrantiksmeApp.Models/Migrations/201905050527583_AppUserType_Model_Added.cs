namespace PrantiksmeApp.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AppUserType_Model_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppUserTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AppUserTypes");
        }
    }
}
