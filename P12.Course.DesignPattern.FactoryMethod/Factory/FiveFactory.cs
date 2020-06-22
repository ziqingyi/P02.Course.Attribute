using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P10.Course.DesignPattern.Interface;
using P11.Course.DesignPattern.Service;

namespace P12.Course.DesignPattern.FactoryMethod.Factory
{
    public class FiveFactory:IFactory
    {
        public virtual IRace CreateRace()// virtual 
        {
            return new Five(2, "New", 2);
        }

    }
}
