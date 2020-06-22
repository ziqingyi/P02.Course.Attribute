using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P10.Course.DesignPattern.Interface;

namespace P12.Course.DesignPattern.FactoryMethod.Factory
{
    public interface IFactory
    {
        IRace CreateRace();
    }
}
