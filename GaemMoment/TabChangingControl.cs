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
    public partial class TabChangingControl : UserControl
    {
        public TabChangingControl()
        {
            InitializeComponent();
        }

        [Browsable(true)]
        public event EventHandler TabChange;

        private void OnTabChange(EventArgs e)
        {
            TabChange?.Invoke(this, e);
        }

        protected virtual void ChangeTab(Tab tab)
        {
            OnTabChange(new TabSelectEventArgs(tab));
        }

        protected virtual void ChangeTab(Tab tab, string roomCode)
        {
            OnTabChange(new TabSelectEventArgs(tab, roomCode));
        }
    }
}
