using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;

namespace P32.Course.LuceneProject.Utility
{
    public class Logger
    {
        static Logger()
        {
            FileInfo fileInfo = new FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CfgFiles\\log4net.cfg.xml"));
            XmlConfigurator.Configure(fileInfo);

            ILog Log = LogManager.GetLogger(typeof(Logger));
            Log.Info("init Logger");

        }

        private ILog loger = null;

        public Logger(Type type)
        {
            loger = LogManager.GetLogger(type);
        }

        public void Error(string msg = "error happens", Exception ex = null)
        {
            Console.WriteLine(msg);
            loger.Error(msg,ex);
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
