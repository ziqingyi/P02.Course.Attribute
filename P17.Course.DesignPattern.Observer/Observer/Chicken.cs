using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P17.Course.DesignPattern.Observer.Observer
{
    public class Chicken : IObserver
    {
        public void DoAction()
        {
            this.Woo();
        }
        public void Woo()
        {
            Console.WriteLine("{0} Woo", this.GetType().Name);
        }
    }
}
