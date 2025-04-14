using Chess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaemMoment
{
    internal class Square
    {
        public static Square[,] squares = new Square[BoardGraphic.BOARD_SIZE, BoardGraphic.BOARD_SIZE];
        public Position position;
        public SquareColor NaturalColor
        {
            get
            {
                return BoardGraphic.GetCorrectColor(position);
            }
        }
        public SquareColor color;
        public Piece piece;
        public bool ColorChangeNeeded = false;

        public static void LoadSquares()
        {
            for (short i = 0; i < BoardGraphic.BOARD_SIZE; i++)
            {
                for (short j = 0; j < BoardGraphic.BOARD_SIZE; j++)
                {
                    squares[i, j] = new Square(new Position(j, i));
                }
            }
        }

        public Square(Position position)
        {
            this.position = position;
            color = NaturalColor;
            piece = null;
        }

        public static Square GetSquare(Position position)
        {
            return squares[position.Y, position.X];
        }

        public void Highlight()
        {
            color = SquareColor.HIGHLIGHT;
            ColorChangeNeeded = true;
        }

        public void Unmark()
        {
            color = NaturalColor;
            ColorChangeNeeded = true;
        }

        public static void UnmarkAll()
        {
            for (short i = 0; i < BoardGraphic.BOARD_SIZE; i++)
            {
                for (short j = 0; j < BoardGraphic.BOARD_SIZE; j++)
                {
                    squares[i, j].Unmark();
                }
            }
        }
    }
}
