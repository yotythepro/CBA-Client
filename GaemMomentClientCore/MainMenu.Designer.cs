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
            PlayOnlineButton = new System.Windows.Forms.Button();
            PlayOfflineButton = new System.Windows.Forms.Button();
            LoadButton = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // PlayOnlineButton
            // 
            PlayOnlineButton.Location = new System.Drawing.Point(36, 37);
            PlayOnlineButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            PlayOnlineButton.Name = "PlayOnlineButton";
            PlayOnlineButton.Size = new System.Drawing.Size(88, 27);
            PlayOnlineButton.TabIndex = 0;
            PlayOnlineButton.Text = "Play Online!";
            PlayOnlineButton.UseVisualStyleBackColor = true;
            PlayOnlineButton.Click += PlayOnlineButton_Click;
            // 
            // PlayOfflineButton
            // 
            PlayOfflineButton.Location = new System.Drawing.Point(36, 97);
            PlayOfflineButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            PlayOfflineButton.Name = "PlayOfflineButton";
            PlayOfflineButton.Size = new System.Drawing.Size(88, 39);
            PlayOfflineButton.TabIndex = 1;
            PlayOfflineButton.Text = "Play VS \r\nCPU";
            PlayOfflineButton.UseVisualStyleBackColor = true;
            PlayOfflineButton.Click += PlayOfflineButton_Click;
            // 
            // LoadButton
            // 
            LoadButton.Location = new System.Drawing.Point(36, 164);
            LoadButton.Name = "LoadButton";
            LoadButton.Size = new System.Drawing.Size(88, 23);
            LoadButton.TabIndex = 2;
            LoadButton.Text = "Load Game";
            LoadButton.UseVisualStyleBackColor = true;
            LoadButton.Click += LoadButton_Click;
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(LoadButton);
            Controls.Add(PlayOfflineButton);
            Controls.Add(PlayOnlineButton);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "MainMenu";
            Size = new System.Drawing.Size(175, 221);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button PlayOnlineButton;
        private System.Windows.Forms.Button PlayOfflineButton;
        private System.Windows.Forms.Button LoadButton;
    }
}
