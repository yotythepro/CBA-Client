           using Chess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace GaemMoment
{
    internal static class BoardGraphic
    {
        public const int BOARD_SIZE = 8;
        static readonly PictureBox[,] board = new PictureBox[BOARD_SIZE, BOARD_SIZE];
        
        static readonly Dictionary<PieceType, ImageType> PIECE_IMAGES = new()
        {
            {PieceType.Rook, ImageType.Rook},
            {PieceType.King, ImageType.King},
            {PieceType.Pawn, ImageType.Pawn},
            {PieceType.Bishop, ImageType.Bishop},
            {PieceType.Knight, ImageType.Knight},
            {PieceType.Queen, ImageType.Queen}
        };
        public static void DrawBoard(int init_x, int init_y)
        {
            Square.LoadSquares();
            int x = init_x;
            int y = init_y;
            for (short i = BOARD_SIZE - 1; i >= 0; i--)
            {
                for (short j = 0; j < BOARD_SIZE; j++)
                {
                    board[i, j] = new PictureBox
                    {
                        Location = new System.Drawing.Point(x, y),
                        Size = new System.Drawing.Size(60, 60)
                    };
                    short rank = i;
                    short file = j;
                    board[i, j].Click += new EventHandler((sender, e) => OnClick(sender, e, rank, file));
                    Image img = Images.Squares[GetCorrectColor(i, j)][PieceColor.White][ImageType.Empty];
                    board[i, j].Image = img;
                    MainForm.Instance.Invoke(new Action(() => MainForm.Instance.gameTab.Controls.Add(board[i, j])));

                    x += 60;
                }
                x = init_x;
                y += 60;
            }
        }

        public static void OnClick(object sender, EventArgs e, short rank, short file)
        {
            MainForm.Instance.gameTab.ClickPosition(new Position(file, rank));
        }

        public static SquareColor GetCorrectColor(int rank, int file)
        {
            if ((rank + file) % 2 == 0) 
                return SquareColor.DARK;
            else return SquareColor.LIGHT;
        }

        public static SquareColor GetCorrectColor(Position pos)
        {
            return GetCorrectColor(pos.Y, pos.X);
        }

        public static void LoadPosition(ChessBoard loadedBoard)
        {
            for (short i = 0; i < BOARD_SIZE; i++)
            {
                for (short j = 0; j < BOARD_SIZE; j++)
                {
                    Position pos = new(j, i);
                    if (!IsSamePiece(loadedBoard[pos], Square.GetSquare(pos).piece) || Square.GetSquare(pos).ColorChangeNeeded) {
                        Square.GetSquare(pos).piece = loadedBoard[pos];
                        if (loadedBoard[pos] == null)
                        {
                            board[i, j].Image = Images.Squares[Square.GetSquare(pos).color][PieceColor.Black][ImageType.Empty];
                        } 
                        else
                        {
                            board[i, j].Image = Images.Squares[Square.GetSquare(pos).color][loadedBoard[pos].Color][PIECE_IMAGES[loadedBoard[pos].Type]];
                        }
                        Square.GetSquare(pos).ColorChangeNeeded = false;
                    }
                }
            }
        }

        public static bool IsSamePiece(Piece piece1, Piece piece2)
        {
            if (piece1 == null) 
                return piece2 == null;
            else if (piece2 == null) 
                return false;
            return piece1.Color == piece2.Color && piece1.Type == piece2.Type;
        }
    }
}
