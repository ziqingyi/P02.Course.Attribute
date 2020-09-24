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
using P21.Course.Lottery.Common;

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
            this.IsGoOn = true;
            this.taskList.Clear();
            this.lblRed1.Text = "00";
            this.lblRed2.Text = "00";
            this.lblRed3.Text = "00";
            this.lblRed4.Text = "00";
            this.lblRed5.Text = "00";
            this.lblRed6.Text = "00";
            this.lblBlue1.Text = "00";
            #endregion

            //int i  =new RandomHelper().GetRandomNumber(1,20);

            Thread.Sleep(1000);
            foreach (var control in this.groupBoxDisplay.Controls)  //loop through all controls
            {
                if (control is Label)   // if it's Label
                {
                    Label label = (Label) control;  // convert to Label


                    if (label.Name.Contains("Blue"))
                    {
                        Task blueTask = Task.Run(
                            () =>
                            {
                                try
                                {
                                    while (IsGoOn)
                                    {
                                        //1 get random number, not include upper bound.
                                        int index = new RandomHelper().GetRandomNumDelay(0, BlueNums.Length);
                                        string sNumber = this.BlueNums[index];

                                        //2 refresh window
                                        //this.lblBlue1.Text = sNumber;
                                        //cannot modify control in sub thread. should assign to main thread. 
                                        this.Invoke(new Action(
                                            () =>
                                            {
                                                label.Text = sNumber;
                                            }));

                                        //3 loop

                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                    throw;
                                }

                            }
                        );
                        taskList.Add(blueTask);



                    }
                    else if (label.Name.Contains("Red"))
                    {

                        Task redTask = Task.Run(
                             () =>
                             {
                                 try
                                 {
                                     while (IsGoOn)
                                     {
                                        //1 get random number, not include upper bound.
                                        int index = new RandomHelper().GetRandomNumDelay(0, RedNums.Length);
                                         string sNumber = this.RedNums[index];

                                        //2 refresh window

                                        lock (_Lock)
                                         {
                                             List<string> usedNumberList = this.GetUsedRedNumbers();
                                             if (!usedNumberList.Contains(sNumber))
                                             {
                                                 //the thread who owns the Control's underlying window handle, will run this delegate
                                                 //so below need to use main thread. if at the same time other method are using main thread, lock. 
                                                 this.Invoke(new Action(
                                                     () =>
                                                     {
                                                         label.Text = sNumber;
                                                     }));

                                             }
                                         }


                                        //3 loop

                                    }
                                 }
                                 catch (Exception ex)
                                 {
                                     Console.WriteLine(ex.Message);
                                     throw;
                                 }

                             }
                         );

                        taskList.Add(redTask);
                    }

                }

            }

            Task.Factory.ContinueWhenAll(this.taskList.ToArray(), tArray =>
            {
                //must use main thread to invoke operations to controls, otherwise lock. 
                this.Invoke(new Action(()=>
                    {

                        this.btnStart.Enabled = true;
                        this.btnStop.Enabled = false;
                        this.btnStart.Text = "Start";

                    })
                );
 
                this.ShowResult();

            });

            //delay 5 seconds after start, then  user can stop it, using main to invoke. 
            Task.Delay(5 * 1000).ContinueWith(
                t => 
                { 
                    this.Invoke(
                        new Action(
                        () => 
                        { this.btnStop.Enabled = true; }
                        )
                    );
                }
                );

        


        }

        private static readonly object _Lock = new object();
        private List<string> GetUsedRedNumbers()
        {
            List<string> usedNumberList = new List<string>();
            foreach (Control ctr in groupBoxDisplay.Controls)
            {


                if (ctr is Label)
                {
                    if (    (  (Label)ctr  ).Name.Contains("Red")     )
                    {
                        usedNumberList.Add( ( (Label)ctr ).Text  );
                    }
                }

                
            }

            if (usedNumberList.Distinct<string>().Count() < 6)
            {
                Console.WriteLine("---------has duplicates?-----------");
                usedNumberList.ForEach(s =>
                {
                    Console.WriteLine($"{s}");
                }
                );
            }

            return usedNumberList;
        }







        private void btnStop_Click(object sender, EventArgs e)
        {


            this.IsGoOn = false;

         

            //wait for all tasks completed, must use another thread.
            //if still use main thread execute below, program will be dead lock.
            //because main thread will wait for tasks in list to complete,
            //but threads updating the label need to wait for main thread to assign value. (they are at around lock or executing in the lock)
   
            ////method 1
            //this.btnStart.Enabled = true;
            //this.btnStop.Enabled = false;
            //this.btnStart.Text = "Start";
            //Task.Run(() =>
            //{
            //    Task.WaitAll(taskList.ToArray());

            //    ShowResult();
            //});

            ////method 2, add a call back function to btnStart_Click() 
            //Task.Factory.ContinueWhenAll(this.taskList.ToArray(), tArray =>
            //{
            //    //ShowResult() and Enable buttons when everything finish
            //});
        }


        private void ShowResult()
        {
            MessageBox.Show(string.Format("the Red Balls are: {0} {1} {2} {3} {4} {5}  Blue Ball:{6}"
                , this.lblRed1.Text
                , this.lblRed2.Text
                , this.lblRed3.Text
                , this.lblRed4.Text
                , this.lblRed5.Text
                , this.lblRed6.Text
                , this.lblBlue1.Text));
        }

    }
}
