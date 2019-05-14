using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PrantiksmeApp.Models.Contracts;

namespace PrantiksmeApp.BLL.Contracts.Base
{
    public interface IManager<T>:IDisposable where T:class,IDeletable
    {
        bool Add(T entity);
        bool Update(T entity);
        bool Remove(IDeletable entity);
        bool Remove(ICollection<IDeletable> entities);
        ICollection<T> GetAll();
        ICollection<T> GetAll(bool withDeleted = false);
        ICollection<T> Get(Expression<Func<T, bool>> query);
        T GetById(long id);
    }
}
