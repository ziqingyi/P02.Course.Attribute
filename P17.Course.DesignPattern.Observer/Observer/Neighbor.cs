using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P17.Course.DesignPattern.Observer.Observer
{
    public class Neighbor : IObserver
    {
        public void DoAction()
        {
            this.Awake();
        }
        public void Awake()
        {
            Console.WriteLine("{0} Awake", this.GetType().Name);
        }
    }
}
