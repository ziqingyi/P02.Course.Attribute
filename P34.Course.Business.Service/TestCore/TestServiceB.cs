using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using P34.Course.Business.Interface.TestCore;

namespace P34.Course.Business.Service.TestCore
{
    public class TestServiceB : ITestServiceB
    {
        private ILogger<TestServiceB> _logger = null;
        public TestServiceB(ITestServiceA iTestServiceA, ILogger<TestServiceB> logger)
        {
            //Console.WriteLine("initialize TestServiceB with ITestServiceA");
            //use logger instead of Console
            this._logger = logger;
            logger.LogInformation("initialize TestServiceB with ITestServiceA");
        }

        public void Show()
        {
            //Console.WriteLine($"This is TestServiceB B123456");
            //use logger instead of Console
            this._logger.LogInformation($"This is TestServiceB show() B123456");
            
        }
    }
}
