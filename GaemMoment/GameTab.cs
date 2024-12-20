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

        public void UpdateCode(string code)
        {
            label1.Text = $"Room code: {code}";
        }
    }
}
