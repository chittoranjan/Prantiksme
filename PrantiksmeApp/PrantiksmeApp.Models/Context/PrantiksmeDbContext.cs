using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using PrantiksmeApp.Models.IdentityModels;
using PrantiksmeApp.Models.Migrations;

namespace PrantiksmeApp.Models.Context
{
    public class PrantiksmeDbContext:IdentityDbContext<ApplicationUser, CustomRole, long, CustomUserLogin, CustomUserRole, CustomUserClaim>
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



        #endregion

        #region Reports Releted

        

        #endregion
    }
    
}