using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03.Course.Delegate.Event
{
    class Father:IObject
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
