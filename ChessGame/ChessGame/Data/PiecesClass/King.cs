using ChessGame.ResourceManager;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Data.PiecesClass
{
    class King : Piece
    {
        public King(PieceSide side, Point pos, bool isMoved = false) : base(side, PieceType.KING, pos, isMoved)
        {
        }

        public override List<Point> GetPossibleMove()
        {
            List<Point> ArrPossibleMove = new List<Point>();
            BoardData board = BoardData.GetInstance();

            int[] dx = new int[8] { 1, 1, 1, 0, 0, -1, -1, -1 };
            int[] dy = new int[8] { -1, 0, 1, 1, -1, -1, 0, 1 };
            for (int i = 0; i < 8; i++)
            {
                Point newPos = new Point(this.Position.X + dx[i], this.Position.Y + dy[i]);
                if (board.CheckPositionInBoard(newPos.X, newPos.Y))
                {
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
            int dx = Math.Abs(des.X - Position.X);
            int dy = Math.Abs(des.Y - Position.Y);
            int sum = dx * dx + dy * dy;
            return (dx + dy <= 2 && sum != 0);
        }
    }
}
