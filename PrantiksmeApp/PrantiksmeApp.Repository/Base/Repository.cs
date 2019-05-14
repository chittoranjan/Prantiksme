using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using PrantiksmeApp.Models.Contracts;
using PrantiksmeApp.Repository.Contracts.Base;

namespace PrantiksmeApp.Repository.Base
{
    public abstract class Repository<T> : IDisposable, IRepository<T> where T : class, IDeletable
    {
        protected DbContext Db;

        protected Repository(DbContext db)
        {
            this.Db = db;
        }


        public virtual bool Add(T entity)
        {
            Db.Set<T>().Add(entity);
            return Db.SaveChanges() > 0;
        }

        public virtual bool Update(T entity)
        {
            Db.Set<T>().Attach(entity);
            Db.Entry(entity).State = EntityState.Modified;
            return Db.SaveChanges() > 0;
        }

        public virtual bool Remove(IDeletable entity)
        {
            entity.Delete();
            return Update((T)entity);
        }

        public virtual bool Remove(ICollection<IDeletable> entities)
        {
            int removeCount = 0;
            foreach (var entity in entities)
            {
                bool isRemoved = Remove(entity);
                if (isRemoved)
                {
                    removeCount++;
                }
            }

            return entities.Count == removeCount;

        }

        public ICollection<T> GetAll()
        {
            return Db.Set<T>().ToList();
        }

        public virtual ICollection<T> GetAll(bool withDeleted = false)
        {

            return Db.Set<T>().Where(c => c.IsDeleted == false || c.IsDeleted == withDeleted).ToList();
        }

        public virtual ICollection<T> Get(Expression<Func<T, bool>> query)
        {
            return Db.Set<T>().Where(query).ToList();
        }


        public virtual T GetById(long id)
        {
            return Db.Set<T>().Find(id);
        }


        public virtual void Dispose()
        {
            Db?.Dispose();
        }
    }


    //DeletableRepository

    //public abstract class DeletableRepository<T> : Repository<T> where T : class, IDeletable,IModel
    //{
    //    protected DeletableRepository(DbContext db) : base(db)
    //    {
    //    }
    //    public override ICollection<T> GetAll(bool withDeleted = false)
    //    {
    //        return Db.Set<T>().Where(c => c.IsDeleted == false || c.IsDeleted == withDeleted).ToList();
    //    }
    //}
}
