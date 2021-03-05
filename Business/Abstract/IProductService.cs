using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    //buraya iş katmanında kullanacağımız operasyonları yazacağız
    public interface IProductService
    {
        //business içinde entities ve data accesden referans aldık

        IDataResult<List<Product>> GetAll();
        IDataResult<List<Product>> GetAllByCategoryId(int id);
        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);
        IDataResult<List<ProductDetailDto>> GetProductDetails();

        IDataResult<Product> GetById(int productId);
        IResult Add(Product product);
        IResult Update(Product product);

        IResult AddTransactionalTest(Product product);
    }
}
