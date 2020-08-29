using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace P03.Course.Delegate
{
    public class MyDelegate
    {
        public delegate void NoReturnNoPara();

        public delegate void NoReturnWIthPara(int x, int y);

        public delegate int WithReturnNoPara();

        public delegate MyDelegate WithReturnWIthPara(out int x, ref int y);

        public void Show()
        {
            Student s = new Student()
            {
                Id = 96,
                Name = "Tom"
            };
            s.Study();
            {
                NoReturnNoPara method = new NoReturnNoPara(this.DoNothing);
                method.Invoke(); // same to this.DoNothing();
                method(); // can also remove Invoke()
                method.BeginInvoke(null, null); // run a thread 
                //method.EndInvoke(null);
            }

            {
                WithReturnWIthPara method2 = new WithReturnWIthPara(this.PraReturn);
                int i = 1;
                int a;//declaring the variable without assigning value. 
                method2.Invoke(out a, ref i);


                WithReturnNoPara w = new WithReturnNoPara(Get);
                int ss  = w.Invoke(); // same to this.Get();

            }

            {
                Student ss = new Student()
                {
                    Id = 123,
                    Name = "Rab",
                    Age = 23,
                    ClassId = 1
                };
                ss.SayHi("Cath", PeopleType.Chinese);

                ss.SayHiPerfect("tom", ss.SayHiEnglish);
            }

            {
                Action a = new Action(this.DoNothing); // up to 16 param, no return 
                Action aa = this.DoNothing; // Syntactic sugar
                Action<int> a_in = this.ShowInt; // contra variant, because it's in:  void Action<in T>(T obj)

                Func<int> fun_out = this.Get; // can have return, no param
                int iRes = fun_out.Invoke();

                Func<int, string> func1 = this.ToStringFunc;

            }
            {
                Action a0 = this.DoNothing;
                NoReturnNoPara method = this.DoNothing;

                this.DOAction(a0);
                //this.DOAction(method);//wrong, different kind of delegate.


                //if there are many delegates in the system, the delegate parameter cannot be commonly used.
                // so the system defined action and func 
                Thread a = new Thread(new ParameterizedThreadStart(t => { Console.WriteLine("ddd"); }));

                ThreadPool.QueueUserWorkItem(new WaitCallback(t => { Console.WriteLine("ddd"); }));

                Task.Run(new Action(
                    ()=> { Console.WriteLine("ddd"); }
                    ));

            }
            { 
                //many ways to init, must keep same param and return value with delegate
                {
                    NoReturnNoPara method = new NoReturnNoPara(this.DoNothing);
                    NoReturnNoPara method2 = this.DoNothing;
                    Action m = this.DoNothing;
                }
                {
                    NoReturnNoPara method = new NoReturnNoPara(DONothintgStatic);
                    NoReturnNoPara method2 = DONothintgStatic;
                    Action m = DONothintgStatic;
                }
                {
                    NoReturnNoPara method = new NoReturnNoPara(new Student().Study);
                    NoReturnNoPara method2 = new Student().Study;
                    Action m = new Student().Study;
                }
                {
                    NoReturnNoPara method = new NoReturnNoPara(Student.Staticstudy);
                    NoReturnNoPara method2 = Student.Staticstudy;
                    Action m = Student.Staticstudy;
                }
            }
            {
                //multicast delegate 
                Action method = this.DoNothing;
                method += DONothintgStatic;
                method += this.DoNothing;
                method += new Student().Study;
                method += Student.Staticstudy;

                foreach (Action item in method.GetInvocationList())
                {
                    item.Invoke();
                    item.BeginInvoke(null,null);
                }

                method -= this.DoNothing;
                method -= new Student().Study;//will not remove that one,because different obj. 

                //method.Invoke();
                //new thread to run //but multicast delegate cannot async. 
                //method.BeginInvoke(null, null);
            }

        }

        private void DOAction(Action act)
        {
            act.Invoke();
        }

        private string ToStringFunc(int i)
        {
            return i.ToString() + " string";
        }

        public void ShowInt(int i)
        {
            Console.WriteLine(i);
        }


        public int Get()
        {
            return 10;
        }
        private MyDelegate PraReturn(out int x, ref int y)
        {
            //throw new Exception();
            x =  1;
            y = y + 1;
            return null;
        }

        private void DoNothing()
        {
            Console.WriteLine("this is doing nothing");
        }

        private static void DONothintgStatic()
        {
            Console.WriteLine("This is static do nothing");
        }
    
    }
}
