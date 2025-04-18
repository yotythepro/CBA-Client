﻿using Chess;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GaemMoment {
    /// <summary>
    /// Class used to communicate with the server.
    /// </summary>
    public class ServerConn {
        readonly static string ip = "127.0.0.1";
        readonly static int port = 5000;
        readonly TcpClient cl;
        readonly NetworkStream ns;
        readonly byte[] data;
        private static ServerConn instance = null;
        private static readonly object padlock = new();
        readonly string PublicKey;
        readonly string PrivateKey;
        string ServerPublicKey;
        readonly string AESKey;
        readonly string IV;
        bool ConnectionInitialized = false;

        /// <summary>
        /// Initializes a new <c>TcpClient</c> and uses it to connect to the server (Used to connect to the game).
        /// </summary>
        /// <param name="fr">The <c>GameForm</c> calling this constructor.</param>
        private ServerConn()
        {
            RSACryptoServiceProvider rsa = new(4096);
            PrivateKey = Encryption.GetKeyString(rsa.ExportParameters(true));
            PublicKey = Encryption.GetKeyString(rsa.ExportParameters(false));
            using (Aes myAes = Aes.Create())
            {
                AESKey = Convert.ToBase64String(myAes.Key);
                IV = Convert.ToBase64String(myAes.IV);
            }
            try {
                cl = new TcpClient();

                cl.Connect(ip, port);
                // use the ipaddress as in the server program

                ns = cl.GetStream();
                data = new byte[cl.ReceiveBufferSize];
                cl.GetStream().BeginRead(data,
                                                 0,
                                                 System.Convert.ToInt32(cl.ReceiveBufferSize),
                                                 ReceiveMessage,
                                                 null);
            }
            catch (Exception e) {
                MessageBox.Show("Error..... " + e.StackTrace);
            }
        }

        public static ServerConn Instance
        {
            get
            {
                lock (padlock)
                {
                    instance ??= new ServerConn();
                    return instance;
                }
            }
        }

        /// <summary>
        /// Sends a message to the server.
        /// </summary>
        /// <param name="message">Message to send to the server.</param>
        public void SendRawMessage(string message)
        {
            try
            {
                // send message to the server
                byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

                // send the text
                ns.Write(data, 0, data.Length);
                ns.Flush();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public async void SendMessage(string message)
        {
            if (!ConnectionInitialized)
            {
                InitializeConnection();
                while (!ConnectionInitialized)
                {
                    await Task.Delay(25);
                }
            }
            SendRawMessage(Encryption.EncryptAES(message, AESKey, IV));
        }

        public void InitializeConnection()
        {
            SendRawMessage(PublicKey);
        }

        /// <summary>
        /// Recieves a message from the server and sends it to 
        /// the respective <c>ParseMessage</c> of the caller of the <c>ServerConn</c> constuctor.
        /// Calls itself asyncronously at the end to keep recieving messages.
        /// </summary>
        /// <param name="ar">Asyncronous result of the last calling of <c>ReceiveMessage</c>.</param>
        private void ReceiveMessage(IAsyncResult ar)
        {
            try
            {
                int bytesRead;

                // read the data from the server
                bytesRead = cl.GetStream().EndRead(ar);

                if (bytesRead < 1)
                {
                    return;
                }
                else
                {
                    // invoke the delegate to display the recived data
                    string textFromServer = System.Text.Encoding.ASCII.GetString(data, 0, bytesRead);
                    if (ConnectionInitialized)
                    {
                        HandleMessage(Encryption.DecryptAES(textFromServer, AESKey, IV));
                    }
                    else
                    {
                        ServerPublicKey = Encryption.DecryptRSA(textFromServer, PrivateKey);
                        SendRawMessage(Encryption.EncryptRSA($"{AESKey},{IV}", ServerPublicKey));
                        ConnectionInitialized = true;
                    }
                }

                // continue reading
                cl.GetStream().BeginRead(data,
                                         0,
                                         System.Convert.ToInt32(cl.ReceiveBufferSize),
                                         ReceiveMessage,
                                         null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private static void HandleMessage(string message)
        {
            char identifier = message[0];
            string body = message[1..];
            switch (identifier)
            {
                case 'R':
                    Response response = JsonSerializer.Deserialize<Response>(body);
                    response?.Handle();
                    break;
                case 'D':
                    DBConn.Instance.ParseMessage(body);
                    break;
                case 'A':
                    Alert alert = JsonSerializer.Deserialize<Alert>(body);
                    alert?.Handle();
                    break;
                case 'M':
                    MainForm.Instance.Invoke(new Action(() => MainForm.Instance.gameTab.RecieveMove(body)));
                    break;
            }
        }
    }
}
