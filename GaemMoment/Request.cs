using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaemMoment
{
    internal class Request
    {
        public RequestType Type;
        public string RoomCodeOrName;
        public bool? IsPrivate;

        private Request(RequestType type, string roomCodeOrName, bool? isPrivate)
        {
            Type = type;
            RoomCodeOrName = roomCodeOrName;
            IsPrivate = isPrivate;
        }

        public static Request JoinRequest(string roomCode)
        {
            return new Request(RequestType.JOIN_ROOM, roomCode, null);
        }

        public static Request CreateRequest(bool isPrivate, string roomName)
        {
            return new Request(RequestType.CREATE_ROOM, roomName, isPrivate);
        }

        public static Request CloseRequest()
        {
            return new Request(RequestType.CLOSE_ROOM, null, null);
        }

        public static Request GetRequest()
        {
            return new Request(RequestType.GET_ROOM_LIST, null, null);
        }
    }
}
