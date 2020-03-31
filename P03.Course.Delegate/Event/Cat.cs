using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03.Course.Delegate.Event
{
    public class Cat
    {

        public void Miao()
        {
            Console.WriteLine("{0} Miao", this.GetType().Name);
            new Dog().Wang();
            new Mouse().Run();
            new Baby().Cry();
            new Mother().Wispher();
            new Brother().Turn();
            new Father().Roar();
            new Neighbor().Awake();
            new Stealer().Hide();
            Console.WriteLine("*&^&*^*^*(^&*^&*^&*^&*^");
            Console.WriteLine("*&^&*^*^*(^&*^&*^&*^&*^");
            Console.WriteLine("*&^&*^*^*(^&*^&*^&*^&*^");
            Console.WriteLine("*&^&*^*^*(^&*^&*^&*^&*^");
            Console.WriteLine("*&^&*^*^*(^&*^&*^&*^&*^");
        }

        private List<IObject> _ObserverList = new List<IObject>();

        public void AddObserver(IObject observer)
        {
            this._ObserverList.Add(observer);
        }

        public void MiaoObserver()
        {
            Console.WriteLine("{0} MiaoObserver",this.GetType().Name);
            foreach (var item in this._ObserverList)
            {
                item.DoAction();
            }
            Console.WriteLine("*&^&*^*^*(^&*^&*^&*^&*^");
            Console.WriteLine("*&^&*^*^*(^&*^&*^&*^&*^");
            Console.WriteLine("*&^&*^*^*(^&*^&*^&*^&*^");
            Console.WriteLine("*&^&*^*^*(^&*^&*^&*^&*^");
            Console.WriteLine("*&^&*^*^*(^&*^&*^&*^&*^");
        }

        public Action CatMiaoAction;

        public void MiaoDelegate()
        {
            Console.WriteLine("{0} MiaoDelegate ", this.GetType().Name);
            this.CatMiaoAction?.Invoke();
            Console.WriteLine("*&^&*^*^*(^&*^&*^&*^&*^");
            Console.WriteLine("*&^&*^*^*(^&*^&*^&*^&*^");
            Console.WriteLine("*&^&*^*^*(^&*^&*^&*^&*^");
            Console.WriteLine("*&^&*^*^*(^&*^&*^&*^&*^");
            Console.WriteLine("*&^&*^*^*(^&*^&*^&*^&*^");

        }

        public event Action CatMiaoActionHandler;

        public void MiaoEvent()
        {
            Console.WriteLine("{0} MiaoEvent", this.GetType().Name);
            this.CatMiaoActionHandler?.Invoke();

            Console.WriteLine("*&^&*^*^*(^&*^&*^&*^&*^");
            Console.WriteLine("*&^&*^*^*(^&*^&*^&*^&*^");
            Console.WriteLine("*&^&*^*^*(^&*^&*^&*^&*^");
            Console.WriteLine("*&^&*^*^*(^&*^&*^&*^&*^");
            Console.WriteLine("*&^&*^*^*(^&*^&*^&*^&*^");


        }


    }
}
