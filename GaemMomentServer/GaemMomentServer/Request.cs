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
    }
}
