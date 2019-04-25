using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using PrantiksmeApp.Models.Contracts;
using PrantiksmeApp.Repository.Contracts.Base;

namespace PrantiksmeApp.Repository.Base
{
    public abstract class Repository<T>:IRepository<T>  where T :class,IEntityModel
    {
        protected DbContext db;

        public Repository(DbContext db)
        {
            this.db = db;
        }
       

        public virtual bool Add(T entity)
        {
            db.Set<T>().Add(entity);
            return db.SaveChanges() > 0;
        }

        public virtual bool Update(T entity)
        {
            db.Set<T>().Attach(entity);
            db.Entry(entity).State = EntityState.Modified;
            return db.SaveChanges() > 0;
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

        public virtual ICollection<T> GetAll(bool withDeleted = false)
        {
            //Expression<Func<IDeletable, bool>> query = c => true;
            //bool isDeletableObj = typeof(IDeletable).IsAssignableFrom(typeof(T));
            //if (isDeletableObj)
            //{
            //    query = c => c.IsDeleted == false || c.IsDeleted == withDeleted;

            //}
            return db.Set<T>().ToList();
        }

        public virtual ICollection<T> Get(Expression<Func<T, bool>> query)
        {
            return db.Set<T>().Where(query).ToList();
        }
      

        public virtual T GetById(int id)
        {
            return db.Set<T>().Find(id);
        }


        public virtual void Dispose()
        {
            db?.Dispose();
        }
    }


    public abstract class DeleteableRepository<T> : Repository<T> where T : class, IDeletable,IEntityModel
    {
        public override ICollection<T> GetAll(bool withDeleted = false)
        {
            return db.Set<T>().Where(c => c.IsDeleted == false || c.IsDeleted == withDeleted).ToList();
        }

        protected DeleteableRepository(DbContext db) : base(db)
        {
        }
    }
}
