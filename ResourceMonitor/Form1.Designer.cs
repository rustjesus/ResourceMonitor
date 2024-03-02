namespace ResourceMonitor
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.labelCPU = new System.Windows.Forms.Label();
            this.labelDisk = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.labelMem = new System.Windows.Forms.Label();
            this.labelUsedDiskSpace = new System.Windows.Forms.Label();
            this.labelAvailableDiskSpace = new System.Windows.Forms.Label();
            this.totalMem = new System.Windows.Forms.Label();
            this.mempercentLabel = new System.Windows.Forms.Label();
            this.labelMem2 = new System.Windows.Forms.Label();
            this.progressBarCPU = new System.Windows.Forms.ProgressBar();
            this.ram_memory_progressBar1 = new System.Windows.Forms.ProgressBar();
            this.usedDisk_progressBar1 = new System.Windows.Forms.ProgressBar();
            this.gpuUsedPercent_label1 = new System.Windows.Forms.Label();
            this.gpu_progressBar1 = new System.Windows.Forms.ProgressBar();
            this.verlabel1 = new System.Windows.Forms.Label();
            this.cpuTemp_label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelCPU
            // 
            this.labelCPU.AutoSize = true;
            this.labelCPU.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCPU.Location = new System.Drawing.Point(117, 21);
            this.labelCPU.Name = "labelCPU";
            this.labelCPU.Size = new System.Drawing.Size(125, 13);
            this.labelCPU.TabIndex = 0;
            this.labelCPU.Text = "Cpu Usage: 100.00%";
            // 
            // labelDisk
            // 
            this.labelDisk.AutoSize = true;
            this.labelDisk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDisk.Location = new System.Drawing.Point(118, 144);
            this.labelDisk.Name = "labelDisk";
            this.labelDisk.Size = new System.Drawing.Size(110, 13);
            this.labelDisk.TabIndex = 1;
            this.labelDisk.Text = "Disk Usage: 100%";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // labelMem
            // 
            this.labelMem.AutoSize = true;
            this.labelMem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMem.Location = new System.Drawing.Point(118, 96);
            this.labelMem.Name = "labelMem";
            this.labelMem.Size = new System.Drawing.Size(107, 13);
            this.labelMem.TabIndex = 2;
            this.labelMem.Text = "Avail Memory: GB";
            // 
            // labelUsedDiskSpace
            // 
            this.labelUsedDiskSpace.AutoSize = true;
            this.labelUsedDiskSpace.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsedDiskSpace.Location = new System.Drawing.Point(118, 170);
            this.labelUsedDiskSpace.Name = "labelUsedDiskSpace";
            this.labelUsedDiskSpace.Size = new System.Drawing.Size(161, 13);
            this.labelUsedDiskSpace.TabIndex = 3;
            this.labelUsedDiskSpace.Text = "Used Disk Space: 100.00%";
            // 
            // labelAvailableDiskSpace
            // 
            this.labelAvailableDiskSpace.AutoSize = true;
            this.labelAvailableDiskSpace.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAvailableDiskSpace.Location = new System.Drawing.Point(117, 157);
            this.labelAvailableDiskSpace.Name = "labelAvailableDiskSpace";
            this.labelAvailableDiskSpace.Size = new System.Drawing.Size(184, 13);
            this.labelAvailableDiskSpace.TabIndex = 4;
            this.labelAvailableDiskSpace.Text = "Available Disk Space: 100.00%";
            // 
            // totalMem
            // 
            this.totalMem.AutoSize = true;
            this.totalMem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalMem.Location = new System.Drawing.Point(118, 109);
            this.totalMem.Name = "totalMem";
            this.totalMem.Size = new System.Drawing.Size(108, 13);
            this.totalMem.TabIndex = 5;
            this.totalMem.Text = "Total Memory: GB";
            // 
            // mempercentLabel
            // 
            this.mempercentLabel.AutoSize = true;
            this.mempercentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mempercentLabel.Location = new System.Drawing.Point(117, 122);
            this.mempercentLabel.Name = "mempercentLabel";
            this.mempercentLabel.Size = new System.Drawing.Size(139, 13);
            this.mempercentLabel.TabIndex = 6;
            this.mempercentLabel.Text = "Memory Used: 100.00%";
            // 
            // labelMem2
            // 
            this.labelMem2.AutoSize = true;
            this.labelMem2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMem2.Location = new System.Drawing.Point(118, 83);
            this.labelMem2.Name = "labelMem2";
            this.labelMem2.Size = new System.Drawing.Size(108, 13);
            this.labelMem2.TabIndex = 7;
            this.labelMem2.Text = "Used Memory: GB";
            // 
            // progressBarCPU
            // 
            this.progressBarCPU.Location = new System.Drawing.Point(12, 21);
            this.progressBarCPU.Name = "progressBarCPU";
            this.progressBarCPU.Size = new System.Drawing.Size(100, 13);
            this.progressBarCPU.TabIndex = 8;
            // 
            // ram_memory_progressBar1
            // 
            this.ram_memory_progressBar1.Location = new System.Drawing.Point(12, 122);
            this.ram_memory_progressBar1.Name = "ram_memory_progressBar1";
            this.ram_memory_progressBar1.Size = new System.Drawing.Size(100, 13);
            this.ram_memory_progressBar1.TabIndex = 9;
            // 
            // usedDisk_progressBar1
            // 
            this.usedDisk_progressBar1.Location = new System.Drawing.Point(12, 170);
            this.usedDisk_progressBar1.Name = "usedDisk_progressBar1";
            this.usedDisk_progressBar1.Size = new System.Drawing.Size(100, 13);
            this.usedDisk_progressBar1.TabIndex = 11;
            // 
            // gpuUsedPercent_label1
            // 
            this.gpuUsedPercent_label1.AutoSize = true;
            this.gpuUsedPercent_label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpuUsedPercent_label1.Location = new System.Drawing.Point(118, 53);
            this.gpuUsedPercent_label1.Name = "gpuUsedPercent_label1";
            this.gpuUsedPercent_label1.Size = new System.Drawing.Size(126, 13);
            this.gpuUsedPercent_label1.TabIndex = 12;
            this.gpuUsedPercent_label1.Text = "Gpu Usage: 100.00%";
            // 
            // gpu_progressBar1
            // 
            this.gpu_progressBar1.Location = new System.Drawing.Point(12, 53);
            this.gpu_progressBar1.Name = "gpu_progressBar1";
            this.gpu_progressBar1.Size = new System.Drawing.Size(100, 13);
            this.gpu_progressBar1.TabIndex = 13;
            // 
            // verlabel1
            // 
            this.verlabel1.AutoSize = true;
            this.verlabel1.Location = new System.Drawing.Point(9, 5);
            this.verlabel1.Name = "verlabel1";
            this.verlabel1.Size = new System.Drawing.Size(50, 13);
            this.verlabel1.TabIndex = 14;
            this.verlabel1.Text = "Ver 0.1.1";
            // 
            // cpuTemp_label1
            // 
            this.cpuTemp_label1.AutoSize = true;
            this.cpuTemp_label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cpuTemp_label1.Location = new System.Drawing.Point(118, 34);
            this.cpuTemp_label1.Name = "cpuTemp_label1";
            this.cpuTemp_label1.Size = new System.Drawing.Size(68, 13);
            this.cpuTemp_label1.TabIndex = 15;
            this.cpuTemp_label1.Text = "Cpu Temp:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(305, 206);
            this.Controls.Add(this.cpuTemp_label1);
            this.Controls.Add(this.verlabel1);
            this.Controls.Add(this.gpu_progressBar1);
            this.Controls.Add(this.gpuUsedPercent_label1);
            this.Controls.Add(this.usedDisk_progressBar1);
            this.Controls.Add(this.ram_memory_progressBar1);
            this.Controls.Add(this.progressBarCPU);
            this.Controls.Add(this.labelMem2);
            this.Controls.Add(this.mempercentLabel);
            this.Controls.Add(this.totalMem);
            this.Controls.Add(this.labelAvailableDiskSpace);
            this.Controls.Add(this.labelUsedDiskSpace);
            this.Controls.Add(this.labelMem);
            this.Controls.Add(this.labelDisk);
            this.Controls.Add(this.labelCPU);
            this.ForeColor = System.Drawing.Color.Lime;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelCPU;
        private System.Windows.Forms.Label labelDisk;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label labelMem;
        private System.Windows.Forms.Label labelUsedDiskSpace;
        private System.Windows.Forms.Label labelAvailableDiskSpace;
        private System.Windows.Forms.Label totalMem;
        private System.Windows.Forms.Label mempercentLabel;
        private System.Windows.Forms.Label labelMem2;
        private System.Windows.Forms.ProgressBar progressBarCPU;
        private System.Windows.Forms.ProgressBar ram_memory_progressBar1;
        private System.Windows.Forms.ProgressBar usedDisk_progressBar1;
        private System.Windows.Forms.Label gpuUsedPercent_label1;
        private System.Windows.Forms.ProgressBar gpu_progressBar1;
        private System.Windows.Forms.Label verlabel1;
        private System.Windows.Forms.Label cpuTemp_label1;
    }
}

