using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace GaemMomentServer {
    /// <summary>
    /// Main class running the server.
    /// </summary>
    internal class Program {
        readonly static int port = 5000;
        readonly IDictionary<TcpClient, Player> players = new Dictionary<TcpClient, Player>();
        readonly TcpListener server = new TcpListener(IPAddress.Any, port);

        /// <summary>
        /// Ensures the server start up on program execution.
        /// </summary>
        static void Main() {
            Program main = new Program();
            main.ServerStart();  //starting the server

            Console.ReadLine();
        }

        /// <summary>
        /// Starts up the server.
        /// </summary>
        private void ServerStart() {
            server.Start();
            AcceptConnection();  //accepts incoming connections
        }

        /// <summary>
        /// Accepts a TCP connection and passes it to <see cref="HandleConnection"/>.
        /// </summary>
        private void AcceptConnection() {
            server.BeginAcceptTcpClient(HandleConnection, server);  //this is called asynchronously and will run in a different thread
        }

        /// <summary>
        /// Starts reading from a TCP client and lets the server accept new incoming connection.
        /// </summary>
        /// <param name="result">Asyncronous result of the last calling of <see cref="AcceptConnection"/>.</param>
        private void HandleConnection(IAsyncResult result)  //the parameter is a delegate, used to communicate between threads
        {
            AcceptConnection();  //once again, checking for any other incoming connections
            TcpClient client = server.EndAcceptTcpClient(result);  //creates the TcpClient

            NetworkStream ns = client.GetStream();

            /* here you can add the code to send/receive data */
            Console.WriteLine("new socket: " + client.Client.RemoteEndPoint.ToString());
            byte[] buffer = new byte[client.ReceiveBufferSize];
            CallbackArgs args = new CallbackArgs(ns, buffer, client);
            ns.BeginRead(buffer,
                                          0,
                                          System.Convert.ToInt32(client.ReceiveBufferSize),
                                          ReceiveMessage,
                                          args);
        }

        /// <summary>
        /// Recieves a message from a client and handles it.
        /// Calls itself asyncronously at the end to keep recieving messages.
        /// </summary>
        /// <param name="ar">Asyncronous result of the last calling of <c>ReceiveMessage</c>.</param>
        private void ReceiveMessage(IAsyncResult ar)
        {
            int bytesRead;
            CallbackArgs args = (CallbackArgs)ar.AsyncState;
            TcpClient cl = args.Client;
            Byte[] data = args.Buffer;
            NetworkStream ns = args.Stream;
            try
            {
                lock (cl.GetStream())
                {
                    // call EndRead to handle the end of an async read.
                    bytesRead = cl.GetStream().EndRead(ar);
                }
                if (bytesRead < 1)
                {
                    // remove the client from out list of clients
                    players.Remove(cl);
                    return;
                }
                Player pl = null;
                if (players.ContainsKey(cl))
                    pl = players[cl];
                string messageReceived = System.Text.Encoding.ASCII.GetString(data, 0, bytesRead);
                Console.WriteLine($"{cl.Client.RemoteEndPoint} {messageReceived}");
                switch (messageReceived[0])
                {
                    case 'R':
                        pl.TurnRight(); break;
                    case 'L':
                        pl.TurnLeft(); break;
                    case 'J':
                        pl.Jump(); break;
                    case 'S':
                        pl.xSpeed = 0; break;
                    case 'A':
                        pl.Attack(); break;
                    case 'P':
                        AddPlayer(cl); break;
                    case 'D':
                        DBConn conn = new DBConn();
                        SendMessage(conn.ParseMessage(messageReceived.Substring(1)), cl);
                        break;

                }

                args = new CallbackArgs(ns, data, cl);
                lock (cl.GetStream())
                {
                    // continue reading form the client
                    cl.GetStream().BeginRead(data, 0, System.Convert.ToInt32(cl.ReceiveBufferSize), ReceiveMessage, args);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        /// Broadcasts game state to all clients 30 times each second.
        /// </summary>
        private void Update()
        {
            TimeSpan deltaTime;
            DateTime oldTime = DateTime.Now;
            double accumulator = 0;
            while (true)
            {
                deltaTime = DateTime.Now - oldTime;
                oldTime = DateTime.Now;
                accumulator += deltaTime.TotalSeconds;
                while (accumulator > 1.0 / 30.0)
                {
                    BroadCast(PlayersString());
                    accumulator -= 1.0 / 30.0;
                }
            }
        }

        /// <summary>
        /// Generates string containing all player information to produce a game state.
        /// </summary>
        /// <returns>The string generated.</returns>
        private string PlayersString()
        {
            String res = "{";
            foreach (Player pl in players.Values)
            {
                res += pl;
            }
            res += "}";
            return res;
        }

        /// <summary>
        /// Sends a message to a client.
        /// </summary>
        /// <param name="message">Message to send.</param>
        /// <param name="cl">Client to send message to.</param>
        private void SendMessage(string message, TcpClient cl)
        {
            try
            {
                // send message to the server
                byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
                NetworkStream ns = cl.GetStream();
                // send the text
                ns.Write(data, 0, data.Length);
                ns.Flush();
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Sends a message to all connected clients.
        /// </summary>
        /// <param name="message"></param>
        private void BroadCast(string message)
        {
            foreach (TcpClient cl in players.Keys.ToList())
            {
                SendMessage(message, cl);
            }
        }

        /// <summary>
        /// Adds a <c>Player</c> to the game.
        /// </summary>
        /// <param name="client">Client controlling said player.</param>
        private void AddPlayer(TcpClient client)
        {
            if (players.Count == 0)
            {
                players.Add(client, new Player(-3, 0, true));
                Task.Run(() => Update());
            }
            else if (players.Count == 1)
                players.Add(client, new Player(3, 0, false));
        }
    }
}
