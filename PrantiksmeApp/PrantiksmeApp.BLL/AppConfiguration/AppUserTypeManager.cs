using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrantiksmeApp.BLL.Base;
using PrantiksmeApp.BLL.Contracts;
using PrantiksmeApp.Models.EntityModels;
using PrantiksmeApp.Repository.Contracts;
using PrantiksmeApp.Repository.Contracts.AppConfiguration;
using PrantiksmeApp.Repository.Contracts.Base;

namespace PrantiksmeApp.BLL
{
    public class AppUserTypeManager:Manager<AppUserType>,IAppUserTypeManager
    {
        protected IAppUserTypeRepository _repository;
        public AppUserTypeManager(IAppUserTypeRepository repository) : base(repository)
        {
            this._repository = repository;
        }
    }
}
