using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages //static yaptım ki newlemiyim defalarca
    {
        //Not: public değişkenler PascalCase yazılır
        public static string ProductAdded = "Ürün eklendi";
        public static string productNameInValid = "Ürün ismi geçersiz";
        internal static string MaintenanceTime = "Sistem Bakımda";
        internal static string ProductListed = "Ürünler Listelendi";
    } 
}
