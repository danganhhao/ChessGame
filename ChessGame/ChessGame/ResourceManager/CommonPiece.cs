using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.ResourceManager
{
    enum PIECE{
        BlackKing, BlackQueen, BlackRook, BlackBishop, BlackKnight, BlackPawn,
        WhiteKing, WhiteQueen, WhiteRook, WhiteBishop, WhiteKnight, WhitePawn
    }

    abstract class CommonPiece
    {
        protected Dictionary<PIECE, Bitmap> pieces = new Dictionary<PIECE, Bitmap>();

        public CommonPiece()
        {
            SetBishopPieceResource();
            SetKingPieceResource();
            SetKnightPieceResource();
            SetPawnPieceResource();
            SetQueenPieceResource();
            SetRookPieceResource();
        }

        public Bitmap GetPiece(PIECE type)
        {
            if (pieces.ContainsKey(type))
            {
                return pieces[type];
            }
            return null;
        }
        public virtual void SetKingPieceResource() { }
        public virtual void SetQueenPieceResource() { }
        public virtual void SetRookPieceResource() { }
        public virtual void SetBishopPieceResource() { }
        public virtual void SetKnightPieceResource() { }
        public virtual void SetPawnPieceResource() { }
    }
}
