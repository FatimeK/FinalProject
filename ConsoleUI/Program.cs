using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //DTO - Data Transformation Object
            //ProductTest();
            //CategoryTest();

        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

            
            //foreach (var category in categoryManager.GetAll())
            //{
            //    Console.WriteLine(category.CategoryName);
            //}
        }

        //private static void ProductTest()
        //{
        //    ProductManager productManager = new ProductManager(new EfProductDal());//bana hangi veri yöntemiyle çalışcamı söylemen lazım
        //    var result = productManager.GetAll();
        //    if (result.Success == true)
        //    {
        //        foreach (var prouct in result.Data)
        //        {
        //            //Console.WriteLine(prouct.ProductName + "/" + prouct.CategoryName);

        //        }

        //    }
        //    else
        //    {
        //        Console.WriteLine(result.Message);
        //    }
            


            
        //}

    }
}
