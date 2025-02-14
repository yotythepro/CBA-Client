namespace GaemMoment
{
    partial class HomeForm
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
            this.regBtn = new System.Windows.Forms.Button();
            this.UsernameBox = new System.Windows.Forms.TextBox();
            this.PasswordBox = new System.Windows.Forms.TextBox();
            this.loginBtn = new System.Windows.Forms.Button();
            this.LoginUsernamePrompt = new System.Windows.Forms.Label();
            this.LoginPasswordPrompt = new System.Windows.Forms.Label();
            this.RegPasswordPrompt = new System.Windows.Forms.Label();
            this.RegUsernamePrompt = new System.Windows.Forms.Label();
            this.RegPasswordBox = new System.Windows.Forms.TextBox();
            this.RegUsernameBox = new System.Windows.Forms.TextBox();
            this.EmailPrompt = new System.Windows.Forms.Label();
            this.EmailBox = new System.Windows.Forms.TextBox();
            this.LNamePrompt = new System.Windows.Forms.Label();
            this.FNamePrompt = new System.Windows.Forms.Label();
            this.LNameBox = new System.Windows.Forms.TextBox();
            this.FNameBox = new System.Windows.Forms.TextBox();
            this.CityPrompt = new System.Windows.Forms.Label();
            this.CityBox = new System.Windows.Forms.ComboBox();
            this.GenderListBox = new System.Windows.Forms.ComboBox();
            this.GenderListPrompt = new System.Windows.Forms.Label();
            this.PronounPrompt = new System.Windows.Forms.Label();
            this.PronounBox1 = new System.Windows.Forms.TextBox();
            this.PronounBox2 = new System.Windows.Forms.TextBox();
            this.PronounSlash = new System.Windows.Forms.Label();
            this.GenderPrompt = new System.Windows.Forms.Label();
            this.GenderTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // regBtn
            // 
            this.regBtn.Location = new System.Drawing.Point(593, 30);
            this.regBtn.Name = "regBtn";
            this.regBtn.Size = new System.Drawing.Size(75, 23);
            this.regBtn.TabIndex = 0;
            this.regBtn.Text = "Register";
            this.regBtn.UseVisualStyleBackColor = true;
            this.regBtn.Click += new System.EventHandler(this.RegBtnClick);
            // 
            // UsernameBox
            // 
            this.UsernameBox.Location = new System.Drawing.Point(49, 38);
            this.UsernameBox.Name = "UsernameBox";
            this.UsernameBox.Size = new System.Drawing.Size(100, 20);
            this.UsernameBox.TabIndex = 1;
            // 
            // PasswordBox
            // 
            this.PasswordBox.Location = new System.Drawing.Point(49, 80);
            this.PasswordBox.Name = "PasswordBox";
            this.PasswordBox.Size = new System.Drawing.Size(100, 20);
            this.PasswordBox.TabIndex = 2;
            // 
            // loginBtn
            // 
            this.loginBtn.Location = new System.Drawing.Point(155, 35);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(75, 23);
            this.loginBtn.TabIndex = 3;
            this.loginBtn.Text = "Login";
            this.loginBtn.UseVisualStyleBackColor = true;
            this.loginBtn.Click += new System.EventHandler(this.LoginBtnClick);
            // 
            // LoginUsernamePrompt
            // 
            this.LoginUsernamePrompt.AutoSize = true;
            this.LoginUsernamePrompt.Location = new System.Drawing.Point(49, 22);
            this.LoginUsernamePrompt.Name = "LoginUsernamePrompt";
            this.LoginUsernamePrompt.Size = new System.Drawing.Size(55, 13);
            this.LoginUsernamePrompt.TabIndex = 4;
            this.LoginUsernamePrompt.Text = "Username";
            // 
            // LoginPasswordPrompt
            // 
            this.LoginPasswordPrompt.AutoSize = true;
            this.LoginPasswordPrompt.Location = new System.Drawing.Point(49, 61);
            this.LoginPasswordPrompt.Name = "LoginPasswordPrompt";
            this.LoginPasswordPrompt.Size = new System.Drawing.Size(53, 13);
            this.LoginPasswordPrompt.TabIndex = 5;
            this.LoginPasswordPrompt.Text = "Password";
            // 
            // RegPasswordPrompt
            // 
            this.RegPasswordPrompt.AutoSize = true;
            this.RegPasswordPrompt.Location = new System.Drawing.Point(473, 56);
            this.RegPasswordPrompt.Name = "RegPasswordPrompt";
            this.RegPasswordPrompt.Size = new System.Drawing.Size(53, 13);
            this.RegPasswordPrompt.TabIndex = 9;
            this.RegPasswordPrompt.Text = "Password";
            // 
            // RegUsernamePrompt
            // 
            this.RegUsernamePrompt.AutoSize = true;
            this.RegUsernamePrompt.Location = new System.Drawing.Point(473, 17);
            this.RegUsernamePrompt.Name = "RegUsernamePrompt";
            this.RegUsernamePrompt.Size = new System.Drawing.Size(55, 13);
            this.RegUsernamePrompt.TabIndex = 8;
            this.RegUsernamePrompt.Text = "Username";
            // 
            // RegPasswordBox
            // 
            this.RegPasswordBox.Location = new System.Drawing.Point(473, 75);
            this.RegPasswordBox.Name = "RegPasswordBox";
            this.RegPasswordBox.Size = new System.Drawing.Size(100, 20);
            this.RegPasswordBox.TabIndex = 7;
            // 
            // RegUsernameBox
            // 
            this.RegUsernameBox.Location = new System.Drawing.Point(473, 33);
            this.RegUsernameBox.Name = "RegUsernameBox";
            this.RegUsernameBox.Size = new System.Drawing.Size(100, 20);
            this.RegUsernameBox.TabIndex = 6;
            // 
            // EmailPrompt
            // 
            this.EmailPrompt.AutoSize = true;
            this.EmailPrompt.Location = new System.Drawing.Point(473, 186);
            this.EmailPrompt.Name = "EmailPrompt";
            this.EmailPrompt.Size = new System.Drawing.Size(32, 13);
            this.EmailPrompt.TabIndex = 11;
            this.EmailPrompt.Text = "Email";
            // 
            // EmailBox
            // 
            this.EmailBox.Location = new System.Drawing.Point(473, 205);
            this.EmailBox.Name = "EmailBox";
            this.EmailBox.Size = new System.Drawing.Size(100, 20);
            this.EmailBox.TabIndex = 10;
            // 
            // LNamePrompt
            // 
            this.LNamePrompt.AutoSize = true;
            this.LNamePrompt.Location = new System.Drawing.Point(473, 143);
            this.LNamePrompt.Name = "LNamePrompt";
            this.LNamePrompt.Size = new System.Drawing.Size(58, 13);
            this.LNamePrompt.TabIndex = 15;
            this.LNamePrompt.Text = "Last Name";
            // 
            // FNamePrompt
            // 
            this.FNamePrompt.AutoSize = true;
            this.FNamePrompt.Location = new System.Drawing.Point(473, 104);
            this.FNamePrompt.Name = "FNamePrompt";
            this.FNamePrompt.Size = new System.Drawing.Size(57, 13);
            this.FNamePrompt.TabIndex = 14;
            this.FNamePrompt.Text = "First Name";
            // 
            // LNameBox
            // 
            this.LNameBox.Location = new System.Drawing.Point(473, 162);
            this.LNameBox.Name = "LNameBox";
            this.LNameBox.Size = new System.Drawing.Size(100, 20);
            this.LNameBox.TabIndex = 13;
            // 
            // FNameBox
            // 
            this.FNameBox.Location = new System.Drawing.Point(473, 120);
            this.FNameBox.Name = "FNameBox";
            this.FNameBox.Size = new System.Drawing.Size(100, 20);
            this.FNameBox.TabIndex = 12;
            // 
            // CityPrompt
            // 
            this.CityPrompt.AutoSize = true;
            this.CityPrompt.Location = new System.Drawing.Point(470, 231);
            this.CityPrompt.Name = "CityPrompt";
            this.CityPrompt.Size = new System.Drawing.Size(24, 13);
            this.CityPrompt.TabIndex = 17;
            this.CityPrompt.Text = "City";
            // 
            // CityBox
            // 
            this.CityBox.FormattingEnabled = true;
            this.CityBox.Location = new System.Drawing.Point(473, 248);
            this.CityBox.Name = "CityBox";
            this.CityBox.Size = new System.Drawing.Size(100, 21);
            this.CityBox.TabIndex = 18;
            // 
            // GenderListBox
            // 
            this.GenderListBox.FormattingEnabled = true;
            this.GenderListBox.Items.AddRange(new object[] {
            "Male",
            "Female",
            "Other",
            "Prefer not to specify"});
            this.GenderListBox.Location = new System.Drawing.Point(473, 295);
            this.GenderListBox.Name = "GenderListBox";
            this.GenderListBox.Size = new System.Drawing.Size(100, 21);
            this.GenderListBox.TabIndex = 20;
            this.GenderListBox.SelectedIndexChanged += new System.EventHandler(this.GenderListBox_SelectedIndexChanged);
            // 
            // GenderListPrompt
            // 
            this.GenderListPrompt.AutoSize = true;
            this.GenderListPrompt.Location = new System.Drawing.Point(470, 278);
            this.GenderListPrompt.Name = "GenderListPrompt";
            this.GenderListPrompt.Size = new System.Drawing.Size(42, 13);
            this.GenderListPrompt.TabIndex = 19;
            this.GenderListPrompt.Text = "Gender";
            // 
            // PronounPrompt
            // 
            this.PronounPrompt.AutoSize = true;
            this.PronounPrompt.Enabled = false;
            this.PronounPrompt.Location = new System.Drawing.Point(626, 278);
            this.PronounPrompt.Name = "PronounPrompt";
            this.PronounPrompt.Size = new System.Drawing.Size(148, 13);
            this.PronounPrompt.TabIndex = 21;
            this.PronounPrompt.Text = "Please specify your pronouns:";
            this.PronounPrompt.Visible = false;
            // 
            // PronounBox1
            // 
            this.PronounBox1.Enabled = false;
            this.PronounBox1.Location = new System.Drawing.Point(629, 294);
            this.PronounBox1.Name = "PronounBox1";
            this.PronounBox1.Size = new System.Drawing.Size(55, 20);
            this.PronounBox1.TabIndex = 22;
            this.PronounBox1.Visible = false;
            // 
            // PronounBox2
            // 
            this.PronounBox2.Enabled = false;
            this.PronounBox2.Location = new System.Drawing.Point(708, 294);
            this.PronounBox2.Name = "PronounBox2";
            this.PronounBox2.Size = new System.Drawing.Size(55, 20);
            this.PronounBox2.TabIndex = 23;
            this.PronounBox2.Visible = false;
            // 
            // PronounSlash
            // 
            this.PronounSlash.AutoSize = true;
            this.PronounSlash.Enabled = false;
            this.PronounSlash.Location = new System.Drawing.Point(690, 298);
            this.PronounSlash.Name = "PronounSlash";
            this.PronounSlash.Size = new System.Drawing.Size(12, 13);
            this.PronounSlash.TabIndex = 24;
            this.PronounSlash.Text = "/";
            this.PronounSlash.Visible = false;
            // 
            // GenderPrompt
            // 
            this.GenderPrompt.AutoSize = true;
            this.GenderPrompt.Enabled = false;
            this.GenderPrompt.Location = new System.Drawing.Point(470, 335);
            this.GenderPrompt.Name = "GenderPrompt";
            this.GenderPrompt.Size = new System.Drawing.Size(137, 13);
            this.GenderPrompt.TabIndex = 25;
            this.GenderPrompt.Text = "Please specify your gender:";
            this.GenderPrompt.Visible = false;
            // 
            // GenderTextBox
            // 
            this.GenderTextBox.Enabled = false;
            this.GenderTextBox.Location = new System.Drawing.Point(473, 352);
            this.GenderTextBox.Name = "GenderTextBox";
            this.GenderTextBox.Size = new System.Drawing.Size(100, 20);
            this.GenderTextBox.TabIndex = 26;
            this.GenderTextBox.Visible = false;
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.GenderTextBox);
            this.Controls.Add(this.GenderPrompt);
            this.Controls.Add(this.PronounSlash);
            this.Controls.Add(this.PronounBox2);
            this.Controls.Add(this.PronounBox1);
            this.Controls.Add(this.PronounPrompt);
            this.Controls.Add(this.GenderListBox);
            this.Controls.Add(this.GenderListPrompt);
            this.Controls.Add(this.CityBox);
            this.Controls.Add(this.CityPrompt);
            this.Controls.Add(this.LNamePrompt);
            this.Controls.Add(this.FNamePrompt);
            this.Controls.Add(this.LNameBox);
            this.Controls.Add(this.FNameBox);
            this.Controls.Add(this.EmailPrompt);
            this.Controls.Add(this.EmailBox);
            this.Controls.Add(this.RegPasswordPrompt);
            this.Controls.Add(this.RegUsernamePrompt);
            this.Controls.Add(this.RegPasswordBox);
            this.Controls.Add(this.RegUsernameBox);
            this.Controls.Add(this.LoginPasswordPrompt);
            this.Controls.Add(this.LoginUsernamePrompt);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.PasswordBox);
            this.Controls.Add(this.UsernameBox);
            this.Controls.Add(this.regBtn);
            this.Name = "HomeForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button regBtn;
        private System.Windows.Forms.TextBox UsernameBox;
        private System.Windows.Forms.TextBox PasswordBox;
        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.Label LoginUsernamePrompt;
        private System.Windows.Forms.Label LoginPasswordPrompt;
        private System.Windows.Forms.Label RegPasswordPrompt;
        private System.Windows.Forms.Label RegUsernamePrompt;
        private System.Windows.Forms.TextBox RegPasswordBox;
        private System.Windows.Forms.TextBox RegUsernameBox;
        private System.Windows.Forms.Label EmailPrompt;
        private System.Windows.Forms.TextBox EmailBox;
        private System.Windows.Forms.Label LNamePrompt;
        private System.Windows.Forms.Label FNamePrompt;
        private System.Windows.Forms.TextBox LNameBox;
        private System.Windows.Forms.TextBox FNameBox;
        private System.Windows.Forms.Label CityPrompt;
        private System.Windows.Forms.ComboBox CityBox;
        private System.Windows.Forms.ComboBox GenderListBox;
        private System.Windows.Forms.Label GenderListPrompt;
        private System.Windows.Forms.Label PronounPrompt;
        private System.Windows.Forms.TextBox PronounBox1;
        private System.Windows.Forms.TextBox PronounBox2;
        private System.Windows.Forms.Label PronounSlash;
        private System.Windows.Forms.Label GenderPrompt;
        private System.Windows.Forms.TextBox GenderTextBox;
    }
}

