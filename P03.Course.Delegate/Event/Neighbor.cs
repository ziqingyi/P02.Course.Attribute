using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03.Course.Delegate.Event
{
    class Neighbor:IObject
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
