using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P03.Course.Delegate.Event;

namespace P03.Course.Delegate
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-----study delegate------");
            {
                MyDelegate myDelegate = new MyDelegate();
                myDelegate.Show();

                Student ss = new Student()
                {
                    Id = 123,
                    Name = "Rab",
                    Age = 23,
                    ClassId = 1
                };
                ss.SayHi("Cath", PeopleType.Chinese);

                SayHiDelegate method = new SayHiDelegate(ss.SayHiChinese);
                ss.SayHiPerfect("wang", method);
            }
            {
                Console.WriteLine("---------Action Func-------------");
                MyDelegate myDelegate = new MyDelegate();
                myDelegate.Show();
            }
            {
                Console.WriteLine("-------------------");
                Cat a = new Cat();
                a.Miao();

                a.CatMiaoAction += new Dog().Wang;
                a.CatMiaoAction += new Mouse().Run;
                a.CatMiaoAction += new Baby().Cry;
                a.CatMiaoAction += new Mother().Wispher;
                a.CatMiaoAction += new Brother().Turn;
                a.CatMiaoAction += new Father().Roar;
                a.CatMiaoAction += new Neighbor().Awake;
                a.CatMiaoAction += new Stealer().Hide;

                a.MiaoDelegate();

                a.CatMiaoActionHandler += new Dog().Wang;
                a.CatMiaoActionHandler += new Mouse().Run;
                a.CatMiaoActionHandler += new Baby().Cry;
                a.CatMiaoActionHandler += new Mother().Wispher;
                a.CatMiaoActionHandler += new Brother().Turn;
                a.CatMiaoActionHandler += new Father().Roar;
                a.CatMiaoActionHandler += new Neighbor().Awake;
                a.CatMiaoActionHandler += new Stealer().Hide;

                a.MiaoEvent();



                Console.WriteLine("&&&&&&&&add to private IObject List &&&&&&&&&");
                a.AddObserver(new Dog());
                a.AddObserver(new Mouse());
                a.AddObserver(new Baby());
                a.AddObserver(new Mother());
                a.AddObserver(new Brother());
                a.AddObserver(new Father());
                a.AddObserver(new Neighbor());
                a.AddObserver(new Stealer());

                a.MiaoObserver();

            }
            {
                EventStandard.Show();

            }
        }
    }
}
