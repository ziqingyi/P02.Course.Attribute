using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace P07.Course.Encrypt
{
    public class MD5Encrypt
    {
        public static string Encrypt(string source, int length = 32)
        {
            if (string.IsNullOrEmpty(source))
                return string.Empty;
            HashAlgorithm provider = CryptoConfig.CreateFromName("MD5") as HashAlgorithm;
            byte[] bytes = Encoding.UTF8.GetBytes(source);// turn string to bytes
            byte[] hashValue = provider.ComputeHash(bytes);

            StringBuilder sb = new StringBuilder();
            switch (length)
            {
                case 16:
                    for (int i = 4; i < 12; i++)
                    {
                        sb.Append(hashValue[i].ToString("x2"));
                    }
                    break;
                case 32:
                    for (int i = 0; i < 16; i++)
                    {
                        sb.Append(hashValue[i].ToString("x2"));
                    }
                    break;
                default:
                    for (int i = 0; i < hashValue.Length; i++)
                    {
                        sb.Append(hashValue[i].ToString("x2"));
                    }
                    break;
            }
            return sb.ToString();
        }

        //get file's MD5 abstract, from file name
        public static string AbstractFile(string fileName)
        {
            using (FileStream file = new FileStream(fileName, FileMode.Open))
            {
                return AbstractFile(file);
            }
        }

        //get file's MD5 abstract, from file name
        public static string AbstractFile(Stream stream)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] retVal = md5.ComputeHash(stream);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < retVal.Length; i++)
            {
                sb.Append(retVal[i].ToString("x2"));
            }
            return sb.ToString();
        }







    }
}
