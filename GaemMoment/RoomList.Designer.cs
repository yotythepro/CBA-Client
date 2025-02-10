namespace GaemMoment
{
    partial class RoomList
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "yotythepro",
            "WOOOO"}, -1);
            this.RoomSelectionList = new System.Windows.Forms.ListView();
            this.RoomCreatorUsername = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RoomName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BackButton = new System.Windows.Forms.Button();
            this.CreateRoomButton = new System.Windows.Forms.Button();
            this.JoinRoomButton = new System.Windows.Forms.Button();
            this.JoinPrivateRoomButton = new System.Windows.Forms.Button();
            this.RefreshListButton = new System.Windows.Forms.Button();
            this.publicRoomCheckbox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // RoomSelectionList
            // 
            this.RoomSelectionList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.RoomCreatorUsername,
            this.RoomName});
            this.RoomSelectionList.FullRowSelect = true;
            this.RoomSelectionList.HideSelection = false;
            this.RoomSelectionList.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.RoomSelectionList.Location = new System.Drawing.Point(0, 47);
            this.RoomSelectionList.MultiSelect = false;
            this.RoomSelectionList.Name = "RoomSelectionList";
            this.RoomSelectionList.Size = new System.Drawing.Size(507, 424);
            this.RoomSelectionList.TabIndex = 0;
            this.RoomSelectionList.UseCompatibleStateImageBehavior = false;
            this.RoomSelectionList.View = System.Windows.Forms.View.Details;
            // 
            // RoomCreatorUsername
            // 
            this.RoomCreatorUsername.Text = "Username";
            this.RoomCreatorUsername.Width = 159;
            // 
            // RoomName
            // 
            this.RoomName.Text = "Room Name";
            this.RoomName.Width = 343;
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(3, 3);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(75, 23);
            this.BackButton.TabIndex = 1;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // CreateRoomButton
            // 
            this.CreateRoomButton.AutoSize = true;
            this.CreateRoomButton.Location = new System.Drawing.Point(3, 487);
            this.CreateRoomButton.Name = "CreateRoomButton";
            this.CreateRoomButton.Size = new System.Drawing.Size(79, 23);
            this.CreateRoomButton.TabIndex = 2;
            this.CreateRoomButton.Text = "Create Room";
            this.CreateRoomButton.UseVisualStyleBackColor = true;
            this.CreateRoomButton.Click += new System.EventHandler(this.CreateRoomButton_Click);
            // 
            // JoinRoomButton
            // 
            this.JoinRoomButton.Location = new System.Drawing.Point(319, 496);
            this.JoinRoomButton.Name = "JoinRoomButton";
            this.JoinRoomButton.Size = new System.Drawing.Size(75, 23);
            this.JoinRoomButton.TabIndex = 3;
            this.JoinRoomButton.Text = "Join Room";
            this.JoinRoomButton.UseVisualStyleBackColor = true;
            this.JoinRoomButton.Click += new System.EventHandler(this.JoinRoomButton_Click);
            // 
            // JoinPrivateRoomButton
            // 
            this.JoinPrivateRoomButton.AutoSize = true;
            this.JoinPrivateRoomButton.Location = new System.Drawing.Point(400, 496);
            this.JoinPrivateRoomButton.Name = "JoinPrivateRoomButton";
            this.JoinPrivateRoomButton.Size = new System.Drawing.Size(104, 23);
            this.JoinPrivateRoomButton.TabIndex = 4;
            this.JoinPrivateRoomButton.Text = "Find Private Room";
            this.JoinPrivateRoomButton.UseVisualStyleBackColor = true;
            this.JoinPrivateRoomButton.Click += new System.EventHandler(this.JoinPrivateRoomButton_Click);
            // 
            // RefreshListButton
            // 
            this.RefreshListButton.AutoSize = true;
            this.RefreshListButton.Location = new System.Drawing.Point(429, 3);
            this.RefreshListButton.Name = "RefreshListButton";
            this.RefreshListButton.Size = new System.Drawing.Size(75, 23);
            this.RefreshListButton.TabIndex = 5;
            this.RefreshListButton.Text = "Refresh List";
            this.RefreshListButton.UseVisualStyleBackColor = true;
            this.RefreshListButton.Click += new System.EventHandler(this.RefreshListButton_Click);
            // 
            // publicRoomCheckbox
            // 
            this.publicRoomCheckbox.AutoSize = true;
            this.publicRoomCheckbox.Checked = true;
            this.publicRoomCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.publicRoomCheckbox.Location = new System.Drawing.Point(3, 516);
            this.publicRoomCheckbox.Name = "publicRoomCheckbox";
            this.publicRoomCheckbox.Size = new System.Drawing.Size(146, 17);
            this.publicRoomCheckbox.TabIndex = 6;
            this.publicRoomCheckbox.Text = "Let Your Room Be Visible";
            this.publicRoomCheckbox.UseVisualStyleBackColor = true;
            // 
            // RoomList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.publicRoomCheckbox);
            this.Controls.Add(this.RefreshListButton);
            this.Controls.Add(this.JoinPrivateRoomButton);
            this.Controls.Add(this.JoinRoomButton);
            this.Controls.Add(this.CreateRoomButton);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.RoomSelectionList);
            this.Name = "RoomList";
            this.Size = new System.Drawing.Size(507, 540);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView RoomSelectionList;
        private System.Windows.Forms.ColumnHeader RoomCreatorUsername;
        private System.Windows.Forms.ColumnHeader RoomName;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button CreateRoomButton;
        private System.Windows.Forms.Button JoinRoomButton;
        private System.Windows.Forms.Button JoinPrivateRoomButton;
        private System.Windows.Forms.Button RefreshListButton;
        private System.Windows.Forms.CheckBox publicRoomCheckbox;
    }
}
