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
        public static int ID = 0;
        public TestJob()
        {
            Console.WriteLine();
            ID++;
            Console.WriteLine($"******************new TestStatefulJob: {ID} is initialized****************");
        }

        public async Task Execute(IJobExecutionContext context)
        {
            await Task.Run(() =>
            {
                Console.WriteLine();
                Console.WriteLine("***************TestJob Execute start*******************");

                {
                    //get job dataMap details from Context's JobDetail
                    JobDataMap dataMap = context.JobDetail.JobDataMap;
                    Console.WriteLine("student1 is : "+ dataMap.Get("student1"));
                    Console.WriteLine("student2 is : " + dataMap.Get("student2"));
                    Console.WriteLine("student3 is : " + dataMap.Get("student3"));
                    Console.WriteLine("Year1 is : " + dataMap.GetInt("Year1"));//capital sensitive. 
                }

                {
                    //get job dataMap details from Context's Trigger
                    JobDataMap dataMap = context.Trigger.JobDataMap;
                    Console.WriteLine("student4 is : " + dataMap.Get("student4"));
                    Console.WriteLine("student5 is : " + dataMap.Get("student5"));
                    Console.WriteLine("student6 is : " + dataMap.Get("student6"));
                    Console.WriteLine("Year1 is : " + dataMap.GetInt("Year1"));//capital sensitive. 
                }

                {
                    //get job merged dataMap details from Context's Trigger
                    JobDataMap dataMap = context.MergedJobDataMap;
                    Console.WriteLine("student1 is : " + dataMap.Get("student1"));
                    Console.WriteLine("student2 is : " + dataMap.Get("student2"));
                    Console.WriteLine("student3 is : " + dataMap.Get("student3"));
                    Console.WriteLine("student4 is : " + dataMap.Get("student4"));
                    Console.WriteLine("student5 is : " + dataMap.Get("student5"));
                    Console.WriteLine("student6 is : " + dataMap.Get("student6"));
                    Console.WriteLine("Year1 is : " + dataMap.GetInt("Year1"));//only get latest one
                }

                Console.WriteLine("This is TestJob Execute end  in thread {0}, now is {1}", Thread.CurrentThread.ManagedThreadId,DateTime.Now);
                Console.WriteLine("**********************************");
                Console.WriteLine();
            });
        }

    }
}
