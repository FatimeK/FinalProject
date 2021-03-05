using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages //static yaptım ki newlemiyim defalarca
    {
        //Not: public değişkenler PascalCase yazılır
        public static string ProductAdded = "Ürün eklendi";
        public static string productNameInValid = "Ürün ismi geçersiz";
        public static string MaintenanceTime = "Sistem Bakımda";
        public static string ProductListed = "Ürünler Listelendi";
        public static string ProductCountOfCategoryError = "10dan fazla kategory eklenemez";
        public  static string ProductNameAlreadyExists = "aynı isimde ürün eklenemez";
        public  static string CategoryLimitExceded = "kategori limiti aşıldığı için yeni ürün eklenemiyor..";
        public  static String AuthorizationDenied =  "yetkiniz yok";
    } 
}
