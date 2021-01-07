using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using P19.Course.ConsoleWriterProj;
using Quartz;

namespace P36.Course.DispatcherProject.QuartzNet.CustomJob
{
    public class GoodJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            await Task.Run(() =>
            {
                Console.WriteLine();
                ConsoleWriter.WriteLineGreen("**************GoodJob Execute start in thread {0}, now is {1}", Thread.CurrentThread.ManagedThreadId, DateTime.Now);

                Thread.Sleep(1000);

                ConsoleWriter.WriteLineGreen("This is GoodJob Execute end in thread {0}, now is {1}", Thread.CurrentThread.ManagedThreadId, DateTime.Now);
                Console.WriteLine("**********************************");
                Console.WriteLine();
            });

        }
    }
}
