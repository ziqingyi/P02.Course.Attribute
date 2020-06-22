using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P10.Course.DesignPattern.Interface;
using P11.Course.DesignPattern.Service;

namespace P12.Course.DesignPattern.FactoryMethod.Factory
{
    public class HumanFactory: IFactory
    {
        public virtual IRace CreateRace()
        {
            Console.WriteLine("human factory");
            return new Human();
        }
    }

    public class HumanFactoryAdvanced : HumanFactory
    {
        public override IRace CreateRace()
        {
            Console.WriteLine("advanced human factory");
            return base.CreateRace();
        }
    }





}
