using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaemMomentServer
{
    internal class Response
    {
        public RequestType Type { get; set; }
        public bool Success { get; set; }
        public List<EncapsulatedRoom> Body { get; set; }
        public string ErrorMessage { get; set; }

        public Response(RequestType type, bool success, List<EncapsulatedRoom> body, string errorMessage)
        {
            Type = type;
            Success = success;
            Body = body;
            ErrorMessage = errorMessage;
        }
    }
}
