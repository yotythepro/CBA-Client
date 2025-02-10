using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace GaemMomentServer
{
    /// <summary>
    /// Class used to communicate with the database.
    /// </summary>
    internal class DBConn
    {
        readonly string connectionString;
        readonly SqlConnection connection;
        readonly SqlCommand command;

        /// <summary>
        /// Creates connection to database.
        /// </summary>
        public DBConn()
        {
            connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\alonc\Downloads\GaemMoment New\GaemMoment\GaemMomentServer\GaemMomentServer\Database1.mdf"";Integrated Security=True";
            connection = new SqlConnection(connectionString);
            command = new SqlCommand();
        }

        /// <summary>
        /// Checks if a user with given username exists on the database.
        /// </summary>
        /// <param name="username">Username given.</param>
        /// <returns>True if exists, false otherwise.</returns>
        public bool Exists(string username)
        {
            command.CommandText = $"SELECT COUNT(username) FROM TabLPlusRatio WHERE username={username}";
            command.Connection = connection;
            connection.Open();
            int n = (int)command.ExecuteScalar();
            connection.Close();
            return n > 0;
        }

        /// <summary>
        /// Checks if a user with given username and password exists on the database.
        /// </summary>
        /// <param name="username">Given username.</param>
        /// <param name="password">Given password.</param>
        /// <returns>True if exists, false otherwise.</returns>
        public string Exists(string username, string password)
        {
            command.CommandText = $"SELECT firstname FROM TabLPlusRatio WHERE username='{username}' AND password='{password}'";
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            string firstName = "";
            if (reader.Read())
            {
                firstName = reader.GetString(reader.GetOrdinal("firstname"));
            }
            connection.Close();
            return firstName;
        }

        /// <summary>
        /// Reads database request from a client, checks its validity and executes it.
        /// </summary>
        /// <param name="message">Message recieved from client.</param>
        /// <returns>Result to be sent to client.</returns>
        public string ParseMessage(string message, TcpClient cl)
        {
            List<string> parts = message.Split(',').ToList<string>();
            switch (parts[0])
            {
                case "R":
                    if (Exists(parts[1]))
                        return "{R,F}";
                    else
                    {
                        command.CommandText = $"INSERT INTO TabLPlusRatio VALUES({message.Substring(2)})";
                        Console.WriteLine(command.CommandText);
                        command.Connection = connection;
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                        return "{R,T}";
                    }
                case "L":
                    string name = Exists(parts[1], parts[2]);
                    if (name.Length == 0)
                        return "{L,F}";
                    else
                    {
                        Program.AddPlayer(cl, parts[1]);
                        return $"{{L,T,{name}}}";
                    }
            }
            Console.WriteLine($"Incorrectly formatted database message: {message}");
            return "";
        }
    }
}
