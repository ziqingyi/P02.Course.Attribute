using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P10.Course.DesignPattern.Interface;

namespace P13.Course.DesignPattern.AbstractFactory.Factory
{
    public abstract class FactoryAbstract
    {
        public abstract IRace CreateRace();
        public abstract IArmy CreateArmy();
        public abstract IHero CreateHero();
        public abstract IResource CreateResource();
        //public abstract ILuck CreateLuck();

    }
}
