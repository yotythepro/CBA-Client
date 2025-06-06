namespace GaemMoment
{
    partial class GameTab
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            DownloadBtn = new System.Windows.Forms.Button();
            BackBtn = new System.Windows.Forms.Button();
            StartBtn = new System.Windows.Forms.Button();
            NextBtn = new System.Windows.Forms.Button();
            EndBtn = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 177);
            label1.Location = new System.Drawing.Point(576, 13);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(60, 24);
            label1.TabIndex = 0;
            label1.Text = "label1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 177);
            label2.Location = new System.Drawing.Point(751, 323);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(211, 24);
            label2.TabIndex = 1;
            label2.Text = "Waiting For Opponent...";
            // 
            // DownloadBtn
            // 
            DownloadBtn.AutoSize = true;
            DownloadBtn.Enabled = false;
            DownloadBtn.Location = new System.Drawing.Point(781, 397);
            DownloadBtn.Name = "DownloadBtn";
            DownloadBtn.Size = new System.Drawing.Size(152, 25);
            DownloadBtn.TabIndex = 2;
            DownloadBtn.Text = "Download Replay As PGN";
            DownloadBtn.UseVisualStyleBackColor = true;
            DownloadBtn.Visible = false;
            DownloadBtn.Click += DownloadBtn_Click;
            // 
            // BackBtn
            // 
            BackBtn.Location = new System.Drawing.Point(777, 482);
            BackBtn.Name = "BackBtn";
            BackBtn.Size = new System.Drawing.Size(75, 47);
            BackBtn.TabIndex = 4;
            BackBtn.Text = "Step Back";
            BackBtn.UseVisualStyleBackColor = true;
            BackBtn.Click += BackBtn_Click;
            // 
            // StartBtn
            // 
            StartBtn.Location = new System.Drawing.Point(858, 482);
            StartBtn.Name = "StartBtn";
            StartBtn.Size = new System.Drawing.Size(75, 47);
            StartBtn.TabIndex = 5;
            StartBtn.Text = "Skip To Start";
            StartBtn.UseVisualStyleBackColor = true;
            StartBtn.Click += StartBtn_Click;
            // 
            // NextBtn
            // 
            NextBtn.Location = new System.Drawing.Point(777, 535);
            NextBtn.Name = "NextBtn";
            NextBtn.Size = new System.Drawing.Size(75, 47);
            NextBtn.TabIndex = 6;
            NextBtn.Text = "Step Forward";
            NextBtn.UseVisualStyleBackColor = true;
            NextBtn.Click += NextBtn_Click;
            // 
            // EndBtn
            // 
            EndBtn.Location = new System.Drawing.Point(858, 535);
            EndBtn.Name = "EndBtn";
            EndBtn.Size = new System.Drawing.Size(75, 47);
            EndBtn.TabIndex = 7;
            EndBtn.Text = "Skip To End";
            EndBtn.UseVisualStyleBackColor = true;
            EndBtn.Click += EndBtn_Click;
            // 
            // GameTab
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(EndBtn);
            Controls.Add(NextBtn);
            Controls.Add(StartBtn);
            Controls.Add(BackBtn);
            Controls.Add(DownloadBtn);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "GameTab";
            Size = new System.Drawing.Size(1000, 1000);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button DownloadBtn;
        private System.Windows.Forms.Button BackBtn;
        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.Button NextBtn;
        private System.Windows.Forms.Button EndBtn;
    }
}
