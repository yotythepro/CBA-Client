using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaemMomentServer
{
    internal class Room
    {
        const int MAX_PLAYER_COUNT = 2;

        public string Name { get; }
        public string RoomCode { get; }
        public Player Creator { get; }
        public bool IsPrivate { get; }
        public List<Player> PlayerList { get; }
        public bool IsFull { get { return PlayerList.Count == MAX_PLAYER_COUNT; } }

        public Room(string name, string roomCode, Player creator, bool isPrivate)
        {
            Name = name;
            RoomCode = roomCode;
            Creator = creator;
            Creator.room = this;
            Creator.IsInRoom = true;
            IsPrivate = isPrivate;
            PlayerList = new List<Player>
            {
                Creator
            };
            RoomHandler.Rooms.Add(this);
        }

        public bool AddPlayer(Player player)
        {
            if (!IsFull)
            {
                PlayerList.Add(player);
                player.IsInRoom = true;
                player.room = this;
                return true;
            }
            return false;
        }

        public void Close()
        {
            foreach (Player player in PlayerList)
            {
                player.IsInRoom = false;
            }
        }
    }
}
