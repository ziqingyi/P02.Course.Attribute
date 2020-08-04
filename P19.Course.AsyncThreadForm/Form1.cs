using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P19.Course.AsyncThreadForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"*************button Sync Click Start, Thread Id is: " +
                              $"{Thread.CurrentThread.ManagedThreadId.ToString("00")}" +
                              $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss. fff")}" +
                              $"*********************");

            int l = 3;
            int m = 4;
            int n = l + m;
            for (int i = 0; i < 5; i++)
            {
                string name = string.Format($"btnSync_Click_{i}");
                this.DoSomethingLong(name);
            }
            Console.WriteLine($"*************btnSync_Click End , Thread Id is: " +
                              $"{Thread.CurrentThread.ManagedThreadId.ToString("00")} " +
                              $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}" +
                              $"***************");

        }


        // a time consuming task
        private void DoSomethingLong(string name)
        {
            Console.WriteLine($"**************DoSomethingLong Start  {name}  , Thread Id is: " +
                              $"{Thread.CurrentThread.ManagedThreadId.ToString("00")} " +
                              $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}" +
                              $"***************");
            long lResult = 0;
            for (int i = 0; i < 1_000_000_000; i++)
            {
                lResult += i;
            }
            //Thread.Sleep(2000);

            Console.WriteLine($"****************DoSomethingLong   End  " +
                              $"{name}  , Thread Id is: " +
                              $"{Thread.CurrentThread.ManagedThreadId.ToString("00")} " +
                              $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")} " +
                              $"{lResult}***************");

        }

        private void btnAsync_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"****************btnAsync_Click Start, Thread Id is: " +
                              $"{Thread.CurrentThread.ManagedThreadId.ToString("00")}" +
                              $" {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}" +
                              $"***************");
            Action<string> action = this.DoSomethingLong;//new Action<string>(this.DoSomethingLong);
            //action += this.DoSomethingLong;//wrong, The delegate must have only one target for multi-thread.but you can write methods in s=>{}; then assign to action.

            //action.Invoke("btnAsync_Click"); //sync way
            //action("btnAsync_Click");  // syntactic sugar 

            //action.BeginInvoke("btnAsync_Click",null,null);//async need 2 extra params

            for (int i = 0; i < 5; i++)
            {
                string name = string.Format($"btnAsync_Click_{i}");
                action.BeginInvoke(name, null, null);
            }


            Console.WriteLine($"****************btnAsync_Click End, Thread Id is:  " +
                              $"{Thread.CurrentThread.ManagedThreadId.ToString("00")} " +
                              $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}" +
                              $"***************");
        }
    }
}
