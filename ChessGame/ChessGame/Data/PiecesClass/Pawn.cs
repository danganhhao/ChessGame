using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Data.PiecesClass
{
    class Pawn : Piece
    {
        int signDirection = 1;
        public Pawn(PieceSide side, Point pos, bool isMoved = false) : base(side, PieceType.Pawn, pos, isMoved)
        {
            this.signDirection = side == PieceSide.White ? 1 : -1;
        }

        public override List<Point> GetPossibleMove()
        {
            List<Point> ArrPossibleMove = new List<Point>();
            BoardData board = BoardData.GetInstance();

            int dy = signDirection * 1;
            List<Point> listMoveBy = new List<Point>() {
                new Point(0, 1 * signDirection),
            };

            if (!this.IsMoved && board[this.Position.X, this.Position.Y + signDirection] == null)
                listMoveBy.Add(new Point(0, 2 * signDirection));

            List<Point> listAttackBy = new List<Point>() {
                new Point(-1, 1 * signDirection),
                new Point(1, 1 * signDirection),
            };

            foreach(Point p in listMoveBy)
            {
                Point newPos = new Point(Position.X + p.X, Position.Y + p.Y);
                if (board.CheckPositionInBoard(newPos.X, newPos.Y))
                {
                    Piece piece = board[newPos];
                    if (piece == null)
                        ArrPossibleMove.Add(newPos);
                }
            }

            foreach (Point p in listAttackBy)
            {
                Point newPos = new Point(Position.X + p.X, Position.Y + p.Y);
                if (board.CheckPositionInBoard(newPos.X, newPos.Y))
                {
                    Piece piece = board[newPos];
                    if (piece != null && piece.Side != this.Side)
                        ArrPossibleMove.Add(newPos);
                }
            }

            return ArrPossibleMove;
        }

        public override bool IsAvailableMove(Point des) {
            BoardData board = BoardData.GetInstance();
            if (!board.CheckPositionInBoard(des.X, des.Y))
                return false;

            //Nếu là nước tấn công: ô tấn công phải có quân và là quân khác phe
            if (des.Y - this.Position.Y == signDirection && Math.Abs(des.X - this.Position.X) == 1)
            {
                Piece piece = board[des];
                if (piece != null && piece.Side != this.Side)
                    return true;
                return false;
            }

            //Nếu là nước di chuyển: ô đó phải trống và nằm trong vùng đi được
            if (des.X == this.Position.X && board[des] == null)
            {
                if (this.IsMoved)
                {
                    return (des.Y - Position.Y == signDirection);
                }
                else
                {
                    return ((des.Y - Position.Y) / signDirection <= 2 && (des.Y - Position.Y) / signDirection >= 1);
                }
            }

            return false;
        }
    }
}
