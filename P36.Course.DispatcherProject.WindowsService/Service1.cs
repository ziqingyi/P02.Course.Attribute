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
    public partial class Service1 : ServiceBase
    {
        private Logger logger = new Logger(typeof(Service1));
        public Service1()
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
