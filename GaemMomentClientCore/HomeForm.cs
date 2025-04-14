using SendGrid.Helpers.Mail.Model;
using SendGrid.Helpers.Mail;
using SendGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GaemMoment
{
    /// <summary>
    /// Form used to login and register.
    /// </summary>
    public partial class HomeForm : Form
    {
        private static HomeForm instance = null;
        private static readonly object padlock = new object();
        private string CaptchaCode;
        public string emailCode;
        /// <summary>
        /// Initializes the form and a connection to the database.
        /// </summary>
        private HomeForm()
        {
            InitializeComponent();
            RegenerateCaptcha();
        }

        private void RegenerateCaptcha()
        {
            CaptchaCode = RandomString();
            picCaptcha.Image = CaptchaToImage(CaptchaCode, picCaptcha.Width, picCaptcha.Height);
        }

        public static HomeForm Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new HomeForm();
                    }
                    return instance;
                }
            }
        }

        /// <summary>
        /// Sends all input given in the registration fields to the database in attempt to register a new user.
        /// Called when the "Register" button is clicked.
        /// </summary>
        /// <param name="sender">Object sending the event.</param>
        /// <param name="e">Event arguments.</param>
        private void RegBtnClick(object sender, EventArgs e)
        {
            if (CaptchaCode != captchaTextBox.Text)
            {
                RegenerateCaptcha();
                MessageBox.Show("Invalid Captcha");
                return;
            }
            string gender = "", pronoun1 = "", pronoun2 = "";
            bool genderSpecified = true;
            switch (GenderListBox.SelectedIndex)
            {
                case 0:
                    gender = "Male";
                    pronoun1 = "he";
                    pronoun2 = "him";
                    break;
                case 1:
                    gender = "Female";
                    pronoun1 = "she";
                    pronoun2 = "her";
                    break;
                case 2:
                    gender = GenderTextBox.Text;
                    pronoun1 = PronounBox1.Text;
                    pronoun2 = PronounBox2.Text;
                    break;
                case 3:
                    genderSpecified = false;
                    pronoun1 = PronounBox1.Text;
                    pronoun2 = PronounBox2.Text;
                    break;
            }
            DBConn.Instance.InsertNewUser(
                RegUsernameBox.Text,
                RegPasswordBox.Text,
                EmailBox.Text,
                FNameBox.Text,
                LNameBox.Text,
                CityBox.Text,
                gender,
                pronoun1,
                pronoun2,
                genderSpecified);
        }

        /// <summary>
        /// Sends all input given in the login fields to the database in attempt to log into an account.
        /// Called when the "Login" button is clicked.
        /// </summary>
        /// <param name="sender">Object sending the event.</param>
        /// <param name="e">Event arguments.</param>
        private void LoginBtnClick(object sender, EventArgs e)
        {
            DBConn.Instance.Login(UsernameBox.Text, PasswordBox.Text);
        }

        /// <summary>
        /// Calls the function that loads all city names into the city selection box on form load.
        /// </summary>
        /// <param name="sender">Object sending the event.</param>
        /// <param name="e">Event arguments.</param>
        private void Form1Load(object sender, EventArgs e)
        {
            LoadCities();
        }

        /// <summary>
        /// Loads all city names into the city selection box.
        /// </summary>
        private void LoadCities()
        {
            CityBox.Items.Clear();
            foreach (City city in Enum.GetValues(typeof(City)))
            {
                CityBox.Items.Add(city);
            }
        }

        /// <summary>
        /// Chooses wether to display the gender and pronoun selection fields depending on the gender chosen from the list.
        /// </summary>
        /// <param name="sender">Object sending the event.</param>
        /// <param name="e">Event arguments.</param>
        private void GenderListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GenderListBox.SelectedIndex < 2)
            {
                ToggleGenderSelect(false);
                TogglePronounSelect(false);
            }
            else if (GenderListBox.SelectedIndex == 2)
            {
                ToggleGenderSelect(true);
                TogglePronounSelect(true);
            }
            else if (GenderListBox.SelectedIndex == 3)
            {
                ToggleGenderSelect(false);
                TogglePronounSelect(true);
            }
        }

        /// <summary>
        /// Displays or hides the pronoun selection fields depending on <paramref name="state"/>.
        /// </summary>
        /// <param name="state">True to display, False to hide.</param>
        private void TogglePronounSelect(bool state)
        {
            PronounPrompt.Visible = state; PronounPrompt.Enabled = state;
            PronounSlash.Visible = state; PronounSlash.Enabled = state;
            PronounBox1.Visible = state; PronounBox1.Enabled = state;
            PronounBox2.Visible = state; PronounBox2.Enabled = state;
        }

        /// <summary>
        /// Displays or hides the gender selection fields depending on <paramref name="state"/>.
        /// </summary>
        /// <param name="state">True to display, False to hide.</param>
        private void ToggleGenderSelect(bool state)
        {
            GenderPrompt.Visible = state; GenderPrompt.Enabled = state;
            GenderTextBox.Visible = state; GenderTextBox.Enabled = state;
        }

        private Bitmap CaptchaToImage(string text, int width, int height)
        {
            Bitmap bmp = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bmp);
            SolidBrush sb = new SolidBrush(Color.White);
            g.FillRectangle(sb, 0, 0, bmp.Width, bmp.Height);
            Font font = new Font("Tahoma", 45);
            sb = new SolidBrush(Color.Black);
            g.DrawString(text, font, sb, bmp.Width / 2 - (text.Length / 2) * font.Size, (bmp.Height / 2) - font.Size);
            int count = 0;
            Random rand = new Random();
            while (count < 1000)
            {
                sb = new SolidBrush(Color.YellowGreen);
                g.FillEllipse(sb, rand.Next(0, bmp.Width), rand.Next(0, bmp.Height), 4, 2);
                count++;
            }
            count = 0;
            while (count < 25)
            {
                g.DrawLine(new Pen(Color.Bisque), rand.Next(0, bmp.Width), rand.Next(0, bmp.Height), rand.Next(0, bmp.Width), rand.Next(0, bmp.Height));
                count++;
            }
            return bmp;
        }

        public string RandomString()
        {
            Random rnd = new Random();
            int number = rnd.Next(10000, 99999);
            return MD5(number.ToString()).ToUpperInvariant()[..6];
        }

        public string MD5(string input)
        {
            byte[] hashedBytes = System.Security.Cryptography.MD5.HashData(UnicodeEncoding.Unicode.GetBytes(input));
            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }

        private void RegenerateCaptchaButton_Click(object sender, EventArgs e)
        {
            RegenerateCaptcha();
        }

        public async Task SendMail(string email, string name, string message)
        {

            // Your SendGrid API Key you created above.
            string apiKey = "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";

            // Create an instance of the SendGrid Mail Client using the valid API Key
            var client = new SendGridClient(apiKey);

            // Use the From Email as the Email you verified above
            var senderEmail = new EmailAddress("chessbattleawesome@gmail.com", "Garry Chess, Inventor of Chess");

            // The recipient of the email
            var recieverEmail = new EmailAddress(email, name);

            // Define the Email Subject
            string emailSubject = "Hello World! This is my Subject (no I will not bother changing this";

            string textContent = message;

            // HTML content -> for clients supporting HTML, this is default
            string htmlContent = message;

            // construct the email to send via the SendGrid email api
            var msg = MailHelper.CreateSingleEmail(senderEmail, recieverEmail, emailSubject, textContent, htmlContent);

            // send the email asyncronously
            var resp = await client.SendEmailAsync(msg).ConfigureAwait(false);
        }
    }
}
