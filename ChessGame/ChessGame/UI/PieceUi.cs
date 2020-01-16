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
        Color colorNormal, colorHighlight, colorAvailableMove;
        Point position = new Point(0,0);
        TileState state = TileState.NORMAL;
        Panel symbolLegalMove;
        internal Piece Piece { get => piece; set => piece = value; }
        public Point Position { get => position;}

        public PieceUi(TileColor color, Point pos)
        {
            this.position = pos;
            piece = null;
            if (color == TileColor.BLACK)
            {
                this.colorNormal = Const.ColorBlackTile;
                this.colorHighlight = Const.ColorBlackHighlightTile;
            }
            else
            {
                this.colorNormal = Const.ColorWhiteTile;
                this.colorHighlight = Const.ColorWhiteHighlightTile;
            }
            this.BackColor = this.colorNormal;
            Size = Const.TileSize;
        }

        public void SetPiece(Piece piece)
        {
            this.piece = piece;
            if (piece == null)
            {
                this.SetState(TileState.NORMAL);
                this.BackgroundImage = null;
                return;
            }
            Bitmap resource = ResourceManager.ResourceModule.GetInstance().GetPieceResourceByType(piece.Type, piece.Side);
            this.BackgroundImage = new Bitmap(resource, this.Size);
        }

        public bool IsLegalMove()
        {
            return this.state == TileState.AVAILABLE_MOVE;
        }

        public void SetState(TileState tileState)
        {
            if (tileState == this.state)
                return;
            this.state = tileState;
            if (tileState == TileState.AVAILABLE_MOVE)
                this.BackColor = this.colorAvailableMove;
            else if (tileState == TileState.SELECTED)
                this.BackColor = this.colorHighlight;
            else this.BackColor = this.colorNormal;
        }
    }
}
