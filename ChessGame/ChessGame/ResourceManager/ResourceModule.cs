using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.ResourceManager
{
    class ResourceModule
    {
        private ResourceModule() { }
        public static ResourceModule instance = null;
        PieceStrategy pieceStrategy = new PieceStrategy(new BasicPiece());
        public static ResourceModule GetInstance()
        {
            if (instance == null)
            {
                instance = new ResourceModule();
            }
            return instance;
        }

        public Bitmap GetPieceResourceByType(PieceType type, PieceSide color)
        {
            PIECE pieceAdapt = PIECE.BlackKnight;
            if (color == PieceSide.Black)
            {
                switch (type)
                {
                    case PieceType.Bishop: pieceAdapt = PIECE.BlackBishop; break;
                    case PieceType.Rook: pieceAdapt = PIECE.BlackRook; break;
                    case PieceType.Knight: pieceAdapt = PIECE.BlackKnight; break;
                    case PieceType.Queen: pieceAdapt = PIECE.BlackQueen; break;
                    case PieceType.King: pieceAdapt = PIECE.BlackKing; break;
                    case PieceType.Pawn: pieceAdapt = PIECE.BlackPawn; break;
                }
            }
            else
            {
                switch (type)
                {
                    case PieceType.Bishop: pieceAdapt = PIECE.WhiteBishop; break;
                    case PieceType.Rook: pieceAdapt = PIECE.WhiteRook; break;
                    case PieceType.Knight: pieceAdapt = PIECE.WhiteKnight; break;
                    case PieceType.Queen: pieceAdapt = PIECE.WhiteQueen; break;
                    case PieceType.King: pieceAdapt = PIECE.WhiteKing; break;
                    case PieceType.Pawn: pieceAdapt = PIECE.WhitePawn; break;
                }
            }
            return this.pieceStrategy.GetPiece(pieceAdapt);
        }
    }
}
