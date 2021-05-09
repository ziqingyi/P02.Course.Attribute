using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;

namespace P39.Course.dotnetCore.TestProject
{
    public class CSharp7
    {
        public void Show()
        {
            #region Out

            {
                this.DoNothing(out int x, out int y);

                Console.WriteLine(x+y);

                this.DoNothing(out int l, out int m);
                Console.WriteLine(l+m);
            }

            #endregion



            #region Type testing with pattern matching
            this.PrintStars(null);
            this.PrintStars(3);

            this.Switch(null);
            this.Switch("statusA");
            this.Switch("statusB");
            #endregion



            #region 



            #endregion




            #region 



            #endregion










        }



        private void Switch(string text)
        {
            int k = 100;
            switch (text)
            {

                case "statusA" when k > 10:
                    Console.WriteLine("status A");
                    break;
                case "statusB" when text.Length < 10:
                    Console.WriteLine("status B");
                    break;
                case string s when s.Length > 7:
                    Console.WriteLine(s);
                    break;
                default:
                    Console.WriteLine("default");
                    break;
                case null:
                    Console.WriteLine("null");
                    break;
            }


        }


        private void PrintStars(object o)
        {
            //the is operator also tests an expression result against a pattern.
            //below: use a declaration pattern to check the run-time type of an expression:
            if (o is null) return;

            if(o is int i)
                Console.WriteLine(new string('*', i));

        }


        private void DoNothing(out int x, out int y)
        {
            y = 1;
            x = 2;
        }


    }
}
