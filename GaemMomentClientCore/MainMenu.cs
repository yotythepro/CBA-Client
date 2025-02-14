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
    public partial class MainMenu : TabChangingControl
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void PlayOnlineButton_Click(object sender, EventArgs e)
        {
            ChangeTab(Tab.ROOM_SELECTOR);
        }

        private void PlayOfflineButton_Click(object sender, EventArgs e)
        {
            ChangeTab(Tab.GAME);
        }
    }
}
