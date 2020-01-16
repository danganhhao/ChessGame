using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Data.PiecesClass
{
    class Bishop :Piece
    {
        public Bishop(PieceSide side, Point pos, bool isMoved = false) : base(side, PieceType.BISHOP, pos, isMoved)
        {
        }

        public override List<Point> GetPossibleMove()
        {
            List<Point> ArrPossibleMove = new List<Point>();
            CheckLoop(ref ArrPossibleMove, 1, 1);
            CheckLoop(ref ArrPossibleMove, 1, -1);
            CheckLoop(ref ArrPossibleMove, -1, 1);
            CheckLoop(ref ArrPossibleMove, -1, -1);
            return ArrPossibleMove;
        }

        private void CheckLoop(ref List<Point> arrPossibleMove, int v1, int v2)
        {
            BoardData board = BoardData.GetInstance();
            int x = Position.X;
            int y = Position.Y;
            while (true)
            {
                x += v1;
                y += v2;
                if (!board.CheckPositionInBoard(x, y))
                    return;
                if (board[x, y] == null)
                    arrPossibleMove.Add(new Point(x, y));
                else
                {
                    if (board[x, y].Side != Side)
                        arrPossibleMove.Add(new Point(x, y));
                    return;
                }
            }
        }
    }
}
