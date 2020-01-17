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
        White = 1,
        Black = 0
    }

    public enum TileColor
    {
        White,
        Black
    }

    public enum PieceType
    {
        None = -1,
        King,
        Queen,
        Rook,
        Bishop,
        Knight,
        Pawn
    }

    public enum GameMode
    {
        TwoPlayers,
        WithComputer,
        OnLan
    }

    public enum TileState
    {
        Normal,
        Selected,
        AvalableMove,
        LastMove
    }

    public enum BoardState
    {
        NoSelectedPiece,
        SelectingAPiece
    }

    public static class Const
    {
        //Logic
        public const int RowCount = 8;
        public const int ColCount = 8;

        //UI
        public static Size TileSize = new Size(70, 70);
        public static Color ColorBlackTile = Color.FromArgb(119, 149, 86);
        public static Color ColorWhiteTile = Color.FromArgb(235, 236, 208);
        public static Color ColorLegalWhiteTile = Color.FromArgb(228, 247, 82);
        public static Color ColorLegalBlackTile = Color.FromArgb(228, 247, 82);
        public static Color ColorBlackHighlightTile = Color.FromArgb(186, 202, 68);
        public static Color ColorWhiteHighlightTile = Color.FromArgb(246, 246, 130);

        public static Color ColorRunningClock = Color.FromArgb(192, 255, 192);
        public static Color ColorPauseClock = SystemColors.Control;
    }

    public struct Position
    {
        public int letter;
        public int number;

        public Position(int letter, int number)
        {
            this.letter = letter;
            this.number = number;
        }
        public Position(Position copy)
        {
            this.letter = copy.letter;
            this.number = copy.number;
        }

        public override bool Equals(object obj)
        {
            return letter == ((Position)obj).letter && number == ((Position)obj).number;
        }
    }

    public struct piece_t
    {
        public PieceType piece;
        public PieceSide player;
        public Position lastPosition;

        public piece_t(PieceType piece, PieceSide player)
        {
            this.piece = piece;
            this.player = player;
            this.lastPosition = new Position(-1, -1);
        }

        public piece_t(piece_t copy)
        {
            this.piece = copy.piece;
            this.player = copy.player;
            this.lastPosition = copy.lastPosition;
        }
    }

    public struct Move
    {
        public Position from;
        public Position to;

        public Move(Position from, Position to)
        {
            this.from = from;
            this.to = to;
        }
    }
}
