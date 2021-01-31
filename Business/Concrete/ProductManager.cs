using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        //artık ıproductservisin iş kodlarını yazıyoruz
        IProductDal _iProductDal; //soyut nesne ile bağlantı kurcaz ki data kaynağı değişince patlamayalm

        public ProductManager(IProductDal iProductDal) //artık veri erişimim değişirse ctor kullandığım için patlamıycam
        {
            _iProductDal = iProductDal;
        }

        public List<Product> GetAll()
        {
            //iş kodları(ifleri falan geçtiyse(mesela yetkisi var mı gibi iflerden geçerse) napcam dataaccesse gidcem)
            //bi iş sınıfı başka sınıfları newlemez.. constructor injection yapalım o yüzden yani constructor kullanıyorum ki bura çok önemli defalarca tekrar et
            return _iProductDal.GetAll();
        }
    }
}

