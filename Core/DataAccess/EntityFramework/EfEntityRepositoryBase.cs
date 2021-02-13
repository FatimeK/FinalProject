using Core.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity>
        where TEntity: class,IEntity ,new() //limitledik
        where TContext: DbContext ,new()
    {
        public void Add(TEntity entity)
        {
            //bu using IDispossable impementation of C# (usin bittiği an garbage collector gelir çöpe hurraa
            using (TContext context = new TContext()) // böylece daha performanslı bi ürün
            {
                var addedEntity = context.Entry(entity); //referansı yakalama
                addedEntity.State = EntityState.Added; // o aslında eklenecek bi nesne
                context.SaveChanges(); //ve ekle
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext()) // böylece daha performanslı bi ürün
            {
                var deletedEntity = context.Entry(entity); //referansı yakalama
                deletedEntity.State = EntityState.Deleted; // o aslında silinecek bi nesne demek
                context.SaveChanges(); //ve sil
            }

        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);

            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                //turnery operatörünün syntaxı
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }
        }



        public void Update(TEntity entity)
        {
            using (TContext context = new TContext()) // böylece daha performanslı bi ürün
            {
                var updatedEntity = context.Entry(entity); //referansı yakalama
                updatedEntity.State = EntityState.Modified; // o aslında silinecek bi nesne demek
                context.SaveChanges(); //ve sil
            }
        }
    }
}
