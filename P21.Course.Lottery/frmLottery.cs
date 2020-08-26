using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P21.Course.Lottery
{
    public partial class frmLottery : Form
    {
        public frmLottery()
        {
            InitializeComponent();
            this.btnStart.Enabled = true;
            this.btnStop.Enabled = false;
        }

        private string[] RedNums =
        {
            "01","02","03","04","05","06","07","08","09","10",
            "11","12","13","14","15","16","17","18","19","20",
            "21","22","23","24","25","26","27","28","29","30",
            "31","32","33"
        };

        private string[] BlueNums =
        {
            "01","02","03","04","05","06","07","08","09","10",
            "11","12","13","14","15","16"
        };

        private bool IsGoOn = true;
        private List<Task> taskList = new List<Task>();

        private void btnStart_Click(object sender, EventArgs e)
        {
            #region initial steps

            this.btnStart.Text = "running";
            this.btnStart.Enabled = false;

            this.lblRed1.Text = "00";
            this.lblRed2.Text = "00";
            this.lblRed3.Text = "00";
            this.lblRed4.Text = "00";
            this.lblRed5.Text = "00";
            this.lblRed6.Text = "00";
            this.lblBlue1.Text = "00";
            #endregion
            Thread.Sleep(1000);
            foreach (var control in this.groupBoxDisplay.Controls)
            {
                if (control is Label)
                {
                    Label label = (Label) control;
                    if (label.Name.Contains("Blue"))
                    {


                        //1 get random number

                        //2 refresh window


                        //3 loop
                    }



                }

            }





        }

        private void btnStop_Click(object sender, EventArgs e)
        {

        }
    }
}
