﻿using P23.Course.IOC.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P23.Course.IOC.Service
{
    public class IPhone: Itelephone
    {

        public IMicrophone iMicrophone { get; set; }
        public IHeadphone iHeadphone { get; set; }
        public IPower iPower { get; set; }

        //remove parameterless constructor, make it dependent on IHeadphone. 
        //public IPhone()
        //{
        //    Console.WriteLine("{0} (IPhone)construction method", this.GetType().Name);
        //}

        public IPhone(IHeadphone headphone)
        {
            this.iHeadphone = headphone;
            Console.WriteLine("{0} construction method with {1}", this.GetType().Name, headphone.GetType());
        }


        public void Call()
        {
            Console.WriteLine("{0} is calling....", this.GetType().Name);
        }



    }
}
