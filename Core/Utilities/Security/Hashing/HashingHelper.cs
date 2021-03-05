using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        //bi password verip dışarıya out değerlerini çıkarcak
        public static void CreatePasswordHash(string password,out byte[] passwordHash,out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;//İLGİLİ KULLANDIĞIM  ALGORİTMANIN KULLANDIĞI KEY DEĞERİ.HER USER İÇİN SPESİFİKTİR
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)); //COMPUTEHASH BİZDEN BYTE İSTER STRİNG KABUL ETMEZ

            }
        }


        //sonradan sisteme girilen passwordün veri tabanında hashlanmış parola ile eşleşip eşleşmediğini kontrol eden yer
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if(computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }

                }
                return true;
            }
        }
    }
}
