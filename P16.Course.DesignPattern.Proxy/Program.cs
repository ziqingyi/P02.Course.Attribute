using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P16.Course.DesignPattern.Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                Console.WriteLine("********business logic******************");
                ISubject subject = new BusinessLogic();
                subject.GetData();
                subject.DoTransaction();
            }
            {
                Console.WriteLine("**********Proxy***********");
                ISubject subject = new ProxySubject();
                subject.GetData();
                subject.DoTransaction();
            }
            {
                Console.WriteLine("**********Proxy2************");
                ISubject subject = new ProxySubject();
                subject.GetData();
                subject.DoTransaction();
            }


        }
    }
}
