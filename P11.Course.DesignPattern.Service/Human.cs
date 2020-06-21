using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P10.Course.DesignPattern.Interface;

namespace P11.Course.DesignPattern.Service
{
    public class Human : IRace
    {
        public Human(int id, DateTime dateTime, string remark)
        {
        }

        public Human()
        {
        }
        public void ShowKing()
        {
            Console.WriteLine("The King of {0} is {1}", this.GetType().Name, "Sky");
        }

    }


    public class HumanArmy : IArmy
    {

        public void ShowArmy()
        {
            Console.WriteLine("The Army of {0} is {1}", this.GetType().Name, "Footman,Rifleman,Knight,Griffin");
        }
    }

    public class HumanHero : IHero
    {
        public void ShowHero()
        {
            Console.WriteLine("The Army of {0} is {1}", this.GetType().Name, "Archmage,Mountain King,Paladin,Blood Mage");
        }
    }
    public class HumanResource : IResource
    {

        public void ShowResource()
        {
            Console.WriteLine("The Army of {0} is {1}", this.GetType().Name, "1000G1000W");
        }
    }
}
