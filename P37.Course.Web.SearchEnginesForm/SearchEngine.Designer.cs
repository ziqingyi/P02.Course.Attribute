namespace P37.Course.Web.SearchEnginesForm
{
    partial class SearchEngine
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gboIndex = new System.Windows.Forms.GroupBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.gboSearcher = new System.Windows.Forms.GroupBox();
            this.btnStopWCF = new System.Windows.Forms.Button();
            this.btnStartWCF = new System.Windows.Forms.Button();
            this.lblLoc = new System.Windows.Forms.Label();
            this.picBox_weather = new System.Windows.Forms.PictureBox();
            this.btnWeather = new System.Windows.Forms.Button();
            this.gboIndex.SuspendLayout();
            this.gboSearcher.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_weather)).BeginInit();
            this.SuspendLayout();
            // 
            // gboIndex
            // 
            this.gboIndex.Controls.Add(this.btnStop);
            this.gboIndex.Controls.Add(this.btnStart);
            this.gboIndex.Location = new System.Drawing.Point(134, 91);
            this.gboIndex.Name = "gboIndex";
            this.gboIndex.Size = new System.Drawing.Size(188, 100);
            this.gboIndex.TabIndex = 1;
            this.gboIndex.TabStop = false;
            this.gboIndex.Text = "Lucene Index";
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(102, 43);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 25);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(6, 43);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 25);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // gboSearcher
            // 
            this.gboSearcher.Controls.Add(this.btnStopWCF);
            this.gboSearcher.Controls.Add(this.btnStartWCF);
            this.gboSearcher.Location = new System.Drawing.Point(134, 248);
            this.gboSearcher.Name = "gboSearcher";
            this.gboSearcher.Size = new System.Drawing.Size(200, 108);
            this.gboSearcher.TabIndex = 2;
            this.gboSearcher.TabStop = false;
            this.gboSearcher.Text = "Search Service";
            // 
            // btnStopWCF
            // 
            this.btnStopWCF.Location = new System.Drawing.Point(102, 48);
            this.btnStopWCF.Name = "btnStopWCF";
            this.btnStopWCF.Size = new System.Drawing.Size(75, 25);
            this.btnStopWCF.TabIndex = 1;
            this.btnStopWCF.Text = "Stop";
            this.btnStopWCF.UseVisualStyleBackColor = true;
            this.btnStopWCF.Click += new System.EventHandler(this.btnStopWCF_Click);
            // 
            // btnStartWCF
            // 
            this.btnStartWCF.Location = new System.Drawing.Point(6, 48);
            this.btnStartWCF.Name = "btnStartWCF";
            this.btnStartWCF.Size = new System.Drawing.Size(75, 25);
            this.btnStartWCF.TabIndex = 0;
            this.btnStartWCF.Text = "Start";
            this.btnStartWCF.UseVisualStyleBackColor = true;
            this.btnStartWCF.Click += new System.EventHandler(this.btnStartWCF_Click);
            // 
            // lblLoc
            // 
            this.lblLoc.AutoSize = true;
            this.lblLoc.Location = new System.Drawing.Point(134, 13);
            this.lblLoc.Name = "lblLoc";
            this.lblLoc.Size = new System.Drawing.Size(48, 13);
            this.lblLoc.TabIndex = 3;
            this.lblLoc.Text = "Location";
            // 
            // picBox_weather
            // 
            this.picBox_weather.Location = new System.Drawing.Point(12, 13);
            this.picBox_weather.Name = "picBox_weather";
            this.picBox_weather.Size = new System.Drawing.Size(102, 83);
            this.picBox_weather.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBox_weather.TabIndex = 4;
            this.picBox_weather.TabStop = false;
            // 
            // btnWeather
            // 
            this.btnWeather.Location = new System.Drawing.Point(235, 13);
            this.btnWeather.Name = "btnWeather";
            this.btnWeather.Size = new System.Drawing.Size(75, 23);
            this.btnWeather.TabIndex = 5;
            this.btnWeather.Text = "Weather";
            this.btnWeather.UseVisualStyleBackColor = true;
            this.btnWeather.Click += new System.EventHandler(this.btnWeather_Click);
            // 
            // SearchEngine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 447);
            this.Controls.Add(this.btnWeather);
            this.Controls.Add(this.picBox_weather);
            this.Controls.Add(this.lblLoc);
            this.Controls.Add(this.gboSearcher);
            this.Controls.Add(this.gboIndex);
            this.Name = "SearchEngine";
            this.Text = "SearchEngine";
            this.gboIndex.ResumeLayout(false);
            this.gboSearcher.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBox_weather)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gboIndex;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.GroupBox gboSearcher;
        private System.Windows.Forms.Button btnStopWCF;
        private System.Windows.Forms.Button btnStartWCF;
        private System.Windows.Forms.Label lblLoc;
        private System.Windows.Forms.PictureBox picBox_weather;
        private System.Windows.Forms.Button btnWeather;
    }
}

