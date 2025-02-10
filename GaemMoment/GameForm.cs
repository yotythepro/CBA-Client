using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GaemMoment
{
    /// <summary>
    /// Window form where the game takes place.
    /// </summary>
    public partial class GameForm : Form, IServerMessager
    {
        const int playerSize = 75;
        const int baseX = 400;
        const int baseY = 300;
        const int playerNum = 2;
        static readonly List<GameForm> PlayerForms = new List<GameForm>();
        readonly List<List<double>> currState = new List<List<double>>();
        readonly List<PictureBox> playerSprites = new List<PictureBox>();
        readonly ServerConn serverConn;
        int walkDir = 0;

        /// <summary>
        /// Makes a new <c>GameForm</c>.
        /// </summary>
        public GameForm()
        {
            InitializeComponent();
            PlayerForms.Add(this);
            serverConn = ServerConn.Instance;
            serverConn.SendMessage("P");
            this.KeyPreview = true;
            for (int i = 0; i < playerNum; i++)
            {
                PictureBox sprite = new PictureBox
                {
                    Size = new Size(playerSize, playerSize),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    BackColor = Color.Transparent
                };
                playerSprites.Add(sprite);
                this.Controls.Add(sprite);
            }
        }

        /// <summary>
        /// Sends any player key press to the server.
        /// </summary>
        /// <param name="sender">Object sending the event.</param>
        /// <param name="e">Key pressed by the player.</param>
        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.A:
                    if (walkDir == 0)
                    {
                        serverConn.SendMessage("L");
                        walkDir = -1;
                    }
                    break;
                case Keys.D:
                    if (walkDir == 0)
                    {
                        serverConn.SendMessage("R");
                        walkDir = 1;
                    }
                    break;
                case Keys.W:
                    serverConn.SendMessage("J");
                    break;
                case Keys.Space:
                    serverConn.SendMessage("A");
                    break;
            }
        }

        /// <summary>
        /// Tells the server when the player stops moving in a certain direction (stops holding a certain key).
        /// </summary>
        /// <param name="sender">Object sending the event.</param>
        /// <param name="e">Key pressed by the player.</param>
        private void GameForm_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    if (walkDir ==  -1)
                    {
                        serverConn.SendMessage("S");
                        walkDir = 0;
                    }
                    break;
                case Keys.D:
                    if (walkDir == 1)
                    {
                        serverConn.SendMessage("S");
                        walkDir = 0;
                    }
                    break;
            }
        }

        /// <summary>
        /// Parses a message from the server into individual game states to be sent to <see cref="ParseGameState"/>.
        /// </summary>
        /// <param name="text">The raw text sent by the server.</param>
        public void ParseMessage(string text)
        {
            int i;
            for (i = 0; i < text.Length; i++)
            {
                if (text[i] == '{')
                {
                    int parseRes = ParseGameState(text.Substring(i + 1));
                    i += parseRes + 1;
                    if (parseRes == -1)
                    {
                        MessageBox.Show($"MESSAGE {text} FORMATED INCORRECTLY");
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Parses a game state sent by <see cref="ParseMessage"/> into individual player states to be sent to <see cref="ParsePlayerState"/>.
        /// Updates current game state displayed by the form on execution.
        /// </summary>
        /// <param name="text">The raw text sent by the server, starting from the game state it's parsing.</param>
        /// <returns>Index in <paramref name="text"/> where the game state ends.</returns>
        public int ParseGameState(string text)
        {
            int i;
            currState.Clear();
            for (i=0; i < text.Length; i++)
            {
                if (text[i] == '}')
                {
                    UpdateState(currState);
                    return i;
                }
                if (text[i] == '{')
                {
                    int parseRes = ParsePlayerState(text.Substring(i + 1));
                    i += parseRes + 1;
                    if (parseRes == -1)
                    {
                        return -1;
                    }
                }
            }
            return -1;
        }

        /// <summary>
        /// Parses a player state sent by <see cref="ParseGameState"/> and adds it to the current game state displayed by the form.
        /// </summary>
        /// <param name="text">The raw text sent by the server, starting from the player state it's parsing.</param>
        /// <returns>Index in <paramref name="text"/> where the player state ends.</returns>
        private int ParsePlayerState(string text)
        {
            int i;
            List<string> vals = new List<string>();
            List<double> playerState = new List<double>();
            string curr = "";
            bool endReached = false;
            for (i = 0; i < text.Length; i++)
            {
                if (text[i] == '}')
                {
                    vals.Add(curr);
                    endReached = true;
                    break;
                }
                if (text[i] == ',')
                {
                    vals.Add(curr);
                    curr = "";
                    continue;
                }
                curr += text[i];
            }
            if (!endReached)
            {
                return -1;
            }
            foreach (string val in vals)
            {
                playerState.Add(double.Parse(val));
            }
            currState.Add(playerState);
            return i;
        }

        /// <summary>
        /// Displays the current game state on the form.
        /// </summary>
        /// <param name="state">Current game state to be used.</param>
        private void UpdateState(List<List<double>> state)
        {
            int i = 0;
            foreach (List<double> player in state)
            {
                this.Invoke(new Action(() => { playerSprites[i].Location = new Point(baseX + (int)(player[0] * playerSize - 0.5 * playerSize), baseY - (int)(player[1] * playerSize + playerSize)); }));
                switch (player[2])
                {
                    case 0:
                    case 4:
                        playerSprites[i].Image = Properties.Resources.FaceRight; break;
                    case 1:
                    case 5:
                        playerSprites[i].Image = Properties.Resources.FaceLeft; break;
                    case 2:
                        playerSprites[i].Image = Properties.Resources.AttackRight; break;
                    case 3:
                        playerSprites[i].Image = Properties.Resources.AttackLeft; break;
                    case 6:
                    case 7:
                    case 10:
                    case 11:
                        playerSprites[i].Image = Properties.Resources.Midair; break;
                    case 8: case 9:
                        playerSprites[i].Image = Properties.Resources.MidairAttack; break;
                    case 12:
                        playerSprites[i].Image = Properties.Resources.Dead; break;

                }
                i++;
            }
        }
    }
}
