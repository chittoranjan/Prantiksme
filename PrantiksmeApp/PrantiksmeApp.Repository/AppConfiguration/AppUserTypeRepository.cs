using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrantiksmeApp.Models.EntityModels;
using PrantiksmeApp.Repository.Base;
using PrantiksmeApp.Repository.Contracts;
using PrantiksmeApp.Repository.Contracts.AppConfiguration;

namespace PrantiksmeApp.Repository
{
    public class AppUserTypeRepository:Repository<AppUserType>,IAppUserTypeRepository
    {
        public AppUserTypeRepository(DbContext db) : base(db)
        {
        }
    }
}
