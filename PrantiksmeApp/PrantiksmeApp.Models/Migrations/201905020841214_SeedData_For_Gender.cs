namespace PrantiksmeApp.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedData_For_Gender : DbMigration
    {
        public override void Up()
        {
            Sql(@"SET IDENTITY_INSERT [dbo].[Genders] ON 

                INSERT [dbo].[Genders] ([Id], [Name]) VALUES 
                (1, N'Male'),
                (2, N'Female'),
                (3, N'Others')
                
                SET IDENTITY_INSERT [dbo].[Genders] OFF");
        }
        
        public override void Down()
        {
            Sql(@"DELETE FROM [dbo].[Genders];
                   DBCC CHECKIDENT ('Genders', RESEED, 0)");
        }
    }
}
