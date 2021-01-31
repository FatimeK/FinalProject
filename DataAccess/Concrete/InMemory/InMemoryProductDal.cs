using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    //bellek üzerinde veri erişim kodlarını yazacağım yer. bunu daha sonra frameworkla yapcazz.şuan memoryde sanki bi veritabanı varmış gibi simüle ediyoruz
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        //constructor oluşturuyorm.uygulama çalştıpı anda olucak seyler
        public InMemoryProductDal()
        {
            //Oracle,sql Server ,MongoDB den geliyomuş gibi simüle ediyoruz
            _products = new List<Product>
            {
                new Product{ProductId = 1,CategoryId = 1,ProductName = "Bardak",UnityPrice = 15,UnitsInStock = 15 },
                new Product{ProductId = 2,CategoryId = 1,ProductName = "Kamera",UnityPrice = 500,UnitsInStock = 3 },
                new Product{ProductId = 3,CategoryId = 2,ProductName = "Telefon",UnityPrice = 1500,UnitsInStock = 15 },
                new Product{ProductId = 4,CategoryId = 2,ProductName = "Klavye",UnityPrice = 150,UnitsInStock = 15 },
                new Product{ProductId = 5,CategoryId = 2,ProductName = "Fare",UnityPrice = 85,UnitsInStock = 15 }

            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            // _products.Remove(product) --//böyle yazarsan eleman aslaa listeden silinmez. Neden?
            //çünkü referans numarasıyla silmen lazım listeden
            //ürünü silerken primary key ile silsek olur o zaman eşleşen id yi bulup referansını yakalıycaz

            //foreach (var p in _products)
            //{
            //    if (product.ProductId == p.ProductId)
            //    {
            //        productToDelete = p;
            //    }

            //}
            //_products.Remove(productToDelete);
            //ama ben LİNQ ile çok daha kısa şekilde yazabilirimm. lİNQ = Language Integrated Query
            Product productToDelete = null;
            productToDelete = _products.SingleOrDefault(p=>p.ProductId == product.ProductId); //her p için bak bakalım p'nin product id'si benm parametre olarak yolladığımınkine eşit mi
            //foreachin kısa halini lambda ile yazdık yani
            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            //onlara bi liste vermek zorundayım o yüzden return kullanırız
            return _products;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
            //Mesela bu da bir LINQ(Language Integrated Query) kullanım örneği
        }

        public void Update(Product product)
        {
            //Gönderdiğim ürün id sine sahip olan listedeki ürünün ürünü bul demek.referansımı aldım yani
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitsInStock = product.UnitsInStock;
            productToUpdate.UnityPrice = product.UnityPrice;
            //NOT: biz şuan mutfağını öğreniyoruz.aslında bunu frameworklar bizim için paşa paşa yapacak :)

        }
        
    }
}
