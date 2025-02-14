using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaemMomentServer
{
    internal class EncapsulatedRoom
    {
        public string Name { get; }
        public string RoomCode { get; }
        public string CreatorUserName { get; }

        public EncapsulatedRoom(Room room)
        {
            Name = room.Name;
            RoomCode = room.RoomCode;
            CreatorUserName = room.Creator.name;
        }
    }
}
