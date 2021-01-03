using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Quartz;

namespace P36.Course.DispatcherProject.QuartzNet.CustomJob
{
    public class TestJob: IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            await Task.Run(() =>
            {
                Console.WriteLine();
                Console.WriteLine("**********************************");
                Console.WriteLine("This is TestJob Construction in thread {0}, now is {1}", Thread.CurrentThread.ManagedThreadId,DateTime.Now);
                Console.WriteLine("**********************************");
                Console.WriteLine();
            });
        }

    }
}
