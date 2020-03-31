using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03.Course.Delegate.Event
{
    class Dog : IObject
    {
        public void DoAction()
        {
            this.Wang();
        }

        public void Wang()
        {
            Console.WriteLine("{0} Wang", this.GetType().Name);
        }

    }
}
