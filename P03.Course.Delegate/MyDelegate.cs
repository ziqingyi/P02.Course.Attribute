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
                method.Invoke();// same to this.DoNothing();
                method();// can also remove Invoke()
                method.BeginInvoke(null,null);// run a thread 
                method.EndInvoke(null);
            }

            {
                WithReturnWIthPara method2 = new WithReturnWIthPara(this.PraReturn);
                //method2.Invoke(out int a, ref int b );
            }





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
