using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P06.Course.IOSerialize.IO;
using P06.Course.IOSerialize.Serialize;

namespace P06.Course.IOSerialize
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                //Console.WriteLine("******************IO Show, file, directory, recursion*************");
                //MyIO.ShowDirectory();
                //MyIO.ShowFile();
                //MyIO.showDrive();
                //MyIO.showPath();
                //MyIO.Log("log ....s.s.s.s..s.s.s");
                //var directoryInfo = Recursion.GetAllDirectory(@"C:\IOSerialize");
            }
            {
                Console.WriteLine("****************Serialize, Soap, Xml, Json***********");
                //SerializeHelper.BinarySerialize();
                SerializeHelper.XmlSerialize();
                SerializeHelper.Json();

            }

        }
    }
}
