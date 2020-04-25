using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01.Course.DB.SqlServer
{
    public class ReflectionTest
    {
        #region Identity
        public ReflectionTest()
        {
            Console.WriteLine(" Type: {0} no parameter constructor", this.GetType());
        }

        public ReflectionTest(string name)
        {
            Console.WriteLine(" Type: {0}  one parameter constructor with name : {1} ", this.GetType(),name);
        }

        public ReflectionTest(int id)
        {
            Console.WriteLine(" Type: {0} one parameter constructor with id : {1}", this.GetType(),id);
        }
        #endregion

        #region Method
        public void Show1()
        {
            Console.WriteLine(" Type: {0}  method: Show1() ", this.GetType());
        }
        public void Show2(int id)
        {

            Console.WriteLine(" Type: {0} Show2 (int id)", this.GetType());
        }
        public void Show3(int id, string name)//overload
        {
            Console.WriteLine(" Type: {0} Show3 (int id, string name)", this.GetType());
        }

        public void Show3(string name, int id)
        {
            Console.WriteLine(" Type: {0} Show3_2(string name, int id)", this.GetType());
        }
        public void Show3(int id)
        {
            Console.WriteLine(" Type: {0} Show3_3(int id)  param: {1}", this.GetType(),id);
        }
        public void Show3(string name)
        {

            Console.WriteLine(" Type:  {0} Show3_4(string name) ", this.GetType());
        }
        public void Show3()
        {

            Console.WriteLine(" Type: {0} Show3_1() ", this.GetType());
        }

        private void Show4(string name)
        {
            Console.WriteLine(" Type: {0} Show4() is private", this.GetType());
        }

        public static void Show5(string name)
        {
            Console.WriteLine(" Type: {0} Show5() is static method ", typeof(ReflectionTest));
        }
        #endregion



    }
}
