using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaemMomentServer
{
    internal class Alert
    {
        public AlertType type { get; set; }
        public string playerUsername { get; set; }

        public Alert(AlertType type, string playerUsername)
        {
            this.type = type;
            this.playerUsername = playerUsername;
        }
    }
}
