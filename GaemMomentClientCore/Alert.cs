using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GaemMoment
{
    internal class Alert
    {
        public AlertType Type { get; set; }
        public string PlayerUsername { get; set; }

        public void Handle()
        {
            switch (Type)
            {
                case AlertType.PLAYER_JOIN:
                    MainForm.Instance.Invoke(new Action(() => MainForm.Instance.gameTab.UpdateOpponentName(PlayerUsername)));
                    break;
                default:
                    MessageBox.Show("Unrecognized Alert"); break;
            }
        }
    }
}
