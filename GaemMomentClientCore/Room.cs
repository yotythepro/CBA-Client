using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaemMoment
{
    public class Room
    {
        public string Name { get; }
        public string RoomCode { get; }
        public string CreatorUserName { get; }

        public Room(string name, string roomCode, string creatorUserName)
        {
            Name = name;
            RoomCode = roomCode;
            CreatorUserName = creatorUserName;
        }
    }
}
