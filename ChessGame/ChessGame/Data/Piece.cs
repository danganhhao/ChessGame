using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Data
{
    public abstract class Piece
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

        public virtual List<Point> GetLegalMove()
        {
            List<Point> res = new List<Point>();
            BoardData board = BoardData.GetInstance();
            List<Point> possibleMove = this.GetPossibleMove();
            foreach(Point p in possibleMove)
            {
                if (board.CheckMove(this.position, p))
                    res.Add(p);
            }
            return res;
        }

        internal bool IsAvailableMove(Point des)
        {
            return true;
        }
    }
}
