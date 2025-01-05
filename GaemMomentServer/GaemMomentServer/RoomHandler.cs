using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaemMomentServer
{
    internal class RoomHandler
    {
        private static List<Room> _rooms = new List<Room>();
        public static List<Room> Rooms { get { return _rooms; } }

        public static Room GetRoomByCode(string code)
        {
            foreach (Room room in Rooms)
            {
                if (room.RoomCode == code) return room;
            }
            return null;
        }

        public static List<Room> GetPublicRooms()
        {
            return Rooms.Where(room => !room.IsPrivate).ToList();
        }
    }
}
