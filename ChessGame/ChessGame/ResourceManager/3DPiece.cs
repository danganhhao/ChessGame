using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.ResourceManager
{
    class _3DPiece: CommonPiece
    {
        public _3DPiece() : base()
        {
        }
        public override void SetBishopPieceResource()
        {
            pieces.Add(PIECE.BlackBishop, Resource1.Black_B_3);
            pieces.Add(PIECE.WhiteBishop, Resource1.White_B_3);
        }

        public override void SetKingPieceResource()
        {
            pieces.Add(PIECE.BlackKing, Resource1.Black_K_3);
            pieces.Add(PIECE.WhiteKing, Resource1.White_K_3);
        }

        public override void SetKnightPieceResource()
        {
            pieces.Add(PIECE.BlackKnight, Resource1.Black_N_3);
            pieces.Add(PIECE.WhiteKnight, Resource1.White_N_3);
        }

        public override void SetPawnPieceResource()
        {
            pieces.Add(PIECE.BlackPawn, Resource1.Black_P_3);
            pieces.Add(PIECE.WhitePawn, Resource1.White_P_3);
        }

        public override void SetQueenPieceResource()
        {
            pieces.Add(PIECE.BlackQueen, Resource1.Black_Q_3);
            pieces.Add(PIECE.WhiteQueen, Resource1.White_Q_3);
        }

        public override void SetRookPieceResource()
        {
            pieces.Add(PIECE.BlackRook, Resource1.Black_R_3);
            pieces.Add(PIECE.WhiteRook, Resource1.White_R_3);
        }
    }
}
