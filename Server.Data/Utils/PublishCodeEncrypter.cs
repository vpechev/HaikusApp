using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Server.Data.Utils
{
    public static class PublishCodeEncrypter
    {
        public static string CreateSalt()
        {
            int size = new Random().Next(128, 256);
            var rng = new RNGCryptoServiceProvider();
            var buff = new byte[size];
            rng.GetBytes(buff);
            return Convert.ToBase64String(buff);
        }

        //public static string SecurePublishCode(string input, String salt)
        //{
        //    return GenerateSHA256Hash(input + salt);
        //}

        public static string GenerateSHA256Hash(string input)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(input);
            SHA256Managed sha256hashstring = new SHA256Managed();
            byte[] hash = sha256hashstring.ComputeHash(bytes);
            return Encoding.Default.GetString(hash);
        }


    }
}


