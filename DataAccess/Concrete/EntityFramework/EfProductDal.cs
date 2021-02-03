using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //NuGet
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            //bu using IDispossable impementation of C# (usin bittiği an garbage collector gelir çöpe hurraa
            using (NorthwindContext context = new NorthwindContext()) // böylece daha performanslı bi ürün
            {
                var addedEntity = context.Entry(entity); //referansı yakalama
                addedEntity.State = EntityState.Added; // o aslında eklenecek bi nesne
                context.SaveChanges(); //ve ekle
            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext()) // böylece daha performanslı bi ürün
            {
                var deletedEntity = context.Entry(entity); //referansı yakalama
                deletedEntity.State = EntityState.Deleted; // o aslında silinecek bi nesne demek
                context.SaveChanges(); //ve sil
            }

        }

        public Product Get(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);

            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                //turnery operatörünün syntaxı
                return filter == null ? context.Set<Product>().ToList() : context.Set<Product>().Where(filter).ToList();
            }
        }

        

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext()) // böylece daha performanslı bi ürün
            {
                var updatedEntity = context.Entry(entity); //referansı yakalama
                updatedEntity.State = EntityState.Modified; // o aslında silinecek bi nesne demek
                context.SaveChanges(); //ve sil
            }
        }
    }
}
