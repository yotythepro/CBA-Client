using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaemMomentServer
{
    internal class Response
    {
        public RequestType Type;
        public bool Success;
        public List<EncapsulatedRoom> Body;
        public string ErrorMessage;

        public Response(RequestType type, bool success, List<EncapsulatedRoom> body, string errorMessage)
        {
            Type = type;
            Success = success;
            Body = body;
            ErrorMessage = errorMessage;
        }
    }
}
