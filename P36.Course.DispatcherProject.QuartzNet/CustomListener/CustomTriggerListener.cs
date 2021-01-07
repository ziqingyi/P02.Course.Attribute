using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Quartz;

namespace P36.Course.DispatcherProject.QuartzNet.CustomListener
{
    //The interface to be implemented by classes that want to be informed when a ITrigger fires.
   // In general, applications that use a IScheduler will not have use for this mechanism.
    public class CustomTriggerListener : ITriggerListener
    {
        public string Name => "CustomTriggerListener";

        public async Task TriggerComplete(ITrigger trigger, IJobExecutionContext context, SchedulerInstruction triggerInstructionCode, CancellationToken cancellationToken = default)
        {
            await Task.Run(() =>
            {
                Console.WriteLine($"CustomTriggerListener TriggerComplete {trigger.Description}");
            });
        }

        public async Task TriggerFired(ITrigger trigger, IJobExecutionContext context, CancellationToken cancellationToken = default)
        {
            await Task.Run(() =>
            {
                Console.WriteLine($"CustomTriggerListener TriggerFired {trigger.Description}");
            });
        }

        public async Task TriggerMisfired(ITrigger trigger, CancellationToken cancellationToken = default)
        {
            await Task.Run(() =>
            {
                Console.WriteLine($"CustomTriggerListener TriggerMisfired {trigger.Description}");
            });
        }
        //Returns true if job execution should be vetoed, false otherwise.
        public async Task<bool> VetoJobExecution(ITrigger trigger, IJobExecutionContext context, CancellationToken cancellationToken = default)
        {
            await Task.Run(() =>
            {
                Console.WriteLine($"CustomTriggerListener VetoJobExecution {trigger.Description}");
            });
            return false;
        }
    }
}
