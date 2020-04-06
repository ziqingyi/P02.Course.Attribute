using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace P04.Course.Lambda
{
    public delegate void NOReturnNoParaOutClass();

    public delegate void GenericDelegate<T>();

    public class LambdaShow
    {
        public delegate void NoReturnNoPara();

        public delegate void NoReturnWithPara(int x, String y);

        public delegate int WithReturnNoPara();

        public delegate string WithReturnWithPara(out int x, ref int y);

        public void Show()
        {
            
            //.net framwork 1.0
            NoReturnNoPara method1 = new NoReturnNoPara(DoNothing);
            method1 = DoNothing;
            method1.Invoke();

            NoReturnWithPara m1 = Study;
            m1.Invoke(111,"tt");

            //.net framework 2.0 anonymous
            int i = 10;//no method name make it convenient to pass this variable. 
            NoReturnWithPara method2 = new NoReturnWithPara(delegate(int id, string name)
            {
                Console.WriteLine(i);//share internal variable 
                Console.WriteLine($"{id} {name} study advanced course ");
            });
            method2.Invoke(123,"xxx");

            //.net framwork 3.0   remove delegate , use => , goes to 
            NoReturnWithPara method3 = new NoReturnWithPara( 
                (int id, string name)=>
            {
                Console.WriteLine($"{id} {name} study advanced course ");
            });
            method3.Invoke(234, "yyy");

            // some .net framwork update, remove type, compiler will compile based on delegate. 
            NoReturnWithPara method4 = new NoReturnWithPara(
                ( id,  name) =>
                {
                    Console.WriteLine($"{id} {name} study advanced course ");
                });
            method4.Invoke(234, "zzz");

            // some .net framwork update, when one sentence, remove {}
            NoReturnWithPara method5 = new NoReturnWithPara(
                (id, name) => Console.WriteLine($"{id} {name} study advanced course ")
                );
            method5.Invoke(234, "zzz");

            // some .net framwork update, new delegatename() is not necessary 
            NoReturnWithPara method6 =
                (id, name) => Console.WriteLine($"{id} {name} study advanced course ");
            
            method6.Invoke(234, "zzz");

            //lambda  is a method used as  a parameter,and then used for initialise the delegate.


            {// delegate in multicasting 
                NoReturnWithPara mm ;
                mm = this.Study;
                mm += (id, name) => { Console.WriteLine($" {id}  {name} are studying multicasting  "); };

                mm -= this.Study;
                // compiler will generate different name for method, so cannot remove. 
                mm -= (id, name) => { Console.WriteLine($" {id}  {name} are studying multicasting  "); };

                mm.Invoke(888, "multi");
            }
            {
                // anomymous class can have return value. 
                Action action0 = () => { };
                Action<string> a1 = s => Console.WriteLine(s);

                Func<int> func0 = () => DateTime.Now.Month;
                Func<int, string, int> func11 = (id,name)=>id;
                ;
            }

        }

        private void DoNothing()
        {
            Console.WriteLine(" this is do nothing method   ");
        }

        public void Study(int id, string name)
        {
            Console.WriteLine($"{id} {name} study advanced course");
        }


    }
}
