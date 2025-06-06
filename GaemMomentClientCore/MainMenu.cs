using MimeKit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

        private void LoadButton_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "PGN Files (*.pgn)|*.pgn";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
            }

            MainForm.Instance.gameTab.LoadPGNPosition(fileContent);
            ChangeTab(Tab.GAME);
        }
    }
}
