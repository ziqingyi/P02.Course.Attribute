using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P17.Course.DesignPattern.Observer.Observer
{
    public class Father : IObserver
    {
        public void DoAction()
        {
            this.Roar();
        }
        public void Roar()
        {
            Console.WriteLine("{0} Roar", this.GetType().Name);
        }
    }
}
