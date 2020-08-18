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
            this.btnThreadPoolLock = new System.Windows.Forms.Button();
            this.btnTask = new System.Windows.Forms.Button();
            this.btnTaskDelay = new System.Windows.Forms.Button();
            this.btnTask_Teach_Proj = new System.Windows.Forms.Button();
            this.btnTask_LimitNumOfTasks = new System.Windows.Forms.Button();
            this.btnParallel = new System.Windows.Forms.Button();
            this.btnParallel_no_block = new System.Windows.Forms.Button();
            this.btnThreadCore_Exception = new System.Windows.Forms.Button();
            this.btnThreadCore_CancellationTokenSource = new System.Windows.Forms.Button();
            this.btnThreadCore_Variable = new System.Windows.Forms.Button();
            this.btnThreadCore_ThreadSafety = new System.Windows.Forms.Button();
            this.btnThreadCore_LockThis = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSync
            // 
            this.btnSync.Location = new System.Drawing.Point(12, 53);
            this.btnSync.Name = "btnSync";
            this.btnSync.Size = new System.Drawing.Size(75, 23);
            this.btnSync.TabIndex = 0;
            this.btnSync.Text = "Sync";
            this.btnSync.UseVisualStyleBackColor = true;
            this.btnSync.Click += new System.EventHandler(this.btnSync_Click);
            // 
            // btnAsync
            // 
            this.btnAsync.Location = new System.Drawing.Point(12, 107);
            this.btnAsync.Name = "btnAsync";
            this.btnAsync.Size = new System.Drawing.Size(75, 23);
            this.btnAsync.TabIndex = 1;
            this.btnAsync.Text = "Async";
            this.btnAsync.UseVisualStyleBackColor = true;
            this.btnAsync.Click += new System.EventHandler(this.btnAsync_Click);
            // 
            // btnAsyncAdvanced
            // 
            this.btnAsyncAdvanced.Location = new System.Drawing.Point(12, 152);
            this.btnAsyncAdvanced.Name = "btnAsyncAdvanced";
            this.btnAsyncAdvanced.Size = new System.Drawing.Size(148, 23);
            this.btnAsyncAdvanced.TabIndex = 2;
            this.btnAsyncAdvanced.Text = "AsyncAdvanced";
            this.btnAsyncAdvanced.UseVisualStyleBackColor = true;
            this.btnAsyncAdvanced.Click += new System.EventHandler(this.btnAsyncAdvanced_Click);
            // 
            // btnAsyncAdvanced2_IAsyncResult
            // 
            this.btnAsyncAdvanced2_IAsyncResult.Location = new System.Drawing.Point(12, 204);
            this.btnAsyncAdvanced2_IAsyncResult.Name = "btnAsyncAdvanced2_IAsyncResult";
            this.btnAsyncAdvanced2_IAsyncResult.Size = new System.Drawing.Size(197, 23);
            this.btnAsyncAdvanced2_IAsyncResult.TabIndex = 3;
            this.btnAsyncAdvanced2_IAsyncResult.Text = "AsyncAdvanced2_IAsyncResult";
            this.btnAsyncAdvanced2_IAsyncResult.UseVisualStyleBackColor = true;
            this.btnAsyncAdvanced2_IAsyncResult.Click += new System.EventHandler(this.btnAsyncAdvanced2_IAsyncResult_Click);
            // 
            // btnAsyncAdvanced3_WaitOne
            // 
            this.btnAsyncAdvanced3_WaitOne.Location = new System.Drawing.Point(12, 265);
            this.btnAsyncAdvanced3_WaitOne.Name = "btnAsyncAdvanced3_WaitOne";
            this.btnAsyncAdvanced3_WaitOne.Size = new System.Drawing.Size(178, 23);
            this.btnAsyncAdvanced3_WaitOne.TabIndex = 4;
            this.btnAsyncAdvanced3_WaitOne.Text = "AsyncAdvanced3_WaitOne";
            this.btnAsyncAdvanced3_WaitOne.UseVisualStyleBackColor = true;
            this.btnAsyncAdvanced3_WaitOne.Click += new System.EventHandler(this.btnAsyncAdvanced3_WaitOne_Click);
            // 
            // btnAsyncAdvanced4_EndInvoke
            // 
            this.btnAsyncAdvanced4_EndInvoke.Location = new System.Drawing.Point(12, 322);
            this.btnAsyncAdvanced4_EndInvoke.Name = "btnAsyncAdvanced4_EndInvoke";
            this.btnAsyncAdvanced4_EndInvoke.Size = new System.Drawing.Size(178, 23);
            this.btnAsyncAdvanced4_EndInvoke.TabIndex = 5;
            this.btnAsyncAdvanced4_EndInvoke.Text = "AsyncAdvanced4_EndInvoke";
            this.btnAsyncAdvanced4_EndInvoke.UseVisualStyleBackColor = true;
            this.btnAsyncAdvanced4_EndInvoke.Click += new System.EventHandler(this.btnAsyncAdvanced4_EndInvoke_Click);
            // 
            // btnThread
            // 
            this.btnThread.Location = new System.Drawing.Point(238, 30);
            this.btnThread.Name = "btnThread";
            this.btnThread.Size = new System.Drawing.Size(75, 25);
            this.btnThread.TabIndex = 6;
            this.btnThread.Text = "Thread";
            this.btnThread.UseVisualStyleBackColor = true;
            this.btnThread.Click += new System.EventHandler(this.btnThread_Click);
            // 
            // btnThread_CallBack
            // 
            this.btnThread_CallBack.Location = new System.Drawing.Point(238, 83);
            this.btnThread_CallBack.Name = "btnThread_CallBack";
            this.btnThread_CallBack.Size = new System.Drawing.Size(154, 25);
            this.btnThread_CallBack.TabIndex = 7;
            this.btnThread_CallBack.Text = "Thead_CallBack";
            this.btnThread_CallBack.UseVisualStyleBackColor = true;
            this.btnThread_CallBack.Click += new System.EventHandler(this.btnThread_CallBack_Click);
            // 
            // btnThread_CallBack_Return
            // 
            this.btnThread_CallBack_Return.Location = new System.Drawing.Point(238, 135);
            this.btnThread_CallBack_Return.Name = "btnThread_CallBack_Return";
            this.btnThread_CallBack_Return.Size = new System.Drawing.Size(158, 25);
            this.btnThread_CallBack_Return.TabIndex = 8;
            this.btnThread_CallBack_Return.Text = "Thread_CallBack_Return";
            this.btnThread_CallBack_Return.UseVisualStyleBackColor = true;
            this.btnThread_CallBack_Return.Click += new System.EventHandler(this.btnThread_CallBack_Return_Click);
            // 
            // btnTheadCount
            // 
            this.btnTheadCount.Location = new System.Drawing.Point(238, 187);
            this.btnTheadCount.Name = "btnTheadCount";
            this.btnTheadCount.Size = new System.Drawing.Size(134, 25);
            this.btnTheadCount.TabIndex = 9;
            this.btnTheadCount.Text = "Thread_Count";
            this.btnTheadCount.UseVisualStyleBackColor = true;
            this.btnTheadCount.Click += new System.EventHandler(this.btnTheadCount_Click);
            // 
            // btnThreadPool
            // 
            this.btnThreadPool.Location = new System.Drawing.Point(234, 320);
            this.btnThreadPool.Name = "btnThreadPool";
            this.btnThreadPool.Size = new System.Drawing.Size(158, 25);
            this.btnThreadPool.TabIndex = 10;
            this.btnThreadPool.Text = "Thread_pool";
            this.btnThreadPool.UseVisualStyleBackColor = true;
            this.btnThreadPool.Click += new System.EventHandler(this.btnThreadPool_Click);
            // 
            // btnThreadPool_MaxMin
            // 
            this.btnThreadPool_MaxMin.Location = new System.Drawing.Point(234, 373);
            this.btnThreadPool_MaxMin.Name = "btnThreadPool_MaxMin";
            this.btnThreadPool_MaxMin.Size = new System.Drawing.Size(158, 25);
            this.btnThreadPool_MaxMin.TabIndex = 11;
            this.btnThreadPool_MaxMin.Text = "Thread Pool Max/Min";
            this.btnThreadPool_MaxMin.UseVisualStyleBackColor = true;
            this.btnThreadPool_MaxMin.Click += new System.EventHandler(this.btnThreadPool_MaxMin_Click);
            // 
            // btnThreadPoolLock
            // 
            this.btnThreadPoolLock.Location = new System.Drawing.Point(234, 425);
            this.btnThreadPoolLock.Name = "btnThreadPoolLock";
            this.btnThreadPoolLock.Size = new System.Drawing.Size(158, 23);
            this.btnThreadPoolLock.TabIndex = 12;
            this.btnThreadPoolLock.Text = "Thread Pool deadLock";
            this.btnThreadPoolLock.UseVisualStyleBackColor = true;
            this.btnThreadPoolLock.Click += new System.EventHandler(this.btnThreadPoolLock_Click);
            // 
            // btnTask
            // 
            this.btnTask.Location = new System.Drawing.Point(432, 30);
            this.btnTask.Name = "btnTask";
            this.btnTask.Size = new System.Drawing.Size(75, 25);
            this.btnTask.TabIndex = 13;
            this.btnTask.Text = "Task";
            this.btnTask.UseVisualStyleBackColor = true;
            this.btnTask.Click += new System.EventHandler(this.btnTask_Click);
            // 
            // btnTaskDelay
            // 
            this.btnTaskDelay.Location = new System.Drawing.Point(432, 138);
            this.btnTaskDelay.Name = "btnTaskDelay";
            this.btnTaskDelay.Size = new System.Drawing.Size(93, 23);
            this.btnTaskDelay.TabIndex = 14;
            this.btnTaskDelay.Text = "Task_Delay";
            this.btnTaskDelay.UseVisualStyleBackColor = true;
            this.btnTaskDelay.Click += new System.EventHandler(this.btnTaskDelay_Click);
            // 
            // btnTask_Teach_Proj
            // 
            this.btnTask_Teach_Proj.Location = new System.Drawing.Point(432, 190);
            this.btnTask_Teach_Proj.Name = "btnTask_Teach_Proj";
            this.btnTask_Teach_Proj.Size = new System.Drawing.Size(122, 25);
            this.btnTask_Teach_Proj.TabIndex = 15;
            this.btnTask_Teach_Proj.Text = "Task_Teach_Proj";
            this.btnTask_Teach_Proj.UseVisualStyleBackColor = true;
            this.btnTask_Teach_Proj.Click += new System.EventHandler(this.btnTask_Teach_Proj_Click);
            // 
            // btnTask_LimitNumOfTasks
            // 
            this.btnTask_LimitNumOfTasks.Location = new System.Drawing.Point(432, 83);
            this.btnTask_LimitNumOfTasks.Name = "btnTask_LimitNumOfTasks";
            this.btnTask_LimitNumOfTasks.Size = new System.Drawing.Size(148, 25);
            this.btnTask_LimitNumOfTasks.TabIndex = 16;
            this.btnTask_LimitNumOfTasks.Text = "Task_LimitNumOfTasks";
            this.btnTask_LimitNumOfTasks.UseVisualStyleBackColor = true;
            this.btnTask_LimitNumOfTasks.Click += new System.EventHandler(this.btnTask_LimitNumOfTasks_Click);
            // 
            // btnParallel
            // 
            this.btnParallel.Location = new System.Drawing.Point(432, 265);
            this.btnParallel.Name = "btnParallel";
            this.btnParallel.Size = new System.Drawing.Size(122, 25);
            this.btnParallel.TabIndex = 17;
            this.btnParallel.Text = "Parallel";
            this.btnParallel.UseVisualStyleBackColor = true;
            this.btnParallel.Click += new System.EventHandler(this.btnParallel_Click);
            // 
            // btnParallel_no_block
            // 
            this.btnParallel_no_block.Location = new System.Drawing.Point(432, 320);
            this.btnParallel_no_block.Name = "btnParallel_no_block";
            this.btnParallel_no_block.Size = new System.Drawing.Size(172, 25);
            this.btnParallel_no_block.TabIndex = 18;
            this.btnParallel_no_block.Text = "Parallel_no_block";
            this.btnParallel_no_block.UseVisualStyleBackColor = true;
            this.btnParallel_no_block.Click += new System.EventHandler(this.btnParallel_no_block_Click);
            // 
            // btnThreadCore_Exception
            // 
            this.btnThreadCore_Exception.Location = new System.Drawing.Point(640, 30);
            this.btnThreadCore_Exception.Name = "btnThreadCore_Exception";
            this.btnThreadCore_Exception.Size = new System.Drawing.Size(158, 25);
            this.btnThreadCore_Exception.TabIndex = 19;
            this.btnThreadCore_Exception.Text = "ThreadCore_Exception";
            this.btnThreadCore_Exception.UseVisualStyleBackColor = true;
            this.btnThreadCore_Exception.Click += new System.EventHandler(this.btnThreadCore_Exception_Click);
            // 
            // btnThreadCore_CancellationTokenSource
            // 
            this.btnThreadCore_CancellationTokenSource.Location = new System.Drawing.Point(640, 83);
            this.btnThreadCore_CancellationTokenSource.Name = "btnThreadCore_CancellationTokenSource";
            this.btnThreadCore_CancellationTokenSource.Size = new System.Drawing.Size(255, 25);
            this.btnThreadCore_CancellationTokenSource.TabIndex = 20;
            this.btnThreadCore_CancellationTokenSource.Text = "ThreadCore_CancellationTokenSource";
            this.btnThreadCore_CancellationTokenSource.UseVisualStyleBackColor = true;
            this.btnThreadCore_CancellationTokenSource.Click += new System.EventHandler(this.btnThreadCore_CancellationTokenSource_Click);
            // 
            // btnThreadCore_Variable
            // 
            this.btnThreadCore_Variable.Location = new System.Drawing.Point(640, 150);
            this.btnThreadCore_Variable.Name = "btnThreadCore_Variable";
            this.btnThreadCore_Variable.Size = new System.Drawing.Size(181, 25);
            this.btnThreadCore_Variable.TabIndex = 21;
            this.btnThreadCore_Variable.Text = "ThreadCore_Variable";
            this.btnThreadCore_Variable.UseVisualStyleBackColor = true;
            this.btnThreadCore_Variable.Click += new System.EventHandler(this.btnThreadCore_Variable_Click);
            // 
            // btnThreadCore_ThreadSafety
            // 
            this.btnThreadCore_ThreadSafety.Location = new System.Drawing.Point(640, 215);
            this.btnThreadCore_ThreadSafety.Name = "btnThreadCore_ThreadSafety";
            this.btnThreadCore_ThreadSafety.Size = new System.Drawing.Size(192, 25);
            this.btnThreadCore_ThreadSafety.TabIndex = 22;
            this.btnThreadCore_ThreadSafety.Text = "ThreadCore_ThreadSafety";
            this.btnThreadCore_ThreadSafety.UseVisualStyleBackColor = true;
            this.btnThreadCore_ThreadSafety.Click += new System.EventHandler(this.btnThreadCore_ThreadSafety_Click);
            // 
            // btnThreadCore_LockThis
            // 
            this.btnThreadCore_LockThis.Location = new System.Drawing.Point(640, 265);
            this.btnThreadCore_LockThis.Name = "btnThreadCore_LockThis";
            this.btnThreadCore_LockThis.Size = new System.Drawing.Size(192, 25);
            this.btnThreadCore_LockThis.TabIndex = 23;
            this.btnThreadCore_LockThis.Text = "ThreadCore_LockThis";
            this.btnThreadCore_LockThis.UseVisualStyleBackColor = true;
            this.btnThreadCore_LockThis.Click += new System.EventHandler(this.ThreadCore_LockThis_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 498);
            this.Controls.Add(this.btnThreadCore_LockThis);
            this.Controls.Add(this.btnThreadCore_ThreadSafety);
            this.Controls.Add(this.btnThreadCore_Variable);
            this.Controls.Add(this.btnThreadCore_CancellationTokenSource);
            this.Controls.Add(this.btnThreadCore_Exception);
            this.Controls.Add(this.btnParallel_no_block);
            this.Controls.Add(this.btnParallel);
            this.Controls.Add(this.btnTask_LimitNumOfTasks);
            this.Controls.Add(this.btnTask_Teach_Proj);
            this.Controls.Add(this.btnTaskDelay);
            this.Controls.Add(this.btnTask);
            this.Controls.Add(this.btnThreadPoolLock);
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
        private System.Windows.Forms.Button btnThreadPoolLock;
        private System.Windows.Forms.Button btnTask;
        private System.Windows.Forms.Button btnTaskDelay;
        private System.Windows.Forms.Button btnTask_Teach_Proj;
        private System.Windows.Forms.Button btnTask_LimitNumOfTasks;
        private System.Windows.Forms.Button btnParallel;
        private System.Windows.Forms.Button btnParallel_no_block;
        private System.Windows.Forms.Button btnThreadCore_Exception;
        private System.Windows.Forms.Button btnThreadCore_CancellationTokenSource;
        private System.Windows.Forms.Button btnThreadCore_Variable;
        private System.Windows.Forms.Button btnThreadCore_ThreadSafety;
        private System.Windows.Forms.Button btnThreadCore_LockThis;
    }
}

