using ChessGame.Data;
using ChessGame.ResourceManager;
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
        TileColor color;
        //Color colorNormal, colorHighlight, colorAvailableMove;
        Bitmap bmpNormal, bmpSelected, bmpAvailable, bmpLastMove;
        Panel pnlPiece, pnlExtra, pnlBase;
        Point position = new Point(0,0);
        TileState state = TileState.Normal;
        internal Piece Piece { get => piece; set => SetPiece(value); }
        public Point Position { get => position;}
        public TileState State { get => state; }
        public Panel PnlPiece { get => pnlPiece; set => pnlPiece = value; }

        ResourceModule resourceManage;

        public Tile(TileColor color, Point pos)
        {
            InitFieldValue(color, pos);
            InitBaseResource();
            AddPanels();
            
            //if (color == TileColor.Black)
            //{
            //    this.bmp = Const.ColorBlackTile;
            //    this.colorHighlight = Const.ColorBlackHighlightTile;
            //    this.colorAvailableMove = Const.ColorLegalBlackTile;
            //}
            //else
            //{
            //    this.colorNormal = Const.ColorWhiteTile;
            //    this.colorHighlight = Const.ColorWhiteHighlightTile;
            //    this.colorAvailableMove = Const.ColorLegalWhiteTile;
            //}
            //this.BackColor = this.colorNormal
        }

        private void AddPanels()
        {
            //AddPanel(ref this.pnlExtra);
            AddPanel(ref this.pnlPiece);
            AddPanel(ref this.pnlBase);


            //this.pnlExtra.BackgroundImage = this.bmpSelected;
        }

        private void AddPanel(ref Panel panel)
        {
            panel = new Panel();
            panel.Size = Const.TileSize;
            this.Controls.Add(panel);
        }

        private void InitFieldValue(TileColor color, Point pos)
        {
            this.resourceManage = ResourceModule.GetInstance();
            this.position = pos;
            this.color = color;
            piece = null;
            Size = Const.TileSize;
        }

        private void InitBaseResource()
        {
            this.bmpNormal = this.resourceManage.GetTileResource(TileState.Normal, this.color);
            this.bmpAvailable = this.resourceManage.GetTileResource(TileState.AvailableMove, this.color);
            this.bmpLastMove = this.resourceManage.GetTileResource(TileState.LastMove, this.color);
            this.bmpSelected = this.resourceManage.GetTileResource(TileState.Selected, this.color);
        }

        public void SetPiece(Piece piece)
        {
            this.piece = piece; //data
            if (piece == null)
            {
                this.SetState(TileState.Normal);
                this.pnlPiece.BackgroundImage = null;
                return;
            }
            this.pnlPiece.BackgroundImage = this.resourceManage.GetPieceResourceByType(piece.Type, piece.Side);
        }


        public bool IsLegalMove()
        {
            return this.state == TileState.AvailableMove;
        }

        public void SetState(TileState tileState)
        {
            if (tileState == this.state)
                return;

            this.state = tileState;
            if (tileState == TileState.Normal)
                this.pnlBase.BackgroundImage = this.bmpNormal;
            else if (tileState == TileState.AvailableMove)
                this.pnlBase.BackgroundImage = this.bmpAvailable;
            else if (tileState == TileState.LastMove)
                this.pnlBase.BackgroundImage = this.bmpLastMove;

            if (tileState == TileState.Selected)
                this.pnlExtra.Visible = true;
            else this.pnlExtra.Visible = false;
        }
    }
}
