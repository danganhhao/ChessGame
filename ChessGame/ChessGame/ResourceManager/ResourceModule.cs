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
        TileStrategy tileStrategy = new TileStrategy(new BasicTile());
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
            Bitmap bmp = this.pieceStrategy.GetPiece(pieceAdapt);
            return new Bitmap(bmp, Const.TileSize);
        }

        public Bitmap GetTileResource(TileState state, TileColor color)
        {
            TILE tileAdapt = TILE.NormalBlackTile;
            if (color == TileColor.Black)
            {
                switch (state)
                {
                    case TileState.Normal: tileAdapt = TILE.NormalBlackTile; break;
                    case TileState.Selected: tileAdapt = TILE.SelectBlackTile; break;
                    case TileState.LastMove: tileAdapt = TILE.LastMoveBlackTile; break;
                    case TileState.AvailableMove: tileAdapt = TILE.AvalBlackTile; break;
                }
            }
            else
            {
                switch (state)
                {
                    case TileState.Normal: tileAdapt = TILE.NormalWhiteTile; break;
                    case TileState.Selected: tileAdapt = TILE.SelectWhiteTile; break;
                    case TileState.LastMove: tileAdapt = TILE.LastMoveWhiteTile; break;
                    case TileState.AvailableMove: tileAdapt = TILE.AvalWhiteTile; break;
                }
            }
            Bitmap bmp = this.tileStrategy.GetTile(tileAdapt);
            return new Bitmap(bmp, Const.TileSize);
        }
    }
}
