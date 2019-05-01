namespace PrantiksmeApp.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductCategory_ProductSubCategory_ProductItem_Model_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        UniversalCode = c.String(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        CreatedBy = c.Long(nullable: false),
                        ModifiedOn = c.DateTime(),
                        ModifiedBy = c.Long(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductItems",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        UniversalCode = c.String(nullable: false),
                        ProductCategoryId = c.Long(nullable: false),
                        ProductSubCategoryId = c.Long(),
                        CreatedOn = c.DateTime(nullable: false),
                        CreatedBy = c.Long(nullable: false),
                        ModifiedOn = c.DateTime(),
                        ModifiedBy = c.Long(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductCategories", t => t.ProductCategoryId)
                .ForeignKey("dbo.ProductSubCategories", t => t.ProductSubCategoryId)
                .Index(t => t.ProductCategoryId)
                .Index(t => t.ProductSubCategoryId);
            
            CreateTable(
                "dbo.ProductSubCategories",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        UniversalCode = c.String(nullable: false),
                        ProductCategoryId = c.Long(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        CreatedBy = c.Long(nullable: false),
                        ModifiedOn = c.DateTime(),
                        ModifiedBy = c.Long(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductCategories", t => t.ProductCategoryId)
                .Index(t => t.ProductCategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductItems", "ProductSubCategoryId", "dbo.ProductSubCategories");
            DropForeignKey("dbo.ProductSubCategories", "ProductCategoryId", "dbo.ProductCategories");
            DropForeignKey("dbo.ProductItems", "ProductCategoryId", "dbo.ProductCategories");
            DropIndex("dbo.ProductSubCategories", new[] { "ProductCategoryId" });
            DropIndex("dbo.ProductItems", new[] { "ProductSubCategoryId" });
            DropIndex("dbo.ProductItems", new[] { "ProductCategoryId" });
            DropTable("dbo.ProductSubCategories");
            DropTable("dbo.ProductItems");
            DropTable("dbo.ProductCategories");
        }
    }
}
