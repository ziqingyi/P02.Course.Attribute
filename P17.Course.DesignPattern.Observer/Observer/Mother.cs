using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P17.Course.DesignPattern.Observer.Observer
{
    public class Mother : IObserver
    {
        public void DoAction()
        {
            this.Whisper();
        }
        public void Whisper()
        {
            Console.WriteLine("{0} Whisper", this.GetType().Name);
        }
    }
}
