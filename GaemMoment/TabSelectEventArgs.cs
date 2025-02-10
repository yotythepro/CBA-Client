using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaemMoment
{
    public class TabSelectEventArgs : EventArgs
    {
        public Tab SelectedTab;
        public Room SelectedRoom;

        public TabSelectEventArgs(Tab selectedTab)
        {
            SelectedTab = selectedTab;
        }

        public TabSelectEventArgs(Tab selectedTab, Room room) : this(selectedTab)
        {
            SelectedRoom = room;
        }
    }
}
