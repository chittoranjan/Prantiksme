namespace PrantiksmeApp.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sales_SalesDetails_SalesSummary_Model_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Description = c.String(),
                        SalesDate = c.DateTime(nullable: false),
                        SalesStoreId = c.Long(nullable: false),
                        UniversalCode = c.String(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        CreatedBy = c.Long(nullable: false),
                        ModifiedOn = c.DateTime(),
                        ModifiedBy = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SalesStores", t => t.SalesStoreId)
                .Index(t => t.SalesStoreId);
            
            CreateTable(
                "dbo.SalesDetails",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        SalesId = c.Long(nullable: false),
                        ProductCategoryId = c.Long(nullable: false),
                        ProductSubCategoryId = c.Long(),
                        ProductItemId = c.Long(nullable: false),
                        Qty = c.Double(nullable: false),
                        UnitPrice = c.Double(nullable: false),
                        UniversalCode = c.String(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        CreatedBy = c.Long(nullable: false),
                        ModifiedOn = c.DateTime(),
                        ModifiedBy = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductCategories", t => t.ProductCategoryId)
                .ForeignKey("dbo.ProductItems", t => t.ProductItemId)
                .ForeignKey("dbo.ProductSubCategories", t => t.ProductSubCategoryId)
                .ForeignKey("dbo.Sales", t => t.SalesId)
                .Index(t => t.SalesId)
                .Index(t => t.ProductCategoryId)
                .Index(t => t.ProductSubCategoryId)
                .Index(t => t.ProductItemId);
            
            CreateTable(
                "dbo.SalesSummaries",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ProductCategoryId = c.Long(nullable: false),
                        ProductSubCategoryId = c.Long(),
                        ProductItemId = c.Long(nullable: false),
                        SalesStoreId = c.Long(nullable: false),
                        Qty = c.Double(nullable: false),
                        UnitPrice = c.Double(nullable: false),
                        TotalPrice = c.Double(nullable: false),
                        UniversalCode = c.String(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        CreatedBy = c.Long(nullable: false),
                        ModifiedOn = c.DateTime(),
                        ModifiedBy = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductCategories", t => t.ProductCategoryId)
                .ForeignKey("dbo.ProductItems", t => t.ProductItemId)
                .ForeignKey("dbo.ProductSubCategories", t => t.ProductSubCategoryId)
                .ForeignKey("dbo.SalesStores", t => t.SalesStoreId)
                .Index(t => t.ProductCategoryId)
                .Index(t => t.ProductSubCategoryId)
                .Index(t => t.ProductItemId)
                .Index(t => t.SalesStoreId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SalesSummaries", "SalesStoreId", "dbo.SalesStores");
            DropForeignKey("dbo.SalesSummaries", "ProductSubCategoryId", "dbo.ProductSubCategories");
            DropForeignKey("dbo.SalesSummaries", "ProductItemId", "dbo.ProductItems");
            DropForeignKey("dbo.SalesSummaries", "ProductCategoryId", "dbo.ProductCategories");
            DropForeignKey("dbo.SalesDetails", "SalesId", "dbo.Sales");
            DropForeignKey("dbo.SalesDetails", "ProductSubCategoryId", "dbo.ProductSubCategories");
            DropForeignKey("dbo.SalesDetails", "ProductItemId", "dbo.ProductItems");
            DropForeignKey("dbo.SalesDetails", "ProductCategoryId", "dbo.ProductCategories");
            DropForeignKey("dbo.Sales", "SalesStoreId", "dbo.SalesStores");
            DropIndex("dbo.SalesSummaries", new[] { "SalesStoreId" });
            DropIndex("dbo.SalesSummaries", new[] { "ProductItemId" });
            DropIndex("dbo.SalesSummaries", new[] { "ProductSubCategoryId" });
            DropIndex("dbo.SalesSummaries", new[] { "ProductCategoryId" });
            DropIndex("dbo.SalesDetails", new[] { "ProductItemId" });
            DropIndex("dbo.SalesDetails", new[] { "ProductSubCategoryId" });
            DropIndex("dbo.SalesDetails", new[] { "ProductCategoryId" });
            DropIndex("dbo.SalesDetails", new[] { "SalesId" });
            DropIndex("dbo.Sales", new[] { "SalesStoreId" });
            DropTable("dbo.SalesSummaries");
            DropTable("dbo.SalesDetails");
            DropTable("dbo.Sales");
        }
    }
}
