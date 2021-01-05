using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Quartz;

namespace P36.Course.DispatcherProject.QuartzNet.CustomJob
{
    /*
     * #Job State and Concurrency
     * DisallowConcurrentExecution is an attribute that can be added to the Job class that tells Quartz not to execute multiple instances of a given job definition
     *     (that refers to the given job class) concurrently. Notice the wording there, as it was chosen very carefully.
     *     The constraint is based upon an instance definition (JobDetail), not on instances of the job class.
     *     However, it was decided (during the design of Quartz) to have the attribute carried on the class itself,
     *     because it does often make a difference to how the class is coded.
     * PersistJobDataAfterExecution is an attribute that can be added to the Job class that tells Quartz to update the stored
     *     copy of the JobDetail's JobDataMap after the Execute() method completes successfully (without throwing an exception),
     *     such that the next execution of the same job (JobDetail) receives the updated values rather than the originally stored values.
     *     Like the DisallowConcurrentExecution attribute, this applies to a job definition instance, not a job class instance,
     *     though it was decided to have the job class carry the attribute because it does often make a difference to how the class is coded
     *     (e.g. the 'statefulness' will need to be explicitly 'understood' by the code within the execute method).
     *
     * If you use the PersistJobDataAfterExecution attribute, you should strongly consider also using the DisallowConcurrentExecution attribute,
     * in order to avoid possible confusion (race conditions) of what data was left stored when two instances of the same job (JobDetail) executed concurrently
     */
    [PersistJobDataAfterExecution]
    [DisallowConcurrentExecution]//if the code is executing, the other thread will wait for finish. 
    public class TestStatefulJob:IJob
    {
        public static int ID = 0;
        public TestStatefulJob()
        {
            ID++;
            Console.WriteLine($"new TestStatefulJob: {ID} is initialized");
        }

        private static object TempData = new object();//used for passing values or locking
        public async Task Execute(IJobExecutionContext context)
        {
            await Task.Run(() =>
            {
                Console.WriteLine();
                Console.WriteLine("**********************************");

                {
                    //get job dataMap details from Context's JobDetail
                    JobDataMap dataMap = context.JobDetail.JobDataMap;
                    Console.WriteLine("student1 is : " + dataMap.Get("student1"));
                    Console.WriteLine("student2 is : " + dataMap.Get("student2"));
                    Console.WriteLine("student3 is : " + dataMap.Get("student3"));
                    Console.WriteLine("Year1 is : " + dataMap.GetInt("Year1"));//capital sensitive. 

                    dataMap.Put("student1", "new name");
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

                Console.WriteLine("This is TestJob Construction in thread {0}, now is {1}", Thread.CurrentThread.ManagedThreadId, DateTime.Now);
                Console.WriteLine("**********************************");
                Console.WriteLine();
            });
        }


    }
}
