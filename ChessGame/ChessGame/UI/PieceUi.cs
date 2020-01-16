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
        TileColor color;
        Panel symbolLegalMove;
        internal Piece Piece { get => piece; set => piece = value; }

        public PieceUi(TileColor color)
        {
            this.AddSymbolLegalMove();
            piece = null;
            this.color = color;
            if (color == TileColor.BLACK)
                this.BackColor = Const.ColorBlackTile;
            else this.BackColor = Const.ColorWhiteTile;
            Size = Const.TileSize;
        }

        private void AddSymbolLegalMove()
        {
            symbolLegalMove = new Panel();
            symbolLegalMove.Size = this.Size;
            symbolLegalMove.BackColor = Color.White;
            symbolLegalMove.Visible = false;
            this.Controls.Add(symbolLegalMove);
        }

        public void SetPiece(Piece piece)
        {
            this.piece = piece;
            Bitmap resource = ResourceManager.ResourceModule.GetInstance().GetPieceResourceByType(piece.Type, piece.Side);
            this.BackgroundImage = new Bitmap(resource, this.Size);
        }

        public void SetSelected(bool selected)
        {
            if (this.piece != null)
            {
                if (selected)
                    this.BackColor = this.color == TileColor.BLACK ? Const.ColorBlackHighlightTile : Const.ColorWhiteHighlightTile;
                else this.BackColor = this.color == TileColor.BLACK ? Const.ColorBlackTile : Const.ColorWhiteTile;
            }
        }

        public void SetSymboiLegalMoveVisible(bool visible)
        {
            this.symbolLegalMove.Visible = visible;
        }
    }
}
