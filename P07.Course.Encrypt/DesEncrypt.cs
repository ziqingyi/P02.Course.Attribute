using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace P07.Course.Encrypt
{
    public class DesEncrypt
    {
        private static byte[] _rgbKey = 
            ASCIIEncoding.ASCII.GetBytes(
                Constant.DesKey.Substring(0, 8));
        private static byte[] _rgbIV = 
            ASCIIEncoding.ASCII.GetBytes(
                Constant.DesKey.Insert(0,"w").Substring(0,8));

        //DES encrypt
        public static string Encrypt(string text)
        {
            DESCryptoServiceProvider dsp = new DESCryptoServiceProvider();
            using (MemoryStream memStream = new MemoryStream())
            {
                CryptoStream crypStream = 
                    new CryptoStream(memStream, 
                        dsp.CreateEncryptor(_rgbKey,_rgbIV),
                        CryptoStreamMode.Write
                        );
                StreamWriter sWriter = new StreamWriter(crypStream);
                sWriter.Write(text);
                sWriter.Flush();
                crypStream.FlushFinalBlock();
                memStream.Flush();
                string result= Convert.ToBase64String(memStream.GetBuffer(),0,(int)memStream.Length);
                return result;
            }
        }

        //DES decrypt
        public static string Decrypt(string encryptText)
        {
            DESCryptoServiceProvider dsp = new DESCryptoServiceProvider();
            byte[] buffer = Convert.FromBase64String(encryptText);

            using (MemoryStream memStream = new MemoryStream())
            {
                CryptoStream crypStream = new CryptoStream(memStream,
                    dsp.CreateDecryptor(_rgbKey, _rgbIV),
                    CryptoStreamMode.Write);

                crypStream.Write(buffer,0,buffer.Length);

                crypStream.FlushFinalBlock();

                string result = ASCIIEncoding.UTF8.GetString(memStream.ToArray());

                return result;
            }


        }






    }
}
