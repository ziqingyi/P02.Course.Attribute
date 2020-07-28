using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P18.Course.MyAOP.CastleProxyAOPFolder;
using P18.Course.MyAOP.DecoratorAOPFolder;
using P18.Course.MyAOP.ProxyAOPFolder;
using P18.Course.MyAOP.RealProxyAOPFolder;
using P18.Course.MyAOP.UnityAOPFolder;
using P18.Course.MyAOP.UnityAOPFolder2;


namespace P18.Course.MyAOP
{
    class Program
    {
        static void Main(string[] args)
        {
            #region AOP show
            //Implementing AOP:
            //1 static way: The Decorator/Proxy Design Pattern
            //2 dynamic way: Creating a Dynamic Proxy with RealProxy(remoting), Castle(Emit)
            //3 Compile-Time/Runtime Weaving: PostSharp(), the
            //     program is modified during the build process on the development machine, before deployment.
            //     the program is modified during its execution, after deployment

            //4 Independent injection with aop extension: Unity and AutoFac, commonly use other than MVC.

            //5 MVC AOP: invoker center, use attribute and reflection to decide the execution of some other logic. 

            //Console.WriteLine("****************Decorator Show********************");
            //DecoratorAOP.Show();

            //Console.WriteLine("************Proxy AOP Show*******************");
            //ProxyAOP.Show();

            //Console.WriteLine("************Real Proxy AOP Show*******************");
            //RealProxyAOP.Show();

            //Console.WriteLine("***************Castle Proxy AOP show**************");
            //CastleProxyAOP.Show();

            Console.WriteLine("***************Unity AOP show**************");
            //UnityConfigAOP.Show();

            UnityAOP.Show();

            #endregion



        }
    }
}
