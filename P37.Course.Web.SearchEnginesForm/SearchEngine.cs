using P32.Course.LuceneProject.Processor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using P37.Course.Web.SearchEngines.SearchService;

namespace P37.Course.Web.SearchEnginesForm
{
    public partial class SearchEngine : Form
    {

        //[DllImport("kernel32.dll", SetLastError = true)]
        //[return: MarshalAs(UnmanagedType.Bool)]
        //static extern bool AllocConsole();
        //AllocConsole();
        public SearchEngine()
        {
            InitializeComponent();
            this.btnStop.Enabled = false;
            this.btnStopWCF.Enabled = false;
        }

        private CancellationTokenSource CTS = null;

        #region Build Index
        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
               
                Console.WriteLine("{0} id={1} Start to build Index", DateTime.Now, Thread.CurrentThread.ManagedThreadId);
                this.btnStart.Enabled = false;
                CTS = new CancellationTokenSource();
                new Action(() => IndexBuilder.Build(CTS)).BeginInvoke(null, null);
                this.btnStop.Enabled = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} id={1} Index building Error：{2}", ex.Message);
                this.btnStart.Enabled = true;
                this.btnStop.Enabled = false;
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine("{0} id={1} Index building stops", DateTime.Now, Thread.CurrentThread.ManagedThreadId);
                if (CTS != null)
                    CTS.Cancel();
                this.btnStart.Enabled = true;
                this.btnStop.Enabled = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} id={1} Index building stops Error：{2}", DateTime.Now, Thread.CurrentThread.ManagedThreadId, ex.Message);
                this.btnStart.Enabled = true;
                this.btnStop.Enabled = false;
            }
        }


        #endregion

        #region Start / Stop WCF
        private void btnStartWCF_Click(object sender, EventArgs e)
        {
            try
            {
                WCFInit.Start();
                this.btnStartWCF.Enabled = false;
                this.btnStopWCF.Enabled = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} id={1} WCF Start Error：{2}", DateTime.Now, Thread.CurrentThread.ManagedThreadId, ex.Message);
                this.btnStartWCF.Enabled = true;
                this.btnStopWCF.Enabled = false;
            }
        }

        private void btnStopWCF_Click(object sender, EventArgs e)
        {
            try
            {
                WCFInit.Stop();
                this.btnStartWCF.Enabled = true;
                this.btnStopWCF.Enabled = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} id={1} WCF Stops Error {2}", DateTime.Now, Thread.CurrentThread.ManagedThreadId, ex.Message);
                this.btnStartWCF.Enabled = true;
                this.btnStopWCF.Enabled = false;
            }
        }


        #endregion

        private static int count = 0;
        private void btnWeather_Click(object sender, EventArgs e)
        {
            WeatherService.ForecastServiceSoapClient weatherService = new WeatherService.ForecastServiceSoapClient();

            WeatherService.Weather[] weathers = weatherService.GetWeathers(1001);
            if (weathers.Length > 0)
            {
                int index = count++ % weathers.Length;

                this.lblLoc.Text = weathers[index].City;
                this.picBox_weather.ImageLocation = weathers[index].Icon;
            }


        }
    }
}
