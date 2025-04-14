using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace GaemMoment
{
    internal static class RoomHandler
    {
        private static readonly List<Room> _rooms = [];
        public static List<Room> Rooms { get { return _rooms; } }

        public static void UpdateRooms(List<Room> newRoomList)
        {
            Rooms.Clear();
            Rooms.AddRange(newRoomList);
        }

        public static void SendRequest(Request request)
        {
            string message = JsonSerializer.Serialize(request);
            ServerConn.Instance.SendMessage(message);
        }
    }
}
