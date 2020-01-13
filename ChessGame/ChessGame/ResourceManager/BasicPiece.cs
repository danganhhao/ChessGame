using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.ResourceManager
{
    class BasicPiece : CommonPiece
    {
        public BasicPiece() : base()
        {
        }
        public override void SetBishopPieceResource()
        {
            pieces.Add(PIECE.BlackBishop, Resource1.BlackBishop);
            pieces.Add(PIECE.WhiteBishop, Resource1.WhiteBishop);
        }

        public override void SetKingPieceResource()
        {
            pieces.Add(PIECE.BlackKing, Resource1.BlackKing);
            pieces.Add(PIECE.WhiteKing, Resource1.WhiteKing);
        }

        public override void SetKnightPieceResource()
        {
            pieces.Add(PIECE.BlackKnight, Resource1.BlackKnight);
            pieces.Add(PIECE.WhiteKnight, Resource1.WhiteKnight);
        }

        public override void SetPawnPieceResource()
        {
            pieces.Add(PIECE.BlackPawn, Resource1.BlackPawn);
            pieces.Add(PIECE.WhitePawn, Resource1.WhitePawn);
        }

        public override void SetQueenPieceResource()
        {
            pieces.Add(PIECE.BlackQueen, Resource1.BlackQueen);
            pieces.Add(PIECE.WhiteQueen, Resource1.WhiteQueen);
        }

        public override void SetRookPieceResource()
        {
            pieces.Add(PIECE.BlackRook, Resource1.BlackRook);
            pieces.Add(PIECE.WhiteRook, Resource1.WhiteRook);
        }
    }
}
