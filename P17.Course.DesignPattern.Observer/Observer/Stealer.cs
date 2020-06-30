using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P17.Course.DesignPattern.Observer.Observer
{
    public class Stealer : IObserver
    {
        public void DoAction()
        {
            this.Hide();
        }
        public void Hide()
        {
            Console.WriteLine("{0} Hide", this.GetType().Name);
        }
    }
}
