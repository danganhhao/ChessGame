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
    class Tile : Panel
    {
        Piece piece;
        Color colorNormal, colorHighlight, colorAvailableMove;
        Point position = new Point(0,0);
        TileState state = TileState.Normal;
        internal Piece Piece { get => piece; set => SetPiece(value); }
        public Point Position { get => position;}
        public TileState State { get => state; }

        public Tile(TileColor color, Point pos)
        {
            this.position = pos;
            piece = null;
            if (color == TileColor.Black)
            {
                this.colorNormal = Const.ColorBlackTile;
                this.colorHighlight = Const.ColorBlackHighlightTile;
                this.colorAvailableMove = Const.ColorLegalBlackTile;
            }
            else
            {
                this.colorNormal = Const.ColorWhiteTile;
                this.colorHighlight = Const.ColorWhiteHighlightTile;
                this.colorAvailableMove = Const.ColorLegalWhiteTile;
            }
            this.BackColor = this.colorNormal;
            Size = Const.TileSize;
        }

        public void SetPiece(Piece piece)
        {
            this.piece = piece;
            if (piece == null)
            {
                this.SetState(TileState.Normal);
                this.BackgroundImage = null;
                return;
            }
            Bitmap resource = ResourceManager.ResourceModule.GetInstance().GetPieceResourceByType(piece.Type, piece.Side);
            this.BackgroundImage = new Bitmap(resource, this.Size);
        }

        public bool IsLegalMove()
        {
            return this.state == TileState.AvalableMove;
        }

        public void SetState(TileState tileState)
        {
            if (tileState == this.state)
                return;
            this.state = tileState;
            if (tileState == TileState.AvalableMove)
                this.BackColor = this.colorAvailableMove;
            else if (tileState == TileState.Selected)
                this.BackColor = this.colorHighlight;
            else this.BackColor = this.colorNormal;
        }
    }
}
