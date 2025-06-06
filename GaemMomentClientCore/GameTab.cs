using Chess;
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
        public ChessBoard Board;
        public PieceColor color = PieceColor.White;
        public Position? LastClickedPosition = null;
        public bool isReplay = false;

        public GameTab()
        {
            InitializeComponent();
        }

        public void UpdateRoom(Room room)
        {
            label1.Text = $"Room code: {room.RoomCode}\nRoom name: {room.Name}\nRoom creator: {room.CreatorUserName}";
            HideEndingOptions();
            isReplay = false;
        }

        public void UpdateOpponentName(string opponentName)
        {
            label2.Text = $"VS: {opponentName}";
        }

        public void UpdateGraphics()
        {
            BoardGraphic.LoadPosition(Board);
        }

        private static string ToCoordinateNotation(Move move)
        {
            return move.OriginalPosition.ToString() + move.NewPosition.ToString();
        }

        private static Move FromCoordinateNotation(string move)
        {
            return new Move(move[..2], move[2..]);
        }

        public void RecieveMove(string moveText)
        {
            if (Board.Turn == color)
            {
                MessageBox.Show("Your opponent has attempted to move on your turn, if you are trying to play a modified version of the game, please make sure you both have the same modifications enabled.");
                return;
            }
            bool isValid;
            Move move = null;
            try
            {
                move = FromCoordinateNotation(moveText);
                isValid = Board.IsValidMove(move);
            }
            catch
            {
                isValid = false;
            }
            if (isValid)
            {
                Board.Move(move);
                UpdateGraphics();
                CheckEnd();
            }
            else
            {
                MessageBox.Show($"Your opponent has attempted to perform the illegal move {moveText[..2]} to {moveText[2..]}, if you are trying to play a modified version of the game," +
                    $" please make sure you both have the same modifications enabled.");
            }
        }

        public void ClickPosition(Position position)
        {
            if (!Board.IsLastMoveDisplayed || Board.Turn != color || isReplay)
                return;
            if (LastClickedPosition == null)
            {
                if (Board[position] != null && Board[position].Color == color)
                {
                    LastClickedPosition = position;
                    foreach (Move m in Board.Moves(position))
                    {
                        Square.GetSquare(m.NewPosition).Highlight();
                    }
                    UpdateGraphics();
                }
                return;
            }
            Square.UnmarkAll();
            bool isValid;
            Move move = null;
            try
            {
                move = new Move((Position)LastClickedPosition, position);
                isValid = Board.IsValidMove(move);
            }
            catch
            {
                isValid = false;
            }
            if (isValid)
            {
                Invoke(new Action(() => Board.Move(move)));
                ServerConn.Instance.SendMessage($"M{ToCoordinateNotation(move)}");
            }
            UpdateGraphics();
            CheckEnd();
            LastClickedPosition = null;
        }

        public void CheckEnd()
        {
            if (Board.IsEndGame)
            {
                ShowEndingOptions();
                if (Board.EndGame.WonSide == null)
                    MessageBox.Show("Game ended in a draw");
                else if (Board.EndGame.WonSide == color)
                    MessageBox.Show("Game ended, you won");
                else
                    MessageBox.Show("Game ended, you lost");

            }
        }

        public void ShowEndingOptions()
        {
            ShowButton(DownloadBtn);
        }

        public void HideEndingOptions()
        {
            HideButton(DownloadBtn);
        }

        public void ShowButton(Button btn)
        {
            btn.Enabled = true;
            btn.Visible = true;
        }

        public void HideButton(Button btn)
        {
            btn.Enabled = false;
            btn.Visible = false;
        }

        private void DownloadBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "PGN File|*.pgn";
            saveFileDialog1.Title = "Save Replay";
            saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog1.FileName != "")
            {
                // Saves the Image via a FileStream created by the OpenFile method.
                System.IO.FileStream fs =
                    (System.IO.FileStream)saveFileDialog1.OpenFile();

                string tempString = Board.ToPgn();

                fs.Write(Encoding.UTF8.GetBytes(tempString), 0, Encoding.UTF8.GetByteCount(tempString));
                fs.Flush();
                fs.Close();
            }
        }

        public void LoadPGNPosition(string pgn)
        {
            label1.Text = "";
            label2.Text = "";
            isReplay = true;
            HideEndingOptions();
            if (!MainForm.Instance.BoardLoaded)
            {
                Images.Load();
                BoardGraphic.DrawBoard(0, 0);
                MainForm.Instance.BoardLoaded = true;
            }
            Board = ChessBoard.LoadFromPgn(pgn);
            UpdateGraphics();
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Board.Previous();
                UpdateGraphics();
            }
            catch { }

        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Board.First();
                UpdateGraphics();
            }
            catch { }
        }

        private void NextBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Board.Next();
                UpdateGraphics();
            }
            catch { }
        }

        private void EndBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Board.Last();
                UpdateGraphics();
            }
            catch { }
        }
    }
}
