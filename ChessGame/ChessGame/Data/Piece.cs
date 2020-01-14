using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Data
{
    abstract class Piece
    {
        PieceSide side;
        PieceType type;
        Point position;
        bool isMoved = false;

        public PieceSide Side { get => side; set => side = value; }
        public PieceType Type { get => type; set => type = value; }
        public Point Position { get => position; set => position = value; }
        public bool IsMoved { get => isMoved; set => isMoved = value; }

        public Piece()
        {

        }

        public Piece(PieceSide side, PieceType type, bool isMoved = false)
        {
            this.side = side;
            this.type = type;
            this.isMoved = isMoved;
        }

        public abstract List<Point> GetPossibleMove();

        internal bool IsAvailableMove(Point des)
        {
            return true;
        }
    }
}
