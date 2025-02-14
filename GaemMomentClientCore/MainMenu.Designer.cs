namespace GaemMoment
{
    partial class MainMenu
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
            this.PlayOnlineButton = new System.Windows.Forms.Button();
            this.PlayOfflineButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PlayOnlineButton
            // 
            this.PlayOnlineButton.Location = new System.Drawing.Point(31, 32);
            this.PlayOnlineButton.Name = "PlayOnlineButton";
            this.PlayOnlineButton.Size = new System.Drawing.Size(75, 23);
            this.PlayOnlineButton.TabIndex = 0;
            this.PlayOnlineButton.Text = "Play Online!";
            this.PlayOnlineButton.UseVisualStyleBackColor = true;
            this.PlayOnlineButton.Click += new System.EventHandler(this.PlayOnlineButton_Click);
            // 
            // PlayOfflineButton
            // 
            this.PlayOfflineButton.Location = new System.Drawing.Point(31, 84);
            this.PlayOfflineButton.Name = "PlayOfflineButton";
            this.PlayOfflineButton.Size = new System.Drawing.Size(75, 34);
            this.PlayOfflineButton.TabIndex = 1;
            this.PlayOfflineButton.Text = "Play VS \r\nCPU";
            this.PlayOfflineButton.UseVisualStyleBackColor = true;
            this.PlayOfflineButton.Click += new System.EventHandler(this.PlayOfflineButton_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PlayOfflineButton);
            this.Controls.Add(this.PlayOnlineButton);
            this.Name = "MainMenu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button PlayOnlineButton;
        private System.Windows.Forms.Button PlayOfflineButton;
    }
}
