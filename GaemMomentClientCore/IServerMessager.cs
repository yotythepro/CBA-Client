using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaemMoment
{
    public interface IServerMessager
    {
        void ParseMessage(string text);
    }
}
