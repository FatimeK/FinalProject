
using Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T : class,IEntity,new() //burda filtreledim ki adam başka nesne veya klas veremesin implemente ettiğim yerlerde
    {
        //Generic Costraint(generic kısıtlama)
        //class : referans tip
        //IEntity : IEntity veya IEntity implemente edebilen bi nesne olabilir
        //new() : new() lenebilir olmalı 
        List<T> GetAll(Expression<Func<T, bool>> filter = null); //filtrelem
        T Get(Expression<Func<T, bool>> filter = null); //burdaki null un anlamı filtre vermeyedebilirsin demek
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        //List<T> GetAllByCategory(int categoryId); 11. satırdaki expresssionşla filtrelemeden dolayı bu koda asla ihtiyacım yok!!
    }
}
