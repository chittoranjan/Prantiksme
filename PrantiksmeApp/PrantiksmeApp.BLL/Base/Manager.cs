using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PrantiksmeApp.BLL.Contracts.Base;
using PrantiksmeApp.Models.Contracts;
using PrantiksmeApp.Repository.Contracts.Base;

namespace PrantiksmeApp.BLL.Base
{
    public abstract class Manager<T>: IDisposable,IManager<T> where T:class,IDeletable
    {
        private  IRepository<T> _repository;

        protected Manager(IRepository<T> repository)
        {
            _repository = repository;
        }

        
        public virtual bool Add(T entity)
        {
            return _repository.Add(entity);
        }

        public virtual bool Update(T entity)
        {
            return _repository.Update(entity);
        }

        public virtual bool Remove(IDeletable entity)
        {
            bool isDeletable = entity is IDeletable;
            if (!isDeletable)
            {
                throw new Exception("This Item is not Deletable!");
            }
            return _repository.Remove((IDeletable)entity);
        }

        public bool Remove(ICollection<IDeletable> entities)
        {
           return _repository.Remove(entities);
        }

        public ICollection<T> GetAll()
        {
            return _repository.GetAll();
        }
        public virtual ICollection<T> GetAll(bool withDeleted = false)
        {
            return _repository.GetAll(withDeleted);
        }
        public ICollection<T> Get(Expression<Func<T, bool>> query)
        {
            return _repository.Get(query);
        }

        public virtual T GetById(long id)
        {
            return _repository.GetById(id);
        }
        

        public void Dispose()
        {
            _repository?.Dispose();
        }
    }
}
