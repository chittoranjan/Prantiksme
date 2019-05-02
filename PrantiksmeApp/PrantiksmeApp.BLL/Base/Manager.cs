using System;
using System.Collections.Generic;
using PrantiksmeApp.BLL.Contracts.Base;
using PrantiksmeApp.Models.Contracts;
using PrantiksmeApp.Repository.Contracts.Base;

namespace PrantiksmeApp.BLL.Base
{
    public abstract class Manager<T>:IManager<T> where T:class,IModel
    {
        protected IRepository<T> _repository;

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
            bool isDeleteable = entity is IDeletable;
            if (!isDeleteable)
            {
                throw new Exception("This Item is not Deleteable!");
            }
            return _repository.Remove((IDeletable)entity);
        }

        public bool Remove(ICollection<IDeletable> entities)
        {
           return _repository.Remove(entities);
        }

        public virtual T GetById(long id)
        {
            return _repository.GetById(id);
        }

        public virtual ICollection<T> GetAll(bool withDeleted=false)
        {
            return _repository.GetAll(withDeleted);
        }

        public void Dispose()
        {
            _repository?.Dispose();
        }
    }
}
