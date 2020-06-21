using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
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
        // still need to consider many details 
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

        private static string IRacTypeConfig = ConfigurationManager.AppSettings["IRacTypeConfig"];

        public static IRace CreateRaceByConfig()
        {
            RaceType raceType = (RaceType)Enum.Parse(typeof(RaceType), IRacTypeConfig);
            return CreateRace(raceType);
        }

        //IOC   : Extensibility and Configurability 
        //      param:   FactoryPattern.War3.Service.NE,  FactoryPattern.War3.Service
        private static string IRacTypeConfigReflection = ConfigurationManager.AppSettings["IRacTypeConfigReflection"];
        private static string DllName = IRacTypeConfigReflection.Split(',')[1];
        private static string TypeName = IRacTypeConfigReflection.Split(',')[0];

        public static IRace CreateRaceConfigReflection()
        {
            Assembly assembly = Assembly.Load(DllName);
            Type type = assembly.GetType(TypeName);
            IRace iRace = Activator.CreateInstance(type) as IRace;

            return iRace;
        }


    }
}
