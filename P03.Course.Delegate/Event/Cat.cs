﻿using System;
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
            ////original use: 
            //if (this.CatMiaoAction != null)
            //{
            //    this.CatMiaoAction.Invoke();
            //}
            //for simple: 
            this.CatMiaoAction?.Invoke();

            Console.WriteLine("*&^&*^*^*(^&*^&*^&*^&*^");
            Console.WriteLine("*&^&*^*^*(^&*^&*^&*^&*^");
            Console.WriteLine("*&^&*^*^*(^&*^&*^&*^&*^");
            Console.WriteLine("*&^&*^*^*(^&*^&*^&*^&*^");
            Console.WriteLine("*&^&*^*^*(^&*^&*^&*^&*^");

        }
        // event cannot be used outside of the class, not available in subclass. 
        // support by compiler. 
        //You aren't using a public property but a public field (using events, the compiler protects your fields from unwanted access)
        // Events can't be assigned directly.only += or -=. cannot just be override outside.
        // No one outside of your class can raise the event.
        // Events can be included in an interface declaration, whereas a field cannot

        //A delegate specifies a TYPE (such as a class , or an interface does),
        //whereas an event is just a kind of MEMBER (such as fields, properties, etc).
        //just like any other kind of member,  an event also has a type.
        //An Event declaration adds a layer of abstraction and protection on the delegate instance.
        //So Event can be static, delegate cannot. eg as below:
        //public delegate void MoveDelegate(object o);
        //public static MoveDelegate MoveMethod;

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

    public class Cat2 : Cat
    {
        public void DO()
        {
            //this.CatMiaoActionHandler = null;
        }
    }



}
