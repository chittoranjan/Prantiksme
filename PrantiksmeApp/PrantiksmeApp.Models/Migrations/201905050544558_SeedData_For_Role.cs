namespace PrantiksmeApp.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedData_For_Role : DbMigration
    {
        public override void Up()
        {
            Sql(@"SET IDENTITY_INSERT [dbo].[AppRoles] ON 

               

                 INSERT [dbo].[AppRoles] ([Id], [Name]) VALUES (1, N'SystemAdmin')
                 INSERT [dbo].[AppRoles] ([Id], [Name]) VALUES (2, N'SystemManager')
                 INSERT [dbo].[AppRoles] ([Id], [Name]) VALUES (3, N'SystemAccountant')
                 INSERT [dbo].[AppRoles] ([Id], [Name]) VALUES (4, N'BusinessAdmin')
                 INSERT [dbo].[AppRoles] ([Id], [Name]) VALUES (5, N'BusinessManager')
                 INSERT [dbo].[AppRoles] ([Id], [Name]) VALUES (6, N'BusinessAccountant')
                 INSERT [dbo].[AppRoles] ([Id], [Name]) VALUES (7, N'Employee')
                
                SET IDENTITY_INSERT [dbo].[AppRoles] OFF");
        }

        public override void Down()
        {
            Sql(@"DELETE FROM [dbo].[AppRoles];
                   DBCC CHECKIDENT ('AppRoles', RESEED, 0)");
        }
    }
}
