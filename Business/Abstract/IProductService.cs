using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    //buraya iş katmanında kullanacağımız operasyonları yazacağız
    public interface IProductService
    {
        //business içinde entities ve data accesden referans aldık

        List<Product> GetAll(); 
    }
}
