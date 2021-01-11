using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P19.Course.ConsoleWriterProj;
using Quartz.Logging;

namespace P36.Course.DispatcherProject.QuartzNet.CustomLog
{
    public class CustomConsoleLogProvider : ILogProvider
    {
        public Logger GetLogger(string name)
        {
            Logger newLogger = (logLevel, messageFunc, exception, formatParameters) =>
            {
                if (logLevel > LogLevel.Info && messageFunc != null)
                {
                    ConsoleWriter.WriteLineYellow($"[{ DateTime.Now.ToLongTimeString()}] [log level: {logLevel}]");
                    ConsoleWriter.WriteLineYellow($"         {messageFunc()} { string.Join(";", formatParameters.Select(p=>p==null? " ":p.ToString()))}");
                    ConsoleWriter.WriteLineYellow($"         user defined log: {name}");
                }
                return true;
            };

            return newLogger;
        }

        public IDisposable OpenMappedContext(string key, object value, bool destructure = false)
        {
            throw new NotImplementedException();
        }

        public IDisposable OpenNestedContext(string message)
        {
            throw new NotImplementedException();
        }
    }
}
