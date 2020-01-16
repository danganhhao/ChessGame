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
            if (color == PieceSide.BLACK)
            {
                switch (type)
                {
                    case PieceType.BISHOP: pieceAdapt = PIECE.BlackBishop; break;
                    case PieceType.ROOK: pieceAdapt = PIECE.BlackRook; break;
                    case PieceType.KNIGHT: pieceAdapt = PIECE.BlackKnight; break;
                    case PieceType.QUEEN: pieceAdapt = PIECE.BlackQueen; break;
                    case PieceType.KING: pieceAdapt = PIECE.BlackKing; break;
                    case PieceType.PAWN: pieceAdapt = PIECE.BlackPawn; break;
                }
            }
            else
            {
                switch (type)
                {
                    case PieceType.BISHOP: pieceAdapt = PIECE.WhiteBishop; break;
                    case PieceType.ROOK: pieceAdapt = PIECE.WhiteRook; break;
                    case PieceType.KNIGHT: pieceAdapt = PIECE.WhiteKnight; break;
                    case PieceType.QUEEN: pieceAdapt = PIECE.WhiteQueen; break;
                    case PieceType.KING: pieceAdapt = PIECE.WhiteKing; break;
                    case PieceType.PAWN: pieceAdapt = PIECE.WhitePawn; break;
                }
            }
            return this.pieceStrategy.GetPiece(pieceAdapt);
        }
    }
}
