using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Deneme1
{
    public class Crypto
    {
        public Crypto()
        {

        }
        public static string MD5Sifrele(string plainText)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider(); // Md5 crypto class

            byte[] dizi = Encoding.UTF8.GetBytes(plainText);   //Parametre olarak gelen veriyi byte dizisine dönüştürdük.

            dizi = md5.ComputeHash(dizi); //hash of array 

            StringBuilder sb = new StringBuilder(); // Hashlenmiş verileri depolamak için

            foreach (byte ba in dizi) //Her byte'i dizi içerisinden alarak string türüne dönüştürdük.
            {
                sb.Append(ba.ToString("x2").ToLower());
            }
            return sb.ToString();
        }
    }
}
