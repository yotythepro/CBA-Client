using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GaemMoment
{
    public partial class RoomList : TabChangingControl
    {
        public RoomList()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            ChangeTab(Tab.MAIN_MENU);
        }

        private void CreateRoomButton_Click(object sender, EventArgs e)
        {
            Microsoft.VisualBasic.
            ChangeTab(Tab.GAME, "N3WR00M");
        }

        private void RefreshListButton_Click(object sender, EventArgs e)
        {
            RoomHandler.UpdateRooms();
            RoomSelectionList.Clear();
            foreach (Room room in RoomHandler.Rooms)
            {
                RoomSelectionList.Items.Add(new ListViewItem(new string[] { room.CreatorUserName, room.Name }));
            }
        }
    }
}
