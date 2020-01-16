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
        public Pawn(PieceSide side, bool isMoved = false) : base(side, PieceType.PAWN, isMoved)
        {
        }

        public override List<Point> GetPossibleMove()
        {
            List<Point> ArrPossibleMove = new List<Point>();
            BoardData board = BoardData.GetInstance();

            List<Point> tempMove = new List<Point>();
            int sign = this.Side == PieceSide.WHITE ? 1 : -1;
            if (this.IsMoved)
            {
                int[] dy = new int[2] { 1, 2 };
                for (int i = 0; i < dy.Length; i++)
                {
                    Point newPos = new Point(Position.X, Position.Y + dy[i] * sign);
                    Piece piece = board[newPos];
                    if (piece == null)
                        ArrPossibleMove.Add(newPos);
                }
            }
            else
            {
                Piece piece;
                if (this.Position.Y >= 2 && this.Position.Y <= 7) //Chỉ xét quân tốt ở từ hàng 2 đến 7 (không phải hàng dưới/trên cùng)
                {
                    int dy = sign * 1;
                    //Xét ô trước mặt: phải trống
                    piece = board[this.Position.X, this.Position.Y + dy];
                    if (piece == null)
                        ArrPossibleMove.Add(new Point(this.Position.X, this.Position.Y + dy));

                    //Xét 2 ô chéo 2 bên: có quân khác phe
                    piece = board[this.Position.X + 1, this.Position.Y + dy];
                    if (piece != null && piece.Side != this.Side)
                        ArrPossibleMove.Add(new Point(this.Position.X + 1, this.Position.Y + dy));

                    piece = board[this.Position.X - 1, this.Position.Y + dy];
                    if (piece != null && piece.Side != this.Side)
                        ArrPossibleMove.Add(new Point(this.Position.X - 1, this.Position.Y + dy));
                }
            }

            return ArrPossibleMove;
        }
    }
}
