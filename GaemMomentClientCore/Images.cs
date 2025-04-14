using Chess;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GaemMoment
{
    internal static class Images
    {
        public static Dictionary<SquareColor, Dictionary<PieceColor, Dictionary<ImageType, Image>>> Squares = [];
        static readonly PieceColor[] PIECE_COLORS = [PieceColor.White, PieceColor.Black];
        static readonly Assembly assembly = Assembly.GetExecutingAssembly();


        public static void Load()
        {
            /*foreach (string resourceName in assembly.GetManifestResourceNames())
            {
                MessageBox.Show(resourceName);
            }*/
            foreach (SquareColor squareColor in Enum.GetValues<SquareColor>())
            {
                Squares.Add(squareColor, []);
                foreach (PieceColor pieceColor in PIECE_COLORS)
                {
                    Squares[squareColor].Add(pieceColor, []);
                    foreach (ImageType type in Enum.GetValues<ImageType>())
                    {
                        Stream stream = assembly.GetManifestResourceStream($"GaemMoment.images.Chess_pieces.{GetName(squareColor, pieceColor, type)}.png");
                        Squares[squareColor][pieceColor][type] = new Bitmap(stream);
                    }
                }
            }
        }

        public static string GetName(SquareColor squareColor)
        {
            return squareColor switch
            {
                SquareColor.LIGHT => "Light",
                SquareColor.DARK => "Dark",
                SquareColor.HIGHLIGHT => "Highlight",
                _ => null,
            };
        }

        public static string GetName(SquareColor squareColor, PieceColor pieceColor, ImageType type) 
        {
            if (type == ImageType.Empty)
            {
                return $"{GetName(squareColor)}.Empty";
            }
            return $"{GetName(squareColor)}.{pieceColor.Name}.{type}";
        }
    }
}
