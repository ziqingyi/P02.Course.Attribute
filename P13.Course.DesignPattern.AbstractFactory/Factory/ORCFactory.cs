using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P10.Course.DesignPattern.Interface;
using P11.Course.DesignPattern.Service;

namespace P13.Course.DesignPattern.AbstractFactory.Factory
{
    public class ORCFactory :FactoryAbstract
    {
        public override IRace CreateRace()
        {
            return new ORC();
        }

        public override IArmy CreateArmy()
        {
            return new ORCArmy();
        }

        public override IHero CreateHero()
        {
            return new ORCHero();
        }

        public override IResource CreateResource()
        {
            return new ORCResource();
        }

    }
}
