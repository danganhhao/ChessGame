using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.ResourceManager
{
    class ColorfulPiece : CommonPiece
    {
        public ColorfulPiece() : base()
        {
            
        }
        public override void SetBishopPieceResource()
        {
            pieces.Add(PIECE.BlackBishop, Resource1.RedBishop);
            pieces.Add(PIECE.WhiteBishop, Resource1.GreenBishop);
        }

        public override void SetKingPieceResource()
        {
            pieces.Add(PIECE.BlackKing, Resource1.RedKing);
            pieces.Add(PIECE.WhiteKing, Resource1.GreenKing);
        }

        public override void SetKnightPieceResource()
        {
            pieces.Add(PIECE.BlackKnight, Resource1.RedKnight);
            pieces.Add(PIECE.WhiteKnight, Resource1.GreenKnight);
        }

        public override void SetPawnPieceResource()
        {
            pieces.Add(PIECE.BlackPawn, Resource1.RedPawn);
            pieces.Add(PIECE.WhitePawn, Resource1.GreenPawn);
        }

        public override void SetQueenPieceResource()
        {
            pieces.Add(PIECE.BlackQueen, Resource1.RedQueen);
            pieces.Add(PIECE.WhiteQueen, Resource1.GreenQueen);
        }

        public override void SetRookPieceResource()
        {
            pieces.Add(PIECE.BlackRook, Resource1.RedRook);
            pieces.Add(PIECE.WhiteRook, Resource1.GreenRook);
        }
    }
}
