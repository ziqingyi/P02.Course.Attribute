using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P10.Course.DesignPattern.Interface;
using P11.Course.DesignPattern.Service;
using P13.Course.DesignPattern.AbstractFactory.Factory;

namespace P13.Course.DesignPattern.AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            
            {
                // create instance separately.
                IRace race = new Undead();
                IArmy army = new UndeadArmy();
                IHero hero = new UndeadHero();
                IResource resource = new UndeadResource();
            }
            { 
                //System.Data.SqlClient.SqlClientFactory// create instance together.
                FactoryAbstract undeadFactory = new UndeadFactory();
                IRace race = undeadFactory.CreateRace();
                IArmy army = undeadFactory.CreateArmy();
                IHero hero = undeadFactory.CreateHero();
                IResource resource = undeadFactory.CreateResource();

            }
            {
                FactoryAbstract orcfactory = new ORCFactory();
                IRace race = orcfactory.CreateRace();
                IArmy army = orcfactory.CreateArmy();
                IHero hero = orcfactory.CreateHero();
                IResource resource = orcfactory.CreateResource();
            }



        }
    }
}
