using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public async static void Init()
        {
            #region scheduler
            StdSchedulerFactory factory = new StdSchedulerFactory();
            IScheduler scheduler = await factory.GetScheduler();
            await scheduler.Start();
            #endregion





        }












    }
}
