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
        public AlertType type { get; set; }
        public string playerUsername { get; set; }

        public void Handle()
        {
            switch (type)
            {
                case AlertType.PLAYER_JOIN:
                    MainForm.Instance.Invoke(new Action(() => MainForm.Instance.gameTab.UpdateOpponentName(playerUsername)));
                    break;
                default:
                    MessageBox.Show("Unrecognized Alert"); break;
            }
        }
    }
}
