using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaemMoment
{
    public class Room(string name, string roomCode, string creatorUserName)
    {
        public string Name { get; } = name;
        public string RoomCode { get; } = roomCode;
        public string CreatorUserName { get; } = creatorUserName;
    }
}
