using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using PrantiksmeApp.Models.EntityModels;
using PrantiksmeApp.Models.EntityModels.ProductModels;
using PrantiksmeApp.Models.EntityModels.PurchaseModels;
using PrantiksmeApp.Models.EntityModels.SalesModels;
using PrantiksmeApp.Models.IdentityModels;
using PrantiksmeApp.Models.Migrations;

namespace PrantiksmeApp.Models.Context
{
    public class PrantiksmeDbContext : IdentityDbContext<ApplicationUser, CustomRole, long, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {


        #region DbContext Releted
        public PrantiksmeDbContext() : base("PrantiksmeDbContext")
        {
            Configuration.LazyLoadingEnabled = true;
            Database.CommandTimeout = 1080;
            ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = 1080;

        }
        public static PrantiksmeDbContext Create()
        {
            return new PrantiksmeDbContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<ApplicationUser>().ToTable("AppUsers");
            modelBuilder.Entity<CustomRole>().ToTable("AppRoles");
            modelBuilder.Entity<CustomUserRole>().ToTable("AppUserRoles");
            modelBuilder.Entity<CustomUserLogin>().HasKey(c => new { c.UserId, c.ProviderKey, c.LoginProvider }).ToTable("AppUserLogins");
            modelBuilder.Entity<CustomUserClaim>().ToTable("AppUserClaims");

            modelBuilder.Entity<ApplicationUser>().HasKey(c => c.Id);
            modelBuilder.Entity<ApplicationUser>().Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<CustomRole>().HasKey(c => c.Id);
            modelBuilder.Entity<CustomRole>().Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

        }


        #endregion

        #region EntityModels Releted

        public DbSet<SalesStore> SalesStores { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Customer> Customers { get; set; }

        
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductSubCategory> ProductSubCategories { get; set; }
        public DbSet<ProductItem> ProductItems { get; set; }
        
        
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PurchaseDetails> PurchaseDetailses { get; set; }
        public DbSet<StockSummary> StockSummaries { get; set; }

        public DbSet<Sales> Saleses { get; set; }
        public DbSet<SalesDetails> SalesDetailses { get; set; }
        public DbSet<SalesSummary> SalesSummaries { get; set; }


        #endregion

        #region Reports Releted



        #endregion
    }

}