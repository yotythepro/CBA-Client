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
            regBtn = new System.Windows.Forms.Button();
            UsernameBox = new System.Windows.Forms.TextBox();
            PasswordBox = new System.Windows.Forms.TextBox();
            loginBtn = new System.Windows.Forms.Button();
            LoginUsernamePrompt = new System.Windows.Forms.Label();
            LoginPasswordPrompt = new System.Windows.Forms.Label();
            RegPasswordPrompt = new System.Windows.Forms.Label();
            RegUsernamePrompt = new System.Windows.Forms.Label();
            RegPasswordBox = new System.Windows.Forms.TextBox();
            RegUsernameBox = new System.Windows.Forms.TextBox();
            EmailPrompt = new System.Windows.Forms.Label();
            EmailBox = new System.Windows.Forms.TextBox();
            LNamePrompt = new System.Windows.Forms.Label();
            FNamePrompt = new System.Windows.Forms.Label();
            LNameBox = new System.Windows.Forms.TextBox();
            FNameBox = new System.Windows.Forms.TextBox();
            CityPrompt = new System.Windows.Forms.Label();
            CityBox = new System.Windows.Forms.ComboBox();
            GenderListBox = new System.Windows.Forms.ComboBox();
            GenderListPrompt = new System.Windows.Forms.Label();
            PronounPrompt = new System.Windows.Forms.Label();
            PronounBox1 = new System.Windows.Forms.TextBox();
            PronounBox2 = new System.Windows.Forms.TextBox();
            PronounSlash = new System.Windows.Forms.Label();
            GenderPrompt = new System.Windows.Forms.Label();
            GenderTextBox = new System.Windows.Forms.TextBox();
            picCaptcha = new System.Windows.Forms.PictureBox();
            label1 = new System.Windows.Forms.Label();
            captchaTextBox = new System.Windows.Forms.TextBox();
            regenerateCaptchaButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)picCaptcha).BeginInit();
            SuspendLayout();
            // 
            // regBtn
            // 
            regBtn.Location = new System.Drawing.Point(692, 35);
            regBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            regBtn.Name = "regBtn";
            regBtn.Size = new System.Drawing.Size(88, 27);
            regBtn.TabIndex = 0;
            regBtn.Text = "Register";
            regBtn.UseVisualStyleBackColor = true;
            regBtn.Click += RegBtnClick;
            // 
            // UsernameBox
            // 
            UsernameBox.Location = new System.Drawing.Point(57, 44);
            UsernameBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            UsernameBox.Name = "UsernameBox";
            UsernameBox.Size = new System.Drawing.Size(116, 23);
            UsernameBox.TabIndex = 1;
            // 
            // PasswordBox
            // 
            PasswordBox.Location = new System.Drawing.Point(57, 92);
            PasswordBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            PasswordBox.Name = "PasswordBox";
            PasswordBox.Size = new System.Drawing.Size(116, 23);
            PasswordBox.TabIndex = 2;
            // 
            // loginBtn
            // 
            loginBtn.Location = new System.Drawing.Point(181, 40);
            loginBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            loginBtn.Name = "loginBtn";
            loginBtn.Size = new System.Drawing.Size(88, 27);
            loginBtn.TabIndex = 3;
            loginBtn.Text = "Login";
            loginBtn.UseVisualStyleBackColor = true;
            loginBtn.Click += LoginBtnClick;
            // 
            // LoginUsernamePrompt
            // 
            LoginUsernamePrompt.AutoSize = true;
            LoginUsernamePrompt.Location = new System.Drawing.Point(57, 25);
            LoginUsernamePrompt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            LoginUsernamePrompt.Name = "LoginUsernamePrompt";
            LoginUsernamePrompt.Size = new System.Drawing.Size(60, 15);
            LoginUsernamePrompt.TabIndex = 4;
            LoginUsernamePrompt.Text = "Username";
            // 
            // LoginPasswordPrompt
            // 
            LoginPasswordPrompt.AutoSize = true;
            LoginPasswordPrompt.Location = new System.Drawing.Point(57, 70);
            LoginPasswordPrompt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            LoginPasswordPrompt.Name = "LoginPasswordPrompt";
            LoginPasswordPrompt.Size = new System.Drawing.Size(57, 15);
            LoginPasswordPrompt.TabIndex = 5;
            LoginPasswordPrompt.Text = "Password";
            // 
            // RegPasswordPrompt
            // 
            RegPasswordPrompt.AutoSize = true;
            RegPasswordPrompt.Location = new System.Drawing.Point(448, 64);
            RegPasswordPrompt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            RegPasswordPrompt.Name = "RegPasswordPrompt";
            RegPasswordPrompt.Size = new System.Drawing.Size(57, 15);
            RegPasswordPrompt.TabIndex = 9;
            RegPasswordPrompt.Text = "Password";
            // 
            // RegUsernamePrompt
            // 
            RegUsernamePrompt.AutoSize = true;
            RegUsernamePrompt.Location = new System.Drawing.Point(448, 19);
            RegUsernamePrompt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            RegUsernamePrompt.Name = "RegUsernamePrompt";
            RegUsernamePrompt.Size = new System.Drawing.Size(60, 15);
            RegUsernamePrompt.TabIndex = 8;
            RegUsernamePrompt.Text = "Username";
            // 
            // RegPasswordBox
            // 
            RegPasswordBox.Location = new System.Drawing.Point(448, 86);
            RegPasswordBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            RegPasswordBox.Name = "RegPasswordBox";
            RegPasswordBox.Size = new System.Drawing.Size(116, 23);
            RegPasswordBox.TabIndex = 7;
            // 
            // RegUsernameBox
            // 
            RegUsernameBox.Location = new System.Drawing.Point(448, 37);
            RegUsernameBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            RegUsernameBox.Name = "RegUsernameBox";
            RegUsernameBox.Size = new System.Drawing.Size(116, 23);
            RegUsernameBox.TabIndex = 6;
            // 
            // EmailPrompt
            // 
            EmailPrompt.AutoSize = true;
            EmailPrompt.Location = new System.Drawing.Point(448, 214);
            EmailPrompt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            EmailPrompt.Name = "EmailPrompt";
            EmailPrompt.Size = new System.Drawing.Size(36, 15);
            EmailPrompt.TabIndex = 11;
            EmailPrompt.Text = "Email";
            // 
            // EmailBox
            // 
            EmailBox.Location = new System.Drawing.Point(448, 236);
            EmailBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            EmailBox.Name = "EmailBox";
            EmailBox.Size = new System.Drawing.Size(116, 23);
            EmailBox.TabIndex = 10;
            // 
            // LNamePrompt
            // 
            LNamePrompt.AutoSize = true;
            LNamePrompt.Location = new System.Drawing.Point(448, 164);
            LNamePrompt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            LNamePrompt.Name = "LNamePrompt";
            LNamePrompt.Size = new System.Drawing.Size(63, 15);
            LNamePrompt.TabIndex = 15;
            LNamePrompt.Text = "Last Name";
            // 
            // FNamePrompt
            // 
            FNamePrompt.AutoSize = true;
            FNamePrompt.Location = new System.Drawing.Point(448, 119);
            FNamePrompt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            FNamePrompt.Name = "FNamePrompt";
            FNamePrompt.Size = new System.Drawing.Size(64, 15);
            FNamePrompt.TabIndex = 14;
            FNamePrompt.Text = "First Name";
            // 
            // LNameBox
            // 
            LNameBox.Location = new System.Drawing.Point(448, 186);
            LNameBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            LNameBox.Name = "LNameBox";
            LNameBox.Size = new System.Drawing.Size(116, 23);
            LNameBox.TabIndex = 13;
            // 
            // FNameBox
            // 
            FNameBox.Location = new System.Drawing.Point(448, 137);
            FNameBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            FNameBox.Name = "FNameBox";
            FNameBox.Size = new System.Drawing.Size(116, 23);
            FNameBox.TabIndex = 12;
            // 
            // CityPrompt
            // 
            CityPrompt.AutoSize = true;
            CityPrompt.Location = new System.Drawing.Point(444, 266);
            CityPrompt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            CityPrompt.Name = "CityPrompt";
            CityPrompt.Size = new System.Drawing.Size(28, 15);
            CityPrompt.TabIndex = 17;
            CityPrompt.Text = "City";
            // 
            // CityBox
            // 
            CityBox.FormattingEnabled = true;
            CityBox.Location = new System.Drawing.Point(448, 285);
            CityBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            CityBox.Name = "CityBox";
            CityBox.Size = new System.Drawing.Size(116, 23);
            CityBox.TabIndex = 18;
            // 
            // GenderListBox
            // 
            GenderListBox.FormattingEnabled = true;
            GenderListBox.Items.AddRange(new object[] { "Male", "Female", "Other", "Prefer not to specify" });
            GenderListBox.Location = new System.Drawing.Point(448, 339);
            GenderListBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            GenderListBox.Name = "GenderListBox";
            GenderListBox.Size = new System.Drawing.Size(116, 23);
            GenderListBox.TabIndex = 20;
            GenderListBox.SelectedIndexChanged += GenderListBox_SelectedIndexChanged;
            // 
            // GenderListPrompt
            // 
            GenderListPrompt.AutoSize = true;
            GenderListPrompt.Location = new System.Drawing.Point(444, 320);
            GenderListPrompt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            GenderListPrompt.Name = "GenderListPrompt";
            GenderListPrompt.Size = new System.Drawing.Size(45, 15);
            GenderListPrompt.TabIndex = 19;
            GenderListPrompt.Text = "Gender";
            // 
            // PronounPrompt
            // 
            PronounPrompt.AutoSize = true;
            PronounPrompt.Enabled = false;
            PronounPrompt.Location = new System.Drawing.Point(639, 328);
            PronounPrompt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            PronounPrompt.Name = "PronounPrompt";
            PronounPrompt.Size = new System.Drawing.Size(164, 15);
            PronounPrompt.TabIndex = 21;
            PronounPrompt.Text = "Please specify your pronouns:";
            PronounPrompt.Visible = false;
            // 
            // PronounBox1
            // 
            PronounBox1.Enabled = false;
            PronounBox1.Location = new System.Drawing.Point(643, 346);
            PronounBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            PronounBox1.Name = "PronounBox1";
            PronounBox1.Size = new System.Drawing.Size(63, 23);
            PronounBox1.TabIndex = 22;
            PronounBox1.Visible = false;
            // 
            // PronounBox2
            // 
            PronounBox2.Enabled = false;
            PronounBox2.Location = new System.Drawing.Point(735, 346);
            PronounBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            PronounBox2.Name = "PronounBox2";
            PronounBox2.Size = new System.Drawing.Size(63, 23);
            PronounBox2.TabIndex = 23;
            PronounBox2.Visible = false;
            // 
            // PronounSlash
            // 
            PronounSlash.AutoSize = true;
            PronounSlash.Enabled = false;
            PronounSlash.Location = new System.Drawing.Point(714, 351);
            PronounSlash.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            PronounSlash.Name = "PronounSlash";
            PronounSlash.Size = new System.Drawing.Size(12, 15);
            PronounSlash.TabIndex = 24;
            PronounSlash.Text = "/";
            PronounSlash.Visible = false;
            // 
            // GenderPrompt
            // 
            GenderPrompt.AutoSize = true;
            GenderPrompt.Enabled = false;
            GenderPrompt.Location = new System.Drawing.Point(444, 386);
            GenderPrompt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            GenderPrompt.Name = "GenderPrompt";
            GenderPrompt.Size = new System.Drawing.Size(150, 15);
            GenderPrompt.TabIndex = 25;
            GenderPrompt.Text = "Please specify your gender:";
            GenderPrompt.Visible = false;
            // 
            // GenderTextBox
            // 
            GenderTextBox.Enabled = false;
            GenderTextBox.Location = new System.Drawing.Point(448, 405);
            GenderTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            GenderTextBox.Name = "GenderTextBox";
            GenderTextBox.Size = new System.Drawing.Size(116, 23);
            GenderTextBox.TabIndex = 26;
            GenderTextBox.Visible = false;
            // 
            // picCaptcha
            // 
            picCaptcha.Location = new System.Drawing.Point(593, 70);
            picCaptcha.Name = "picCaptcha";
            picCaptcha.Size = new System.Drawing.Size(301, 139);
            picCaptcha.TabIndex = 27;
            picCaptcha.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(635, 222);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(54, 15);
            label1.TabIndex = 28;
            label1.Text = "Captcha:";
            // 
            // captchaTextBox
            // 
            captchaTextBox.Location = new System.Drawing.Point(695, 222);
            captchaTextBox.Name = "captchaTextBox";
            captchaTextBox.Size = new System.Drawing.Size(100, 23);
            captchaTextBox.TabIndex = 29;
            // 
            // regenerateCaptchaButton
            // 
            regenerateCaptchaButton.Location = new System.Drawing.Point(653, 266);
            regenerateCaptchaButton.Name = "regenerateCaptchaButton";
            regenerateCaptchaButton.Size = new System.Drawing.Size(127, 23);
            regenerateCaptchaButton.TabIndex = 30;
            regenerateCaptchaButton.Text = "Regenerate Captcha";
            regenerateCaptchaButton.UseVisualStyleBackColor = true;
            regenerateCaptchaButton.Click += RegenerateCaptchaButton_Click;
            // 
            // HomeForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(933, 519);
            Controls.Add(regenerateCaptchaButton);
            Controls.Add(captchaTextBox);
            Controls.Add(label1);
            Controls.Add(picCaptcha);
            Controls.Add(GenderTextBox);
            Controls.Add(GenderPrompt);
            Controls.Add(PronounSlash);
            Controls.Add(PronounBox2);
            Controls.Add(PronounBox1);
            Controls.Add(PronounPrompt);
            Controls.Add(GenderListBox);
            Controls.Add(GenderListPrompt);
            Controls.Add(CityBox);
            Controls.Add(CityPrompt);
            Controls.Add(LNamePrompt);
            Controls.Add(FNamePrompt);
            Controls.Add(LNameBox);
            Controls.Add(FNameBox);
            Controls.Add(EmailPrompt);
            Controls.Add(EmailBox);
            Controls.Add(RegPasswordPrompt);
            Controls.Add(RegUsernamePrompt);
            Controls.Add(RegPasswordBox);
            Controls.Add(RegUsernameBox);
            Controls.Add(LoginPasswordPrompt);
            Controls.Add(LoginUsernamePrompt);
            Controls.Add(loginBtn);
            Controls.Add(PasswordBox);
            Controls.Add(UsernameBox);
            Controls.Add(regBtn);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "HomeForm";
            Text = "Form1";
            Load += Form1Load;
            ((System.ComponentModel.ISupportInitialize)picCaptcha).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
        private System.Windows.Forms.PictureBox picCaptcha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox captchaTextBox;
        private System.Windows.Forms.Button regenerateCaptchaButton;
    }
}

