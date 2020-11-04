using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace P27.Course.DataStructure
{
    public class DynamicDemo
    {
        public static void Show()
        {
            {
                string s = "abcd";
                //int i = (int)s;  //error, compile-time type checking
                //s.Hello();//error,compile-time type checking
            }
            {
                //The compiler does not check the type of the dynamic type variable at compile time,
                //instead of this, the compiler gets the type at the run time. 
                try
                {
                    dynamic s = "abcd";
                    int i = (int)s; //error in running
                    s.Hello(); //error in running
                    int a = s.Something; //error in running
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    
                }
                

            }
            {
                /*
                 *In most of the cases, the dynamic type behaves like object types.
                 * You can get the actual type of the dynamic variable at runtime by using GetType() method.
                 * The dynamic type changes its type at the run time based on the value
                 * present on the right-hand side. As shown in the below example.
                 */
                dynamic value1 = 123234;
                Console.WriteLine("value1's type is : " + value1.GetType());

                object a = new YieldDemo();
                //a.Power(); // cannot resolve

                //invoke method by reflection
                Type type = a.GetType();
                MethodInfo method = type.GetMethod("Power");
                object result = method.Invoke(a, null);

            
                //use dynamic way other than reflection, 1 efficient data-binding 2 interoperable with C++
                dynamic dynamic_a = a;
                dynamic_a.Power();


                //clr will generate several delegates in first time running, then next time, will invoke directly, faster than reflection. 
                dynamic str = "abcd";
                Console.WriteLine(str.Length);// everything in str will be dynamic. so Length, Substring() are also dynamic. 
                Console.WriteLine(str.Substring(1));
            }





        }



    }
}
