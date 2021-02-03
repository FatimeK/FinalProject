using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //Context : DB tabloları ile proje klaslarını bağlamak
    public class NorthwindContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //sqlserver kullanıcaksan ona nasıl bağlanacağımı belirtmem lazm
            //sen bu projeyi çalşnca buraya bakıyo ki ben nereye bağlanayım diye
            optionsBuilder.UseSqlServer(@"Server = (localdb)\MSSQLLocalDB;Database = Northwind;Trusted_Connection = true"); 
        }

        //veritabanındaki bilgiler benim hangi entitiylerimle eşleşicek belirtmem lazm.bağlantı kurduk yani
        public DbSet<Product>  Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }

        //artık kodlarımızı Ef claslarımızda kullanalım kodlar yazalm
    }
}
