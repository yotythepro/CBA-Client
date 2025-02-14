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

        private void SubmitMoveButton_Click(object sender, EventArgs e)
        {
            if (Board.Turn != color)
            {
                MessageBox.Show("It is not your turn");
                return;
            }
            string moveText = moveInputBox.Text;
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
            if (isValid) {
                Invoke(new Action(() => Board.Move(move)));
                UpdateGraphics();
                ServerConn.Instance.SendMessage($"M{moveText}");
                moveInputBox.Text = "";
            } 
            else {
                MessageBox.Show($"Invalid move \"{moveText}\"");
            }
        }

        public void UpdateGraphics()
        {
            boardLabel.Text = Board.ToAscii();
        }

        private string ToCoordinateNotation(Move move)
        {
            return move.OriginalPosition.ToString() + move.NewPosition.ToString();
        }

        private Move FromCoordinateNotation(string move)
        {
            return new Move(move.Substring(0, 2), move.Substring(2));
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
            }
            else
            {
                MessageBox.Show($"Your opponent has attempted to perform the illegal move {moveText.Substring(0,2)} to {moveText.Substring(2)}, if you are trying to play a modified version of the game," +
                    $" please make sure you both have the same modifications enabled.");
            }
        }
    }
}
