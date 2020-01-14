using ChessGame.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessGame.UI
{
    class PieceUi : Panel
    {
        Piece piece;
        //internal Piece Piece { get => piece; set => piece = value; }
        public PieceUi()
        {
            piece = null;
            Size = Const.TileSize;
        }

        //public void SetPiece(Piece piece)
        //{
        //    this.piece = piece;
        //    this.BackgroundImage = piece.GetResource();
        //}
    }
}
