using P23.Course.IOC.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Unity;

namespace P23.Course.IOC.Service
{
    public class IPhone: Itelephone
    {
        [Dependency]  //attribute injection
        public IMicrophone iMicrophone { get; set; }
        //[Dependency]
        public IHeadphone iHeadphone { get; set; }
        public IPower iPower { get; set; }
        public IDisplay iDisplay { get; set; }

        //public string country;
        //remove parameterless constructor, make it dependent on IHeadphone. 
        //public IPhone()
        //{
        //    Console.WriteLine("{0} (IPhone)construction method", this.GetType().Name);
        //}
        
        //if do not have this attr, container will find the ctor with largest num of params by default(if param is registered)
        //if no Injection attributes here, you can remove the reference to Unity.

        //[InjectionConstructor]
        public IPhone(IHeadphone headphone)
        {
            this.iHeadphone = headphone;
            Console.WriteLine("{0} construction method with {1} in thread: {2}", this.GetType().Name, headphone.GetType(), Thread.CurrentThread.ManagedThreadId);
        }

        public IPhone(IHeadphone headphone, IDisplay display)//, string state="AU"      in {3}   state
        {
            this.iHeadphone = headphone;
            this.iDisplay = display;
            //this.country = state;
            Console.WriteLine("{0} construction method with {1}, {2} in thread: {3}",this.GetType().Name, headphone.GetType(), display.GetType(), Thread.CurrentThread.ManagedThreadId);
        }

        [InjectionMethod]
        public void Call()
        {
            Console.WriteLine("{0} is calling....", this.GetType().Name);
        }



    }
}
