using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaemMoment
{
    internal class TabSelectEventArgs : EventArgs
    {
        public Tab SelectedTab;
        public string RoomCode;

        public TabSelectEventArgs(Tab selectedTab)
        {
            SelectedTab = selectedTab;
        }

        public TabSelectEventArgs(Tab selectedTab, string roomCode) : this(selectedTab)
        {
            RoomCode = roomCode;
        }
    }
}
