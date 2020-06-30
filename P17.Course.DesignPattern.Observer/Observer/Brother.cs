using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P17.Course.DesignPattern.Observer.Observer
{
    public class Brother : IObserver
    {
        public void DoAction()
        {
            this.Turn();
        }
        public void Turn()
        {
            Console.WriteLine("{0} Turn", this.GetType().Name);
        }
    }
}
