using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;

namespace P39.Course.EntityFrameworkCore3.Model.EFSqlLog
{
    public class CustomEFLoggerFactory : ILoggerFactory
    {
        public void AddProvider(ILoggerProvider provider)
        {
           
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new CustomEFLogger(categoryName);
        }

        public void Dispose()
        {
            
        }
    }
}
