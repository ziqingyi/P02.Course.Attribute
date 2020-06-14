using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P07.Course.Encrypt
{
    class Program
    {
        static void Main(string[] args)
        {
            #region MD5
            {
                ////same content with same MD5 value
                //Console.WriteLine(MD5Encrypt.Encrypt("1"));
                //Console.WriteLine(MD5Encrypt.Encrypt("1"));// same to the first one

                //Console.WriteLine(MD5Encrypt.Encrypt("123456Tom"));

                ////compare same file with different name
                //string filepathWrong = @"‪C:\IOSerialize\user.xml";//wrong format, not support,C is different
                //string filepathWrongFixed = @"C:\IOSerialize\user.xml";// fixed with different C. 
                //byte[] wrong = Encoding.UTF8.GetBytes(filepathWrong);
                //byte[] correct = Encoding.UTF8.GetBytes(filepathWrongFixed); 
                
                //string filepath = @"C:\IOSerialize\user.xml";//correct format
                //string filepath2 = @"C:\IOSerialize\user2.xml";
                //string md5FileAbstract1 = MD5Encrypt.AbstractFile(filepath);
                //string md5FileAbstract2 = MD5Encrypt.AbstractFile(filepath2);

            }
            #endregion

            #region DES, symmetric, the key of encrypt and decrypt is same. faster than asymmetric way. 

            {
                string desEn = DesEncrypt.Encrypt("1");
                string desDe = DesEncrypt.Decrypt(desEn);

                string desEn2 = DesEncrypt.Encrypt("2");
                string desDe2 = DesEncrypt.Decrypt(desEn2);
            }
            #endregion


        }
    }
}
