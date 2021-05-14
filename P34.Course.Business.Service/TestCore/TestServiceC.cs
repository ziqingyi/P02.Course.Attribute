using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P34.Course.Business.Interface.TestCore;

namespace P34.Course.Business.Service.TestCore
{
    public class TestServiceC : ITestServiceC
    {
        public TestServiceC(ITestServiceB iTestServiceB)
        {
            Console.WriteLine("initialize TestServiceC with TestServiceB");
            iTestServiceB.Show();
        }
        public void Show()
        {
            Console.WriteLine("This is  TestServiceC  C123456");
        }
    }
}
