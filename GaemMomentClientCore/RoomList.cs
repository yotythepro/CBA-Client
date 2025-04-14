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
            RoomHandler.SendRequest(Request.GetRequest());
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            ChangeTab(Tab.MAIN_MENU);
        }

        private void CreateRoomButton_Click(object sender, EventArgs e)
        {
            InputBox inputBox = new("Enter Room Name:");

            if (inputBox.ShowDialog() == DialogResult.OK)
            {
                RoomHandler.SendRequest(Request.CreateRequest(!publicRoomCheckbox.Checked, inputBox.TextBox.Text));
            }
        }

        private void RefreshListButton_Click(object sender, EventArgs e)
        {
            RoomHandler.SendRequest(Request.GetRequest());
        }

        private void JoinRoomButton_Click(object sender, EventArgs e)
        {
            Room room = RoomHandler.Rooms[RoomSelectionList.SelectedIndices[0]];
            RoomHandler.SendRequest(Request.JoinRequest(room.RoomCode));
        }

        private void JoinPrivateRoomButton_Click(object sender, EventArgs e)
        {
            InputBox inputBox = new("Enter Room ID:");

            if (inputBox.ShowDialog() == DialogResult.OK)
            {
                RoomHandler.SendRequest(Request.JoinRequest(inputBox.TextBox.Text));
            }
        }

        public void UpdateList(List<Room> newRoomList)
        {
            RoomSelectionList.Items.Clear();
            foreach (Room room in newRoomList)
            {
                RoomSelectionList.Items.Add(new ListViewItem([room.CreatorUserName, room.Name]));
            }
            RoomHandler.UpdateRooms(newRoomList);
        }
    }
}
