using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P18.Course.MyAOP.DecoratorAOPFolder;
using P18.Course.MyAOP.ProxyAOPFolder;
using P18.Course.MyAOP.RealProxyAOPFolder;


namespace P18.Course.MyAOP
{
    class Program
    {
        static void Main(string[] args)
        {
            #region AOP show

            //Console.WriteLine("****************Decorator Show********************");
            //DecoratorAOP.Show();

            //Console.WriteLine("************Proxy AOP Show*******************");
            //ProxyAOP.Show();

            Console.WriteLine("************Real Proxy AOP Show*******************");
            RealProxyAOP.Show();




            #endregion



        }
    }
}
