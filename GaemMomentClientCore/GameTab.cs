﻿using Chess;
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
            }
            else
            {
                MessageBox.Show($"Your opponent has attempted to perform the illegal move {moveText[..2]} to {moveText[2..]}, if you are trying to play a modified version of the game," +
                    $" please make sure you both have the same modifications enabled.");
            }
        }

        public void ClickPosition(Position position)
        {
            if (Board.Turn != color)
                return;
            if (LastClickedPosition == null)
            {
                if (Board[position] != null && Board[position].Color == color)
                {
                    LastClickedPosition = position;
                    foreach (Move m in Board.Moves(position)) {
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
                move = new Move((Position) LastClickedPosition, position);
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
            LastClickedPosition = null;
        }
    }
}
