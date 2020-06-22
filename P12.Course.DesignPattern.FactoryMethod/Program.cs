using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P10.Course.DesignPattern.Interface;
using P12.Course.DesignPattern.FactoryMethod.Factory;

namespace P12.Course.DesignPattern.FactoryMethod
{
    class Program
    {
        //Define an interface for creating an object,
        //but let subclasses decide which class to instantiate.
        //Factory Method lets a class defer instantiation to subclasses.
        static void Main(string[] args)
        {
            {
                IFactory factory = new HumanFactory();
                IRace race = factory.CreateRace();

            }





        }
    }
}
