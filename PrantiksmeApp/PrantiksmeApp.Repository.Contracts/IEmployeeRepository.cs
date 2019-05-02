using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrantiksmeApp.Models.EntityModels;
using PrantiksmeApp.Repository.Contracts.Base;

namespace PrantiksmeApp.Repository.Contracts
{
    public interface IEmployeeRepository:IRepository<Employee>
    {
    }
}
