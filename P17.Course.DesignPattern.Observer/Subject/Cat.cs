using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P17.Course.DesignPattern.Observer.Observer;

namespace P17.Course.DesignPattern.Observer.Subject
{
    public class Cat
    {

        public void Scream()
        {
            Console.WriteLine("{0} Screaming.....", this.GetType().Name);


            {
                // bad practice, using other class's implementation. 
                // others' change will lead to change in Cat
                //new Mouse().Run();
                //new Chicken().Woo();
                //new Baby().Cry();
                //new Brother().Turn();
                //new Dog().Wang();
                //new Father().Roar();
                //new Mother().Whisper();
                ////new Mouse().Run();
                //new Neighbor().Awake();
                ////new Stealer().Hide();

            }

        }









    }
}
