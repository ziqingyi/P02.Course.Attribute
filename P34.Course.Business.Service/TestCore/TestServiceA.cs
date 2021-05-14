using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P34.Course.Business.Interface.TestCore;

namespace P34.Course.Business.Service.TestCore
{
    public class TestServiceA : ITestServiceA
    {
        public void Show()
        {
            Console.WriteLine("This is TestServiceA A123456");
        }
    }
}
