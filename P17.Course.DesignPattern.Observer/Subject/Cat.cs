using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
        //method 2: build observer list and call their method.
        private List<IObserver> _observers = new List<IObserver>();

        public void AddObserver(IObserver observer)
        {
            this._observers.Add(observer);
        }

        public void ScreamObserver()
        {
            Console.WriteLine("{0} Scream observer....", this.GetType().Name);
            if (this._observers != null && this._observers.Count > 0)
            {
                foreach (IObserver itemObserver in _observers)
                {
                    itemObserver.DoAction();
                }
            }
        }

        //method 3: build event handler and execute  
        public event Action ScreamEventHandler;

        public void ScreamEvent()
        {
            Console.WriteLine("{0} Scream event..", this.GetType().Name);
            if (this.ScreamEventHandler != null)
            {
                foreach (Action item in this.ScreamEventHandler.GetInvocationList())
                {
                    item.Invoke();
                }
            }
        }


    }
}
