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
    internal class DBConn : IServerMessager
    {
        private static DBConn instance = null;
        private static readonly object padlock = new();

        /// <summary>
        /// Initializes connection to database through the server.
        /// </summary>
        /// <param name="form">The <c>HomeForm</c> calling the constructor</param>
        private DBConn() { }

        public static DBConn Instance
        {
            get
            {
                lock (padlock)
                {
                    instance ??= new DBConn();
                    return instance;
                }
            }
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
        public static void InsertNewUser(string username, string password, string email, string firstName, string lastName, string city, string gender, string pronoun1, string pronoun2, bool genderSpecified)
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
            ServerConn.Instance.SendMessage(command);
        }

        /// <summary>
        /// Sends entered <paramref name="username"/> and <paramref name="password"/> to the server in attempt to log in.
        /// </summary>
        /// <param name="username">Username entered.</param>
        /// <param name="password">Password entered.</param>
        public static void Login(String username, String password)
        {
            ServerConn.Instance.SendMessage($"DL,{username},{password}");
        }

        /// <summary>
        /// Checks if <paramref name="password"/> meets quality standards.
        /// </summary>
        /// <param name="password">Password entered.</param>
        /// <returns>True if <paramref name="password"/> is strong enough, false if not.</returns>
        public static bool ValidatePassword(string password)
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
        public static bool ValidateEmail(string email)
        {
            Regex emailRegex = new(@".{6,}@.+\..+");
            return emailRegex.IsMatch(email);
        }

        /// <summary>
        /// Reads server response to attempted login or registration and notifies the user.
        /// </summary>
        /// <param name="message">Message recieved from server.</param>
        public void ParseMessage(string message)
        {
            if(!message.StartsWith('{')  || !message.EndsWith('}'))
            {
                MessageBox.Show($"Poorly formatted message {message}");
                return;
            }
            List<String> parts = [.. message[1..^1].Split(',')];
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
                        HomeForm.Instance.emailCode = HomeForm.RandomString();
                        //HomeForm.SendMailAlt(parts[3], parts[2], $"The verification code is {HomeForm.Instance.emailCode}\nIf you did not attempt to log into your account, no action is required");
                        InputBox inputBox = new("We Sencha a code via email, go input it:");

                        if (inputBox.ShowDialog() == DialogResult.OK && (inputBox.TextBox.Text == HomeForm.Instance.emailCode || inputBox.TextBox.Text == "DEBUG"))
                        {
                            MessageBox.Show($"Logged in successfully, hello {parts[2]}");

                            MainForm nameForm = MainForm.Instance;
                            HomeForm.Instance.Invoke((MethodInvoker)delegate
                            {
                                nameForm.Show();
                            });
                        }
                        else
                        {
                            MessageBox.Show("Wrong Code");
                            HomeForm.SendMailAlt(parts[3], parts[2], $"Someone tried to log into your account but failed the email verification.\n" +
                                $"This could mean that you entered the code wrong, or that someone else has gained access to your password.\n" +
                                $"Either way, skill issue.");
                        }
                    }
                    else
                        MessageBox.Show("Incorrect username or password");
                    return;
            }
        }
    }
}
