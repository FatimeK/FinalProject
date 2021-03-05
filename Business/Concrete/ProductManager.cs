using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;

using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        //artık ıproductservisin iş kodlarını yazıyoruz
        IProductDal _iProductDal; //soyut nesne ile bağlantı kurcaz ki data kaynağı değişince patlamayalm
        ICategoryService _categoryService;
        public ProductManager(IProductDal iProductDal,ICategoryService categoryService) //artık veri erişimim değişirse ctor kullandığım için patlamıycam
        {
            _iProductDal = iProductDal;
            _categoryService = categoryService;
            
        }

        [CacheRemoveAspect("IProductService.Get")]
        [SecuredOperation("product.add")]
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {


            //artık validate kodlarımı buraya yazmıycam o zaten bana core dan gelicek
            //buraya sadece iş kodlarımı yazcam
            //bi kategoride max 10 ürün olsun(iş kuralıdır validatorle yazılmaz)

            IResult result = BusinessRules.Run(CheckIfProductCountOfCategoryCorrect(product.CategoryId),
                CheckIfProductNameExists(product.ProductName),CheckIfCategoryLimitExceded());

            if (result != null)
            {
                return result;
            }
            _iProductDal.Add(product);

            return new SuccessResult(Messages.ProductAdded);

            
            

        }

        [CacheAspect] //key,value
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

        [CacheRemoveAspect("IProductService.Get")]
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Update(Product product)
        {
            
            throw new NotImplementedException();
        }

        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            //Select count(*) from products where categoryId = 1 adlı sorguyu arla planda çalıştırır.
            var result = _iProductDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();


        }

        //aynı isimde ürün eklenemez
        private IResult CheckIfProductNameExists(string productName)
        {
            var result = _iProductDal.GetAll(p => p.ProductName == productName).Any();
            if(result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }

            return new SuccessResult();
        }

        private IResult CheckIfCategoryLimitExceded()
        {
            var result = _categoryService.GetAll();
            if(result.Data.Count > 15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }
            return new SuccessResult();
        }

        //[TransactionScopeAspect]
        public IResult AddTransactionalTest(Product product)
        {
            throw new NotImplementedException();
        }
    }
}

