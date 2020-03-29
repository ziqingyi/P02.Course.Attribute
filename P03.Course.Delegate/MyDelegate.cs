using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                method.EndInvoke(null);
            }

            {
                WithReturnWIthPara method2 = new WithReturnWIthPara(this.PraReturn);
                int i = 10;
                method2.Invoke(out int a, ref i);


                WithReturnNoPara w = new WithReturnNoPara(Get);
                w.Invoke(); // same to this.Get();

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
                Action<int> a_in = this.ShowInt; // ni 

                Func<int> fun_out = this.Get; // can have return, no param
                int iRes = fun_out.Invoke();

                Func<int, string> func1 = this.ToStringFunc;

            }


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
            throw new Exception();
        }

        private void DoNothing()
        {
            Console.WriteLine("this is doing nothing");
        }
    
    }
}
