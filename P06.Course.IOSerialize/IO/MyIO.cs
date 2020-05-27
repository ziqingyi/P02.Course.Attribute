using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace P06.Course.IOSerialize.IO
{
    public class MyIO
    {
        //get absolute path from app config, and using constant to manage all file path
        private static string NotExistPath = ConfigurationManager.AppSettings["NotExistFolder"];
        private static string LogPath = Constant.LogPath;
        private static string LogMovePath = Constant.LogMovePath;
        //relative directory path
        private static string LogPath2 = AppDomain.CurrentDomain.BaseDirectory;


        public static void Show()
        {
            {
                Console.WriteLine("-----------directory and directoryinfo-----------------");

                if (Directory.Exists(LogPath))
                {
                    Console.WriteLine("log path exist");
                }
                //note: this object will not report error if not exists.
                DirectoryInfo notReportError = new DirectoryInfo(NotExistPath);
                Console.WriteLine(string.Format("FullName: {0} CreationTime: {1} LastWriteTime: {2}", 
                    notReportError.FullName,
                    notReportError.CreationTime,
                    notReportError.LastWriteTime));



                if (File.Exists(Path.Combine(LogPath, "info.txt")))
                {
                    FileInfo fileInfo = new FileInfo(Path.Combine(LogPath,"info.txt"));
                    
                    Console.WriteLine(string.Format("FullName: {0} CreationTime: {1} LastWriteTime: {2}",
                        fileInfo.FullName,
                        fileInfo.CreationTime,
                        fileInfo.LastWriteTime));
                }
            }
            {
                Console.WriteLine("-----------------directory operation --------------------");
                // iiii.txt will be folder name if using Directory
                string newLogPath = Path.Combine(LogPath, "newLogPath/iiii.txt");

                if (!Directory.Exists(newLogPath))
                {
                    //only help to create directory
                    DirectoryInfo di = Directory.CreateDirectory(newLogPath );
                }
                
                if (Directory.Exists(LogMovePath))
                {
                    //Deletes an empty directory, can not have files inside 
                    Directory.Delete(LogMovePath);
                }
                //move all files in the folder to new folder, can have files inside.
                //new folder must check and delete if already exist. 
                Directory.Move(newLogPath,LogMovePath);

                Console.WriteLine("-----------------file operation --------------------");
                String fileName = Path.Combine(LogPath,"log.txt");
                string fileNameCopy = Path.Combine(LogPath, "logCopy.txt");
                string fileNameMove = Path.Combine(LogPath, "logMove.txt");
                bool isExists = File.Exists(fileNameMove);
                if (!isExists)
                {


























                }





            }
        }



    }
}
