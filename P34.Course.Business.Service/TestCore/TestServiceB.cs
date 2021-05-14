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
        public TestServiceB(ITestServiceA iTestService, ILogger<TestServiceB> logger)
        {
            this._logger = logger;
        }

        public void Show()
        {
            this._logger.LogDebug($"This is TestServiceB B123456");
            Console.WriteLine($"This is TestServiceB B123456");
        }
    }
}
