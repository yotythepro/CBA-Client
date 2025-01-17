using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GaemMomentServer
{
    internal class RoomHandler
    {
        private static List<Room> _rooms = new List<Room>();
        public static List<Room> Rooms { get { return _rooms; } }
        const int CODE_LENGTH = 5;
        const string CODE_CHARACTERS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

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

        public static List<EncapsulatedRoom> Encapsulate(List<Room> rooms)
        {
            return Rooms.Select(room => new EncapsulatedRoom(room)).ToList();
        }

        public static string GenerateCode()
        {
            char[] stringChars = new char[CODE_LENGTH];
            Random random = new Random();

            for (int i = 0; i < CODE_LENGTH; i++)
            {
                stringChars[i] = CODE_CHARACTERS[random.Next(CODE_CHARACTERS.Length)];
            }

            return new String(stringChars);
        }
    }
}
