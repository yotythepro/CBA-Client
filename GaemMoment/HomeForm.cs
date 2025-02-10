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
        /// <summary>
        /// Initializes the form and a connection to the database.
        /// </summary>
        private HomeForm()
        {
            InitializeComponent();
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
            string gender = "", pronoun1 = "", pronoun2 = "";
            bool genderSpecified = true;
            switch(GenderListBox.SelectedIndex)
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
    }
}
