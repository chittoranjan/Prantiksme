using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrantiksmeApp.Models.EntityModels;
using PrantiksmeApp.Repository.Base;
using PrantiksmeApp.Repository.Contracts;

namespace PrantiksmeApp.Repository
{
    public class SalesStoreRepository:Repository<SalesStore>,ISalesStoreRepository

    {
        public SalesStoreRepository(DbContext db) : base(db)
        {
        }
    }
}
