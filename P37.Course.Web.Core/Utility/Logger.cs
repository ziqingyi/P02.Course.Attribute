﻿using log4net.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace P37.Course.Web.Core.Utility
{
    public class Logger
    {
        static Logger()
        {
            FileInfo fi = new FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CfgFiles\\log4net.config"));
            XmlConfigurator.Configure(fi);

            ILog Log = LogManager.GetLogger(typeof(Logger));
            Log.Info("initialise Logger");
        }

        private ILog loger = null;

        public Logger(Type type)
        {
            loger = LogManager.GetLogger(type);
        }

        //create Logger
        public static Logger CreateLogger(Type type)
        {
            return new Logger(type);
        }

        public void Fatal(string msg = "Fatal Error", Exception ex = null)
        {
            Console.WriteLine(msg);
            loger.Fatal(msg,ex);
        }


        public void Error(string msg = "Exception", Exception ex = null)
        {
            Console.WriteLine(msg);
            loger.Error(msg, ex);
        }

        public void Warn(string msg)
        {
            Console.WriteLine(msg);
            loger.Warn(msg);
        }

        public void Info(string msg)
        {
            Console.WriteLine(msg);
            loger.Info(msg);
        }

        public void Debug(string msg)
        {
            Console.WriteLine(msg);
            loger.Debug(msg);
        }





    }
}
