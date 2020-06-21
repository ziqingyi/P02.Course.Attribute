using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P10.Course.DesignPattern.Interface;
using P11.Course.DesignPattern.Service;

namespace P09.Course.DesignPattern.SimpleFactory
{
    public enum RaceType
    {
        Human,
        Undead,
        ORC,
        NE
    }

    public class ObjectFactory
    {
        //centralize the process of creating instance. 
        public static IRace CreateRace(RaceType raceType)
        {
            IRace iRace = null;
            switch (raceType)
            {
                case RaceType.Human:
                    iRace = new Human();
                    break;
                case RaceType.Undead:
                    iRace = new Undead();
                    break;
                case RaceType.ORC:
                    iRace = new ORC();
                    break;
                case RaceType.NE:
                    iRace = new NE();
                    break;
                default:
                    throw new Exception("wrong race type");
            }
            return iRace;
        }
        




    }
}
