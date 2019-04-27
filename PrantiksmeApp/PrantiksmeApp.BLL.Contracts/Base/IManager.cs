using System;
using System.Collections.Generic;
using PrantiksmeApp.Models.Contracts;

namespace PrantiksmeApp.BLL.Contracts.Base
{
    public interface IManager<T>:IDisposable where T:class,IEntityModel
    {
        bool Add(T entity);
        bool Update(T entity);
        bool Remove(IDeletable entity);
        bool Remove(ICollection<IDeletable> entities);
        ICollection<T> GetAll(bool withDeleted = false);
        T GetById(long id);
    }
}
