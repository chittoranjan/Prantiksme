using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using PrantiksmeApp.Models.Contracts;

namespace PrantiksmeApp.Repository.Contracts.Base
{
    public interface IRepository<T> : IDisposable where T : class, IModel
    {
        bool Add(T entity);
        bool Update(T entity);
        bool Remove(IDeletable entity);
        bool Remove(ICollection<IDeletable> entities);
        ICollection<T> GetAll(bool withDeleted = false);
        ICollection<T> Get(Expression<Func<T, bool>> query);
        T GetById(long id);

    }
}
