using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P17.Course.DesignPattern.Observer.Observer;
using P17.Course.DesignPattern.Observer.Subject;

namespace P17.Course.DesignPattern.Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            Cat a = new Cat();
            {
                // method 2:
                a.AddObserver(new Baby());
                a.AddObserver(new Brother());

                a.ScreamObserver();
            }
            {
                a.ScreamEventHandler += (new Baby()).DoAction;
                a.ScreamEventHandler += (new Brother()).DoAction;
                a.ScreamEvent();

            }

        }
    }
}
