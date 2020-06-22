using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P10.Course.DesignPattern.Interface;
using P11.Course.DesignPattern.Service;

namespace P13.Course.DesignPattern.AbstractFactory.Factory
{
    public class UndeadFactory :FactoryAbstract
    {
        public override IRace CreateRace()
        {
            return new Undead();
        }

        public override IArmy CreateArmy()
        {
            return new UndeadArmy();
        }

        public override IHero CreateHero()
        {
            return new UndeadHero();
        }

        public override IResource CreateResource()
        {
            return new UndeadResource();
        }
    }
}
