using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICustomerDal:IEntityRepository<Customer>
    {
        //artık bu interface bizim için hazır çünkü ıentityrespriratory i generic yaptık ki artık yeni gelen tüm entitylerde rahatça kullanabiliym

    }
}
