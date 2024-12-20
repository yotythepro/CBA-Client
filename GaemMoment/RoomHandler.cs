using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaemMoment
{
    internal static class RoomHandler
    {
        private static List<Room> _rooms = new List<Room>();
        public static List<Room> Rooms { get { return _rooms; } }

        public static void UpdateRooms()
        {
            Rooms.Clear();
            Rooms.AddRange(new Room[] {
                new Room(
                    "Roomie Room",
                    "15TROOM",
                    "yotythepro"
                ),
                new Room(
                    "Woooo",
                    "0TH3RRO0M",
                    "nameOfTheUser"
                )
            });
        }
    }
}
