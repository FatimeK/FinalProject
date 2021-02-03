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

            ProductManager productManager = new ProductManager(new EfProductDal());//bana hangi veri yöntemiyle çalışcamı söylemen lazım
            foreach (var prouct in productManager.GetByUnitPrice(40,100))
            {
                Console.WriteLine(prouct.ProductName);

            }
            
        }
    }
}
