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

        public TestJob()
        {
            Console.WriteLine("new TestJob is initialized");
        }

        public async Task Execute(IJobExecutionContext context)
        {
            await Task.Run(() =>
            {
                Console.WriteLine();
                Console.WriteLine("**********************************");

                {
                    //get job dataMap details from Context's JobDetail
                    JobDataMap dataMap = context.JobDetail.JobDataMap;
                    Console.WriteLine("student1 is : "+ dataMap.Get("student1"));
                    Console.WriteLine("student2 is : " + dataMap.Get("student2"));
                    Console.WriteLine("student3 is : " + dataMap.Get("student3"));
                    Console.WriteLine("Year1 is : " + dataMap.GetInt("Year"));//capital sensitive. 
                }

                {
                    //get job dataMap details from Context's Trigger
                    JobDataMap dataMap = context.Trigger.JobDataMap;
                    Console.WriteLine("student1 is : " + dataMap.Get("student1"));
                    Console.WriteLine("student2 is : " + dataMap.Get("student2"));
                    Console.WriteLine("student3 is : " + dataMap.Get("student3"));
                    Console.WriteLine("Year1 is : " + dataMap.GetInt("Year"));//capital sensitive. 
                }

                Console.WriteLine("This is TestJob Construction in thread {0}, now is {1}", Thread.CurrentThread.ManagedThreadId,DateTime.Now);
                Console.WriteLine("**********************************");
                Console.WriteLine();
            });
        }

    }
}
