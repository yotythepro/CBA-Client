using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace GaemMomentServer
{
    internal class CallbackArgs
    {
        public NetworkStream Stream { get; set; }
        public byte[] Buffer { get; set; }
        public TcpClient Client { get; set; }

        public CallbackArgs(NetworkStream stream, byte[] buffer, TcpClient client)
        {
            Stream = stream;
            Buffer = buffer;
            Client = client;
        }
    }
}
