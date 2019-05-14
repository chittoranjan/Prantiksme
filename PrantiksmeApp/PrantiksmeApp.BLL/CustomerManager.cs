using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrantiksmeApp.BLL.Base;
using PrantiksmeApp.BLL.Contracts;
using PrantiksmeApp.Models.EntityModels;
using PrantiksmeApp.Repository.Contracts;
using PrantiksmeApp.Repository.Contracts.Base;

namespace PrantiksmeApp.BLL
{
    public class CustomerManager:Manager<Customer>,ICustomerManager
    {
        private readonly ICustomerRepository _repository;
        public CustomerManager(ICustomerRepository repository) : base(repository)
        {
            this._repository = repository;
        }
    }
}
