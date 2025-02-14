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
    public partial class GameTab : TabChangingControl
    {
        public GameTab()
        {
            InitializeComponent();
        }

        public void UpdateRoom(Room room)
        {
            label1.Text = $"Room code: {room.RoomCode}\nRoom name: {room.Name}\nRoom creator: {room.CreatorUserName}";
        }

        public void UpdateOpponentName(string opponentName)
        {
            label2.Text = $"VS: {opponentName}";
        }
    }
}
