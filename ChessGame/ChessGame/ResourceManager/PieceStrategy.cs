using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.ResourceManager
{
    class PieceStrategy
    {
        CommonPiece commonPiece;

        public PieceStrategy(CommonPiece commonPiece)
        {
            this.commonPiece = commonPiece;
        }

        public Bitmap GetPiece(PIECE type)
        {
            return commonPiece.GetPiece(type);
        }

        public void UpdatePieceResource(CommonPiece commonPiece)
        {
            this.commonPiece = commonPiece;
        }
    }
}
