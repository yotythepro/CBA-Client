using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace GaemMoment
{
    /// <summary>
    /// Class used to communicate with the database through the server.
    /// </summary>
    internal class DBConn
    {
        readonly ServerConn sv;
        readonly HomeForm form;

        /// <summary>
        /// Initializes connection to database through the server.
        /// </summary>
        /// <param name="form">The <c>HomeForm</c> calling the constructor</param>
        public DBConn(HomeForm form)
        {
            sv = new ServerConn(this);
            this.form = form;
        }

        /// <summary>
        /// Checks validity of registration data entered, and, if valid, sends them to the server in attempt to create a new user. 
        /// </summary>
        /// <param name="username">Username entered.</param>
        /// <param name="password">Password entered.</param>
        /// <param name="email">Email entered.</param>
        /// <param name="firstName">First name entered.</param>
        /// <param name="lastName">Last name entered.</param>
        /// <param name="city">City entered.</param>
        /// <param name="gender">Gender entered.</param>
        /// <param name="pronoun1">First pronoun entered.</param>
        /// <param name="pronoun2">Second pronoun entered.</param>
        /// <param name="genderSpecified">Whether or not a gender was entered.</param>
        public void InsertNewUser(string username, string password, string email, string firstName, string lastName, string city, string gender, string pronoun1, string pronoun2, bool genderSpecified)
        {
            if(username.Length < 2)
            {
                MessageBox.Show("Please choose a longer username");
                return;
            }
            if (firstName.Length < 2)
            {
                MessageBox.Show("Please choose a longer first name");
                return;
            }
            if (lastName.Length < 2)
            {
                MessageBox.Show("Please choose a longer last name");
                return;
            }
            if (!ValidatePassword(password))
            {
                MessageBox.Show("Please choose a stronger password");
                return;
            }
            if (!ValidateEmail(email))
            {
                MessageBox.Show("Please choose a valid email");
                return;
            }
            String command = $"DR," +
                $"'{username}'," +
                $"'{password}'," +
                $"'{email}'," +
                $"'{firstName}'," +
                $"'{lastName}'," +
                $"'{city}'," +
                $"'{pronoun1}'," +
                $"'{pronoun2}'," +
                $"{(genderSpecified ? $"'{gender}'" : "NULL")}";
            sv.SendMessage(command);
        }

        /// <summary>
        /// Sends entered <paramref name="username"/> and <paramref name="password"/> to the server in attempt to log in.
        /// </summary>
        /// <param name="username">Username entered.</param>
        /// <param name="password">Password entered.</param>
        public void Login(String username, String password)
        {
            sv.SendMessage($"DL,{username},{password}");
        }

        /// <summary>
        /// Checks if <paramref name="password"/> meets quality standards.
        /// </summary>
        /// <param name="password">Password entered.</param>
        /// <returns>True if <paramref name="password"/> is strong enough, false if not.</returns>
        public bool ValidatePassword(string password)
        {
            if (!Regex.IsMatch(password, @"[a-z]"))
            {
                return false;
            }
            if (!Regex.IsMatch(password, @"[A-Z]"))
            {
                return false;
            }
            if (!Regex.IsMatch(password, @"\d"))
            {
                return false;
            }
            if (!Regex.IsMatch(password, @"\W|_"))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Checks if <paramref name="email"/> is a valid email.
        /// </summary>
        /// <param name="email">Email entered.</param>
        /// <returns>True if <paramref name="email"/> is valid, false if not.</returns>
        public bool ValidateEmail(string email)
        {
            Regex emailRegex = new Regex(@".{6,}@.+\..+");
            return emailRegex.IsMatch(email);
        }

        /// <summary>
        /// Reads server response to attempted login or registration and notifies the user.
        /// </summary>
        /// <param name="message">Message recieved from server.</param>
        public void ParseMessage(string message)
        {
            if(!message.StartsWith("{")  || !message.EndsWith("}"))
            {
                MessageBox.Show($"Poorly formatted message {message}");
                return;
            }
            List<String> parts = message.Substring(1, message.Length - 2).Split(',').ToList<string>();
            switch(parts[0])
            {
                case "R":
                    if (parts[1] == "T")
                        MessageBox.Show("Registered successfully");
                    else
                        MessageBox.Show("Username already exists");
                    return;
                case "L":
                    if (parts[1] == "T")
                    {
                        MessageBox.Show($"Logged in successfully, hello {parts[2]}");

                        GameForm nameForm = new GameForm();
                        form.Invoke((MethodInvoker)delegate
                        {
                            nameForm.Show();
                        });
                    }
                    else
                        MessageBox.Show("Incorrect username or password");
                    return;
            }
        }
    }
}
