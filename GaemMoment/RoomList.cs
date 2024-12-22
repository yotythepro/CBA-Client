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
            UpdateList();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            ChangeTab(Tab.MAIN_MENU);
        }

        private void CreateRoomButton_Click(object sender, EventArgs e)
        {
            ChangeTab(Tab.GAME, "N3WR00M");
        }

        private void RefreshListButton_Click(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void JoinRoomButton_Click(object sender, EventArgs e)
        {
            ChangeTab(Tab.GAME, RoomHandler.Rooms[RoomSelectionList.SelectedIndices[0]].RoomCode);
        }

        private void JoinPrivateRoomButton_Click(object sender, EventArgs e)
        {
            InputBox inputBox = new InputBox("Enter Room ID:");

            if (inputBox.ShowDialog() == DialogResult.OK)
            {
                ChangeTab(Tab.GAME, inputBox.TextBox.Text);
            }
        }

        private void UpdateList()
        {
            RoomHandler.UpdateRooms();
            RoomSelectionList.Items.Clear();
            foreach (Room room in RoomHandler.Rooms)
            {
                RoomSelectionList.Items.Add(new ListViewItem(new string[] { room.CreatorUserName, room.Name }));
            }
        }
    }
}
