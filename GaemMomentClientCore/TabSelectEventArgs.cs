using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaemMoment
{
    public class TabSelectEventArgs(Tab selectedTab) : EventArgs
    {
        public Tab SelectedTab = selectedTab;
        public Room SelectedRoom;

        public TabSelectEventArgs(Tab selectedTab, Room room) : this(selectedTab)
        {
            SelectedRoom = room;
        }
    }
}
