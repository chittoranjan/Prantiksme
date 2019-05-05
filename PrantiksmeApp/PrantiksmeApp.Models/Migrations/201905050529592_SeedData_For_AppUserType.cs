namespace PrantiksmeApp.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedData_For_AppUserType : DbMigration
    {
        public override void Up()
        {
            Sql(@"SET IDENTITY_INSERT [dbo].[AppUserTypes] ON 

                INSERT [dbo].[AppUserTypes] ([Id], [Name]) VALUES 
                (1, N'SystemManager'),
                (2, N'Proprietor'),
                (3, N'Employee')
                
                SET IDENTITY_INSERT [dbo].[AppUserTypes] OFF");
        }

        public override void Down()
        {
            Sql(@"DELETE FROM [dbo].[AppUserTypes];
                   DBCC CHECKIDENT ('AppUserTypes', RESEED, 0)");
        }
    }
}
