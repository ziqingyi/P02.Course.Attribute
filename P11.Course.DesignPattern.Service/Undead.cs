using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P10.Course.DesignPattern.Interface;

namespace P11.Course.DesignPattern.Service
{
    public class Undead : IRace
    {
        public void ShowKing()
        {
            Console.WriteLine("The King of {0} is {1}", this.GetType().Name, "GoStop");
        }
    }

    public class UndeadArmy : IArmy
    {

        public void ShowArmy()
        {
            Console.WriteLine("The Army of {0} is {1}", this.GetType().Name, "Acolyte,Gargoyle, Abomination, Meat Wagon, Banshee, Crypt Fiend");
        }
    }

    public class UndeadHero : IHero
    {
        public void ShowHero()
        {
            Console.WriteLine("The Army of {0} is {1}", this.GetType().Name, "Death Knight, Lich, Crypt Lord, Dread Lord");
        }
    }
    public class UndeadResource : IResource
    {

        public void ShowResource()
        {
            Console.WriteLine("The Army of {0} is {1}", this.GetType().Name, "1000G1000W");
        }
    }
}
