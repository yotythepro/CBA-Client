namespace GaemMoment
{
    partial class MainForm
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
            this.mainMenu = new GaemMoment.MainMenu();
            this.roomList = new GaemMoment.RoomList();
            this.gameTab = new GaemMoment.GameTab();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Location = new System.Drawing.Point(183, 188);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(150, 150);
            this.mainMenu.TabIndex = 0;
            // 
            // roomList
            // 
            this.roomList.Location = new System.Drawing.Point(12, 12);
            this.roomList.Name = "roomList";
            this.roomList.Size = new System.Drawing.Size(507, 540);
            this.roomList.TabIndex = 1;
            // 
            // gameTab
            // 
            this.gameTab.Enabled = false;
            this.gameTab.Location = new System.Drawing.Point(68, 113);
            this.gameTab.Name = "gameTab";
            this.gameTab.Size = new System.Drawing.Size(390, 313);
            this.gameTab.TabIndex = 2;
            this.gameTab.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 595);
            this.Controls.Add(this.gameTab);
            this.Controls.Add(this.mainMenu);
            this.Controls.Add(this.roomList);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private MainMenu mainMenu;
        public RoomList roomList;
        private GameTab gameTab;
    }
}