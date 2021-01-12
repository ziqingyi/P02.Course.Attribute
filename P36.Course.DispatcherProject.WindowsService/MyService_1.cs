using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using P36.Course.DispatcherProject.Common;

namespace P36.Course.DispatcherProject.WindowsService
{
    public partial class MyService_1 : ServiceBase
    {
        private Logger logger = new Logger(typeof(MyService_1));
        public MyService_1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            this.logger.Info("This is OnStart..");



        }

        protected override void OnStop()
        {
            this.logger.Info("This is OnStop..");
        }
    }
}
