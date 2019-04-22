using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Microsoft.AspNet.Identity.EntityFramework;
using PrantiksmeApp.Models.IdentityModels;

namespace PrantiksmeApp.Models.Context
{
    public class PrantiksmeDbContext:IdentityDbContext
    {
        public PrantiksmeDbContext() : base("PrantiksmeDbContext")
        {
            Configuration.LazyLoadingEnabled = true;
            Database.CommandTimeout = 1080;
            ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = 1080;

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
        }
    }
}