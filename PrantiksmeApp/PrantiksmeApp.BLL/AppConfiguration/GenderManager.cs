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
    public class GenderManager:Manager<Gender>,IGenderManager
    {
        protected readonly IGenderRepository _repository;

        public GenderManager(IGenderRepository repository) : base(repository)
        {
            this._repository = repository;
        }
    }
}
