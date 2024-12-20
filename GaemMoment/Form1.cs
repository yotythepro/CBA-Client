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
    public partial class Form1 : Form
    {
        Conn connection;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection = new Conn();
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
            connection.InsertNewUser(
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

        private void loginBtn_Click(object sender, EventArgs e)
        {
            connection = new Conn();
            if (connection.Exists(UsernameBox.Text, PasswordBox.Text))
            {
                MessageBox.Show("Logged in successfully");
            }
            else
            {
                MessageBox.Show("Incorrect username or password");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadCities();
        }

        private void LoadCities()
        {
            CityBox.Items.Clear();
            foreach (City city in Enum.GetValues(typeof(City)))
            {
                CityBox.Items.Add(city);
            }
        }

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

        private void TogglePronounSelect(bool state)
        {
            PronounPrompt.Visible = state; PronounPrompt.Enabled = state;
            PronounSlash.Visible = state; PronounSlash.Enabled = state;
            PronounBox1.Visible = state; PronounBox1.Enabled = state;
            PronounBox2.Visible = state; PronounBox2.Enabled = state;
        }

        private void ToggleGenderSelect(bool state)
        {
            GenderPrompt.Visible = state; GenderPrompt.Enabled = state;
            GenderTextBox.Visible = state; GenderTextBox.Enabled = state;
        }
    }
}
