using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaemMomentServer
{
    internal class Alert
    {
        public AlertType Type { get; set; }
        public string PlayerUsername { get; set; }

        public Alert(AlertType type, string playerUsername)
        {
            this.Type = type;
            this.PlayerUsername = playerUsername;
        }
    }
}
