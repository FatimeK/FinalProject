using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
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

        public IResult Add(Product product)
        {
            //business codes
            if(product.ProductName.Length < 2)
            {
                //magic string
                return new ErrorResult(Messages.productNameInValid);
            }
            _iProductDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);//bunu yapabilmemin yöntemi bi constructor eklemektir

        }

        public IDataResult<List<Product>> GetAll()
        {
            if(DateTime.Now.Hour == 1)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            //iş kodları(ifleri falan geçtiyse(mesela yetkisi var mı gibi iflerden geçerse) napcam dataaccesse gidcem)
            //bi iş sınıfı başka sınıfları newlemez.. constructor injection yapalım o yüzden yani constructor kullanıyorum ki bura çok önemli defalarca tekrar et
            return new SuccessDataResult<List<Product>>(_iProductDal.GetAll(), Messages.ProductListed); ;
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {

            return new SuccessDataResult<List<Product>>(_iProductDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_iProductDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_iProductDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_iProductDal.GetProductDetails());
        }

        
    }
}

