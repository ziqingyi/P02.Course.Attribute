using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P36.Course.DispatcherProject.QuartzNet.CustomJob;
using Quartz;

namespace P36.Course.DispatcherProject.QuartzNet
{
    public class DispatcherManager
    {
        //1 nuget
        //2 three core object:
        //      (1) IScheduler -- config scheduler task.
        //                        it's a container and should start for tasks inside. 
        //      (2) IJob: task, which will be executed
        //      (3) ITrigger: properties needed to instantiate an actual Trigger.

        public async static Task Init()
        {
            #region scheduler

            Console.WriteLine("init scheduler.....");
            StdSchedulerFactory factory = new StdSchedulerFactory();
            IScheduler scheduler = await factory.GetScheduler();
            await scheduler.Start();
            #endregion

            #region IJob  and ITrigger

            {
                //create job task
               IJobDetail jobDetail= JobBuilder.Create<TestJob>()
                    .WithIdentity("testjob", "group1")
                    .WithDescription("This is test job")
                    .Build();

                //create trigger
                ITrigger trigger = TriggerBuilder.Create()
                    .WithIdentity("testTrigger1", "group1")
                    .StartAt(new DateTimeOffset(DateTime.Now.AddSeconds(5)))
                    //.StartNow()
                    .WithCronSchedule("0/10 * * * * ?")//every 10 seconds //("0 0/1 * * * ?") //every minutes
                    .WithDescription("This is testjob's Trigger")
                    .Build();
                await scheduler.ScheduleJob(jobDetail, trigger);

                Console.WriteLine("scheduler job added successfully....");
            }
            #endregion



        }












    }
}
