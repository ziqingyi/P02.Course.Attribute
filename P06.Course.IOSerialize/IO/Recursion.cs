using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace P06.Course.IOSerialize.IO
{
    public class Recursion
    {
        public static List<DirectoryInfo> GetAllDirectory(string rootPath)
        {
            if (!Directory.Exists(rootPath))
            {
                return new List<DirectoryInfo>();
            }
            List<DirectoryInfo> directoryList= new List<DirectoryInfo>();//container
            DirectoryInfo directory = new DirectoryInfo(rootPath);//root folder
            directoryList.Add(directory);

            return GetChild(directoryList,directory);
        }

        private static List<DirectoryInfo> GetChild(List<DirectoryInfo> directoryList, DirectoryInfo directoryCurrent )
        {
            var childArray = directoryCurrent.GetDirectories();//can jump out.
            if (childArray != null && childArray.Length > 0)
            {
                directoryList.AddRange(childArray);
                foreach (var child in childArray)
                {
                    GetChild(directoryList, child);
                }
            }
            return directoryList;
        }

        private void Wait()
        {
            if (DateTime.Now.Millisecond < 999)
            {
                Wait();//run many thread in few time,very fast, so need to wait some time,  
                Thread.Sleep(5);//otherwise system got stuck.
            }
            else
            {
                return;
            }
        }


    }
}
