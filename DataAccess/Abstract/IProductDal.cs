using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IProductDal:IEntityRepository<Product>
    {
        //interface kendisi default internaldir ama fonksiyonları default olarak public

        List<ProductDetailDto> GetProductDetails();
    }
}
