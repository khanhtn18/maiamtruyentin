using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//Thư viện để dùng MD5CryptorServiceProvider
using System.Security.Cryptography;
//Thư viện cho ASCIIEncoding
using System.Text;
namespace MaiAmTruyenTin.Common
{
    public class Encryptor
    {
        public static string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            //compute hash from the bytes of text
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            //get hash result after compute it 
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                // change it to 2 hexadecimal digits
                // for each byte
                strBuilder.Append(result[i].ToString("x2"));
            }
            return strBuilder.ToString();
        }
    }
}