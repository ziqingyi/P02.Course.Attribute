using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P16.Course.DesignPattern.TemplateMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            AbstractClient c1 = new ClientCurrent();
            c1.Query(111,"name1", "123132");
            //c1.Show();

            AbstractClient c2 = new ClientRegular();
            c2.Query(222,"name2", "342424");
            //c2.Show();

            AbstractClient c3 = new ClientVIP();
            c3.Query(333,"name3","34235465");
            c3.Show();  // will call  derived class method    (virtual method, pointer decide during running)
            c3.Normal();//will call base class's method (during compiling)

            ClientVIP c4 = new ClientVIP();
            c4.Query(444, "name4", "34235465");
            c4.Normal();  
        }
    }
}
