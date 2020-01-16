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
        public King(PieceSide side, bool isMoved = false) : base(side, PieceType.KING, isMoved)
        {
        }

        public override List<Point> GetPossibleMove()
        {
            List<Point> ArrPossibleMove = new List<Point>();
            BoardData board = BoardData.GetInstance();

            int[] dx = new int[8] { 1, 1, 1, 0, 0, -1, -1, -1 };
            int[] dy = new int[8] { 0, 0, 0, 1, -1, 0, 0, 0 };
            for (int i = 0; i < 8; i++)
            {
                Point newPos = new Point(this.Position.X + dx[i], this.Position.Y + dy[i]);
                if (newPos.X >= 0 && newPos.Y >= 0 && newPos.X <= Const.ColCount)
                {
                    Piece piece = board[newPos];
                    if (piece == null || piece.Side != this.Side)
                        ArrPossibleMove.Add(newPos);
                }
            }
            return ArrPossibleMove;
        }
    }
}
