﻿using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P36.Course.DispatcherProject.QuartzNet.CustomJob;
using P36.Course.DispatcherProject.QuartzNet.CustomListener;
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

        public async static Task InitTestJob()
        {
            #region scheduler
            Console.WriteLine("init scheduler for testjob.....");
            StdSchedulerFactory factory = new StdSchedulerFactory();
            IScheduler scheduler = await factory.GetScheduler();
            await scheduler.Start();
            #endregion

            #region create IJob  and ITrigger
            {
                //create job task
               IJobDetail jobDetail= JobBuilder.Create<TestJob>()
                    .WithIdentity("testjob", "group1")
                    .WithDescription("This is test job")
                    .Build();

                //pass values
                jobDetail.JobDataMap.Add("student1","aaa");
                jobDetail.JobDataMap.Add("student2","bbb");
                jobDetail.JobDataMap.Add("student3","ccc");
                jobDetail.JobDataMap.Add("Year1", DateTime.Now.Year-1);

                //create trigger
                ITrigger trigger = TriggerBuilder.Create()
                    .WithIdentity("testTrigger1", "group1")
                    .StartAt(new DateTimeOffset(DateTime.Now.AddSeconds(5)))
                    //.StartNow()
                    .WithCronSchedule("0/10 * * * * ?")//every 10 seconds //("0 0/1 * * * ?") //every minutes
                    .WithDescription("This is testjob's Trigger")
                    .Build();

                //pass values
                trigger.JobDataMap.Add("student4", "ddd");
                trigger.JobDataMap.Add("student5", "eee");
                trigger.JobDataMap.Add("student6", "fff");
                trigger.JobDataMap.Add("Year1", DateTime.Now.Year);

                //add to scheduler
                await scheduler.ScheduleJob(jobDetail, trigger);

                Console.WriteLine("scheduler testjob added successfully....");
            }
            #endregion
        }

        public async static Task InitTestStatefulJob()
        {
            #region scheduler
            Console.WriteLine("init scheduler for TestStatefulJob.....");
            StdSchedulerFactory factory = new StdSchedulerFactory();
            IScheduler scheduler = await factory.GetScheduler();
            scheduler.ListenerManager.AddSchedulerListener(new CustomSchedulerListener());
            await scheduler.Start();
            #endregion

            #region create IJob  and ITrigger
            {
                //create job task
                IJobDetail jobDetail = JobBuilder.Create<TestStatefulJob>()
                    .WithIdentity("TestStatefulJob", "group1")
                    .WithDescription("This is Test Stateful Job")
                    .Build();

                //pass values
                jobDetail.JobDataMap.Add("student1", "aaa");
                jobDetail.JobDataMap.Add("student2", "bbb");
                jobDetail.JobDataMap.Add("student3", "ccc");
                jobDetail.JobDataMap.Add("Year1", DateTime.Now.Year - 1);

                //create trigger
                ITrigger trigger = TriggerBuilder.Create()
                    .WithIdentity("testTrigger1", "group1")
                    .StartNow()
                    .WithSimpleSchedule(x => 
                        x.WithIntervalInSeconds(10)
                        .WithRepeatCount(5)//limit time of repeat 
                        //.RepeatForever()
                        )
                    .WithDescription("This is TestStatefulJob's Trigger")
                    .Build();

                //pass values
                trigger.JobDataMap.Add("student4", "ddd");
                trigger.JobDataMap.Add("student5", "eee");
                trigger.JobDataMap.Add("student6", "fff");
                trigger.JobDataMap.Add("Year1", DateTime.Now.Year);

                //add to scheduler
                await scheduler.ScheduleJob(jobDetail, trigger);

                Console.WriteLine("scheduler TestStatefulJob added successfully....");
            }
            #endregion
        }










    }
}
