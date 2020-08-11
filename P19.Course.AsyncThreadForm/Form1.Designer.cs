namespace P19.Course.AsyncThreadForm
{
    partial class Form1
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
            this.btnSync = new System.Windows.Forms.Button();
            this.btnAsync = new System.Windows.Forms.Button();
            this.btnAsyncAdvanced = new System.Windows.Forms.Button();
            this.btnAsyncAdvanced2_IAsyncResult = new System.Windows.Forms.Button();
            this.btnAsyncAdvanced3_WaitOne = new System.Windows.Forms.Button();
            this.btnAsyncAdvanced4_EndInvoke = new System.Windows.Forms.Button();
            this.btnThread = new System.Windows.Forms.Button();
            this.btnThread_CallBack = new System.Windows.Forms.Button();
            this.btnThread_CallBack_Return = new System.Windows.Forms.Button();
            this.btnTheadCount = new System.Windows.Forms.Button();
            this.btnThreadPool = new System.Windows.Forms.Button();
            this.btnThreadPool_MaxMin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSync
            // 
            this.btnSync.Location = new System.Drawing.Point(12, 49);
            this.btnSync.Name = "btnSync";
            this.btnSync.Size = new System.Drawing.Size(75, 21);
            this.btnSync.TabIndex = 0;
            this.btnSync.Text = "Sync";
            this.btnSync.UseVisualStyleBackColor = true;
            this.btnSync.Click += new System.EventHandler(this.btnSync_Click);
            // 
            // btnAsync
            // 
            this.btnAsync.Location = new System.Drawing.Point(12, 99);
            this.btnAsync.Name = "btnAsync";
            this.btnAsync.Size = new System.Drawing.Size(75, 21);
            this.btnAsync.TabIndex = 1;
            this.btnAsync.Text = "Async";
            this.btnAsync.UseVisualStyleBackColor = true;
            this.btnAsync.Click += new System.EventHandler(this.btnAsync_Click);
            // 
            // btnAsyncAdvanced
            // 
            this.btnAsyncAdvanced.Location = new System.Drawing.Point(12, 154);
            this.btnAsyncAdvanced.Name = "btnAsyncAdvanced";
            this.btnAsyncAdvanced.Size = new System.Drawing.Size(148, 21);
            this.btnAsyncAdvanced.TabIndex = 2;
            this.btnAsyncAdvanced.Text = "AsyncAdvanced";
            this.btnAsyncAdvanced.UseVisualStyleBackColor = true;
            this.btnAsyncAdvanced.Click += new System.EventHandler(this.btnAsyncAdvanced_Click);
            // 
            // btnAsyncAdvanced2_IAsyncResult
            // 
            this.btnAsyncAdvanced2_IAsyncResult.Location = new System.Drawing.Point(12, 199);
            this.btnAsyncAdvanced2_IAsyncResult.Name = "btnAsyncAdvanced2_IAsyncResult";
            this.btnAsyncAdvanced2_IAsyncResult.Size = new System.Drawing.Size(197, 21);
            this.btnAsyncAdvanced2_IAsyncResult.TabIndex = 3;
            this.btnAsyncAdvanced2_IAsyncResult.Text = "AsyncAdvanced2_IAsyncResult";
            this.btnAsyncAdvanced2_IAsyncResult.UseVisualStyleBackColor = true;
            this.btnAsyncAdvanced2_IAsyncResult.Click += new System.EventHandler(this.btnAsyncAdvanced2_IAsyncResult_Click);
            // 
            // btnAsyncAdvanced3_WaitOne
            // 
            this.btnAsyncAdvanced3_WaitOne.Location = new System.Drawing.Point(12, 251);
            this.btnAsyncAdvanced3_WaitOne.Name = "btnAsyncAdvanced3_WaitOne";
            this.btnAsyncAdvanced3_WaitOne.Size = new System.Drawing.Size(178, 21);
            this.btnAsyncAdvanced3_WaitOne.TabIndex = 4;
            this.btnAsyncAdvanced3_WaitOne.Text = "AsyncAdvanced3_WaitOne";
            this.btnAsyncAdvanced3_WaitOne.UseVisualStyleBackColor = true;
            this.btnAsyncAdvanced3_WaitOne.Click += new System.EventHandler(this.btnAsyncAdvanced3_WaitOne_Click);
            // 
            // btnAsyncAdvanced4_EndInvoke
            // 
            this.btnAsyncAdvanced4_EndInvoke.Location = new System.Drawing.Point(12, 311);
            this.btnAsyncAdvanced4_EndInvoke.Name = "btnAsyncAdvanced4_EndInvoke";
            this.btnAsyncAdvanced4_EndInvoke.Size = new System.Drawing.Size(178, 21);
            this.btnAsyncAdvanced4_EndInvoke.TabIndex = 5;
            this.btnAsyncAdvanced4_EndInvoke.Text = "AsyncAdvanced4_EndInvoke";
            this.btnAsyncAdvanced4_EndInvoke.UseVisualStyleBackColor = true;
            this.btnAsyncAdvanced4_EndInvoke.Click += new System.EventHandler(this.btnAsyncAdvanced4_EndInvoke_Click);
            // 
            // btnThread
            // 
            this.btnThread.Location = new System.Drawing.Point(238, 28);
            this.btnThread.Name = "btnThread";
            this.btnThread.Size = new System.Drawing.Size(75, 23);
            this.btnThread.TabIndex = 6;
            this.btnThread.Text = "Thread";
            this.btnThread.UseVisualStyleBackColor = true;
            this.btnThread.Click += new System.EventHandler(this.btnThread_Click);
            // 
            // btnThread_CallBack
            // 
            this.btnThread_CallBack.Location = new System.Drawing.Point(238, 77);
            this.btnThread_CallBack.Name = "btnThread_CallBack";
            this.btnThread_CallBack.Size = new System.Drawing.Size(154, 23);
            this.btnThread_CallBack.TabIndex = 7;
            this.btnThread_CallBack.Text = "Thead_CallBack";
            this.btnThread_CallBack.UseVisualStyleBackColor = true;
            this.btnThread_CallBack.Click += new System.EventHandler(this.btnThread_CallBack_Click);
            // 
            // btnThread_CallBack_Return
            // 
            this.btnThread_CallBack_Return.Location = new System.Drawing.Point(238, 125);
            this.btnThread_CallBack_Return.Name = "btnThread_CallBack_Return";
            this.btnThread_CallBack_Return.Size = new System.Drawing.Size(158, 23);
            this.btnThread_CallBack_Return.TabIndex = 8;
            this.btnThread_CallBack_Return.Text = "Thread_CallBack_Return";
            this.btnThread_CallBack_Return.UseVisualStyleBackColor = true;
            this.btnThread_CallBack_Return.Click += new System.EventHandler(this.btnThread_CallBack_Return_Click);
            // 
            // btnTheadCount
            // 
            this.btnTheadCount.Location = new System.Drawing.Point(238, 173);
            this.btnTheadCount.Name = "btnTheadCount";
            this.btnTheadCount.Size = new System.Drawing.Size(134, 23);
            this.btnTheadCount.TabIndex = 9;
            this.btnTheadCount.Text = "Thread_Count";
            this.btnTheadCount.UseVisualStyleBackColor = true;
            this.btnTheadCount.Click += new System.EventHandler(this.btnTheadCount_Click);
            // 
            // btnThreadPool
            // 
            this.btnThreadPool.Location = new System.Drawing.Point(443, 77);
            this.btnThreadPool.Name = "btnThreadPool";
            this.btnThreadPool.Size = new System.Drawing.Size(158, 23);
            this.btnThreadPool.TabIndex = 10;
            this.btnThreadPool.Text = "Thread_pool";
            this.btnThreadPool.UseVisualStyleBackColor = true;
            this.btnThreadPool.Click += new System.EventHandler(this.btnThreadPool_Click);
            // 
            // btnThreadPool_MaxMin
            // 
            this.btnThreadPool_MaxMin.Location = new System.Drawing.Point(443, 28);
            this.btnThreadPool_MaxMin.Name = "btnThreadPool_MaxMin";
            this.btnThreadPool_MaxMin.Size = new System.Drawing.Size(158, 23);
            this.btnThreadPool_MaxMin.TabIndex = 11;
            this.btnThreadPool_MaxMin.Text = "Thread Pool Max/Min";
            this.btnThreadPool_MaxMin.UseVisualStyleBackColor = true;
            this.btnThreadPool_MaxMin.Click += new System.EventHandler(this.btnThreadPool_MaxMin_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 415);
            this.Controls.Add(this.btnThreadPool_MaxMin);
            this.Controls.Add(this.btnThreadPool);
            this.Controls.Add(this.btnTheadCount);
            this.Controls.Add(this.btnThread_CallBack_Return);
            this.Controls.Add(this.btnThread_CallBack);
            this.Controls.Add(this.btnThread);
            this.Controls.Add(this.btnAsyncAdvanced4_EndInvoke);
            this.Controls.Add(this.btnAsyncAdvanced3_WaitOne);
            this.Controls.Add(this.btnAsyncAdvanced2_IAsyncResult);
            this.Controls.Add(this.btnAsyncAdvanced);
            this.Controls.Add(this.btnAsync);
            this.Controls.Add(this.btnSync);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSync;
        private System.Windows.Forms.Button btnAsync;
        private System.Windows.Forms.Button btnAsyncAdvanced;
        private System.Windows.Forms.Button btnAsyncAdvanced2_IAsyncResult;
        private System.Windows.Forms.Button btnAsyncAdvanced3_WaitOne;
        private System.Windows.Forms.Button btnAsyncAdvanced4_EndInvoke;
        private System.Windows.Forms.Button btnThread;
        private System.Windows.Forms.Button btnThread_CallBack;
        private System.Windows.Forms.Button btnThread_CallBack_Return;
        private System.Windows.Forms.Button btnTheadCount;
        private System.Windows.Forms.Button btnThreadPool;
        private System.Windows.Forms.Button btnThreadPool_MaxMin;
    }
}

