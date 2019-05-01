namespace PrantiksmeApp.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Customer_Purchase_PurchaseDetails_StockSummary_Model_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        ContactNo = c.String(),
                        Address = c.String(),
                        SalesStoreId = c.Long(nullable: false),
                        EmployeeId = c.Long(nullable: false),
                        UniversalCode = c.String(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        CreatedBy = c.Long(nullable: false),
                        ModifiedOn = c.DateTime(),
                        ModifiedBy = c.Long(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .ForeignKey("dbo.SalesStores", t => t.SalesStoreId)
                .Index(t => t.SalesStoreId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.PurchaseDetails",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        PurchaseId = c.Long(nullable: false),
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
                .ForeignKey("dbo.Purchases", t => t.PurchaseId)
                .Index(t => t.PurchaseId)
                .Index(t => t.ProductCategoryId)
                .Index(t => t.ProductSubCategoryId)
                .Index(t => t.ProductItemId);
            
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Description = c.String(),
                        PurchaseDate = c.DateTime(nullable: false),
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
                "dbo.StockSummaries",
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
            DropForeignKey("dbo.StockSummaries", "SalesStoreId", "dbo.SalesStores");
            DropForeignKey("dbo.StockSummaries", "ProductSubCategoryId", "dbo.ProductSubCategories");
            DropForeignKey("dbo.StockSummaries", "ProductItemId", "dbo.ProductItems");
            DropForeignKey("dbo.StockSummaries", "ProductCategoryId", "dbo.ProductCategories");
            DropForeignKey("dbo.PurchaseDetails", "PurchaseId", "dbo.Purchases");
            DropForeignKey("dbo.Purchases", "SalesStoreId", "dbo.SalesStores");
            DropForeignKey("dbo.PurchaseDetails", "ProductSubCategoryId", "dbo.ProductSubCategories");
            DropForeignKey("dbo.PurchaseDetails", "ProductItemId", "dbo.ProductItems");
            DropForeignKey("dbo.PurchaseDetails", "ProductCategoryId", "dbo.ProductCategories");
            DropForeignKey("dbo.Customers", "SalesStoreId", "dbo.SalesStores");
            DropForeignKey("dbo.Customers", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.StockSummaries", new[] { "SalesStoreId" });
            DropIndex("dbo.StockSummaries", new[] { "ProductItemId" });
            DropIndex("dbo.StockSummaries", new[] { "ProductSubCategoryId" });
            DropIndex("dbo.StockSummaries", new[] { "ProductCategoryId" });
            DropIndex("dbo.Purchases", new[] { "SalesStoreId" });
            DropIndex("dbo.PurchaseDetails", new[] { "ProductItemId" });
            DropIndex("dbo.PurchaseDetails", new[] { "ProductSubCategoryId" });
            DropIndex("dbo.PurchaseDetails", new[] { "ProductCategoryId" });
            DropIndex("dbo.PurchaseDetails", new[] { "PurchaseId" });
            DropIndex("dbo.Customers", new[] { "EmployeeId" });
            DropIndex("dbo.Customers", new[] { "SalesStoreId" });
            DropTable("dbo.StockSummaries");
            DropTable("dbo.Purchases");
            DropTable("dbo.PurchaseDetails");
            DropTable("dbo.Customers");
        }
    }
}
