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
            mainMenu = new MainMenu();
            roomList = new RoomList();
            gameTab = new GameTab();
            SuspendLayout();
            // 
            // mainMenu
            // 
            mainMenu.Location = new System.Drawing.Point(214, 217);
            mainMenu.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            mainMenu.Name = "mainMenu";
            mainMenu.Size = new System.Drawing.Size(175, 173);
            mainMenu.TabIndex = 0;
            // 
            // roomList
            // 
            roomList.Location = new System.Drawing.Point(14, 14);
            roomList.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            roomList.Name = "roomList";
            roomList.Size = new System.Drawing.Size(592, 623);
            roomList.TabIndex = 1;
            // 
            // gameTab
            // 
            gameTab.Enabled = false;
            gameTab.Location = new System.Drawing.Point(0, 0);
            gameTab.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            gameTab.Name = "gameTab";
            gameTab.Size = new System.Drawing.Size(1000, 1000);
            gameTab.TabIndex = 2;
            gameTab.Visible = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1084, 1061);
            Controls.Add(gameTab);
            Controls.Add(mainMenu);
            Controls.Add(roomList);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "MainForm";
            Text = "MainForm";
            ResumeLayout(false);
        }

        #endregion

        private MainMenu mainMenu;
        public RoomList roomList;
        public GameTab gameTab;
    }
}