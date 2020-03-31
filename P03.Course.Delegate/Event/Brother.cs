using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03.Course.Delegate.Event
{
    class Brother: IObject
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
