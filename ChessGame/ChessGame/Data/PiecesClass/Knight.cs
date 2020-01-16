using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Data.PiecesClass
{
    class Knight : Piece
    {
        public Knight(PieceSide side, Point pos, bool isMoved = false) : base(side, PieceType.Knight, pos, isMoved)
        {
        }

        public override List<Point> GetPossibleMove()
        {
            List<Point> ArrPossibleMove = new List<Point>();
            BoardData board = BoardData.GetInstance();

            int[] dx = new int[8] { 2, 2, 1, 1, -1, -1, -2, -2 };
            int[] dy = new int[8] { -1, 1, -2, 2, 2, -2, 1, -1 };
            for (int i = 0; i < 8; i++)
            {
                Point newPos = new Point(this.Position.X + dx[i], this.Position.Y + dy[i]);
                if (board.CheckPositionInBoard(newPos.X, newPos.Y)) {
                    Piece piece = board[newPos];
                    if (piece == null || piece.Side != this.Side)
                        ArrPossibleMove.Add(newPos);
                }
            }

            return ArrPossibleMove;
        }

        public override bool IsAvailableMove(Point des)
        {
            BoardData board = BoardData.GetInstance();
            if (!board.CheckPositionInBoard(des.X, des.Y))
                return false;
            return (Math.Abs(des.X - Position.X) + Math.Abs(des.Y - Position.Y) == 3);            
        }
    }
}
