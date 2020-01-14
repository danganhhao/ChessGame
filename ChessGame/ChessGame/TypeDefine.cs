using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public enum PieceSide
    {
        WHITE = 0,
        BLACK = 1
    }

    public enum PieceType
    {
        KING,
        QUEEN,
        ROOK,
        BISHOP,
        KNIGHT,
        PAWN
    }

    public enum Direction
    {
        UP,
        DOWN
    }

    public static class Const
    {
        //Logic
        public const int RowCount = 8;
        public const int ColCount = 8;

        //UI
        public static Size TileSize = new Size(50, 50);
        public static Color ColorBlackTile = Color.FromArgb(119, 149, 86);
        public static Color ColorWhiteTile = Color.FromArgb(235, 236, 208);
        public static Color ColorBlackHighlightTile = Color.FromArgb(186, 202, 68);
        public static Color ColorWhiteHighlightTile = Color.FromArgb(246, 246, 130);
    }
}
