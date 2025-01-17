using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaemMomentServer
{
    internal class Request
    {
        public RequestType Type;
        public string RoomCodeOrName;
        public bool? IsPrivate;
        

        public Response Handle(Player player)
        {
            Room room = RoomHandler.GetRoomByCode(RoomCodeOrName);
            switch (Type)
            {
                case RequestType.CREATE_ROOM:
                    if (IsPrivate == null)
                    {
                        return new Response(Type, false, null, "Room privacy not specified");
                    }
                    if (player.IsInRoom)
                    {
                        return new Response(Type, false, null, "You are already in a room");
                    }
                    room = new Room(RoomCodeOrName, RoomHandler.GenerateCode(), player, (bool) IsPrivate);
                    return new Response(Type, true, RoomHandler.Encapsulate(new List<Room> { room }), null);
                case RequestType.JOIN_ROOM:
                    if (room == null)
                    {
                        return new Response(Type, false, null, "Room does not exist");
                    }
                    if (player.IsInRoom)
                    {
                        return new Response(Type, false, null, "You are already in a room");
                    }
                    if (!room.AddPlayer(player))
                    {
                        return new Response(Type, false, null, "Room is full");
                    }
                    return new Response(Type, true, null, null);
                case RequestType.CLOSE_ROOM:
                    if (room == null)
                    {
                        return new Response(Type, false, null, "Room does not exist or is not owned by you");
                    }
                    if (room.Creator != player)
                    {
                        return new Response(Type, false, null, "Room does not exist or is not owned by you");
                    }
                    room.Close();
                    RoomHandler.Rooms.Remove(room);
                    return new Response(Type, true, null, null);
                case RequestType.GET_ROOM_LIST:
                    return new Response(Type, true, RoomHandler.Encapsulate(RoomHandler.GetPublicRooms()), null);
                default:
                    return new Response(Type, false, null, "Unrecognized request");
            }
        }
    }
}
