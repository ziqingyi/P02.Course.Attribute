using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P10.Course.DesignPattern.Interface;
using P11.Course.DesignPattern.Service;

namespace P09.Course.DesignPattern.SimpleFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player(){Id = 1, Name =  "player1"};

            {
                // create instance
                Human human = new Human();
                player.PlayHuman(human);
                player.PlayWar3(human);
            }
            {  
                //use interface 
                IRace human = new Human();
                player.PlayWar3(human);
            }
            {
                // create by factory , using Enum to decide which constructor is called. 
                IRace human = ObjectFactory.CreateRace(RaceType.Human);
                player.PlayWar3(human);
            }
            {
                //create by string from config. convert string to Enum --Enum.Parse()
                IRace undead = ObjectFactory.CreateRaceByConfig();
                player.PlayWar3(undead);
            }
            {
                //Assembly load dll, assembly get type, Activator create instance, return to interface. 
                IRace ne = ObjectFactory.CreateRaceConfigReflection();
                player.PlayWar3(ne);
            }




        }
    }
}
