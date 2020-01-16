using ChessGame.Data;
using ChessGame.Data.PiecesClass;
using ChessGame.ResourceManager;
using ChessGame.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessGame
{
    public partial class Form1 : Form
    {
        Tile[,] tiles;
        Tile selectedTile;
        List<Tile> availableMoveTiles, lastMoveTiles;
        GameManager gameManager;
        BoardState state;
        PieceSide turn;
        bool isBlocked;

        public Form1()
        {
            InitializeComponent();
            InitFieldValue();
            InitBoardUi();
            LayoutComponent();
        }

        private void InitFieldValue()
        {
            state = BoardState.NoSelectedPiece;
            gameManager = GameManager.GetInstance();
            gameManager.SetForm(this);
            selectedTile = null;
            availableMoveTiles = new List<Tile>();
            lastMoveTiles = new List<Tile>();
            isBlocked = false;
        }

        private void InitBoardUi()
        {
            tiles = new Tile[Const.ColCount, Const.RowCount];
            Piece[,] arrPiece = gameManager.GetArrayPiece();
            int w = Const.TileSize.Width;
            int h = Const.TileSize.Height;
            for (var x = 0; x < 8; x++)
                for (var y = 0; y < 8; y++)
                {
                    TileColor color = GetTileColorAtCoor(x, y);
                    Tile tile = new Tile(color, new Point(x, y));

                    //Set position depend on My piece color
                    if (gameManager.MySide == PieceSide.Black)
                        tile.Location = new Point(Const.TileSize.Width * (7 - x), Const.TileSize.Height * y);
                    else tile.Location = new Point(Const.TileSize.Width * x, Const.TileSize.Height * (7 - y));

                    //Set mouse click handler
                    tile.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnClickTile);

                    //Set piece data
                    if (arrPiece[x, y] != null)
                        tile.SetPiece(arrPiece[x, y]);

                    //Add tile to form and array
                    pnlBoard.Controls.Add(tile);
                    tiles[x, y] = tile;
                }
        }

        internal void SetBlockBoard(bool block)
        {
            isBlocked = block;
        }

        private static TileColor GetTileColorAtCoor(int x, int y)
        {
            TileColor color;
            if ((x + y) % 2 != 0)
                color = TileColor.White;
            else color = TileColor.Black;
            return color;
        }

        internal void SetTurn(PieceSide turn)
        {
            this.turn = turn;
            SwitchRunningClock(turn);
        }

        private void SwitchRunningClock(PieceSide turn)
        {
            //TODO: run and pause clock
        }

        private void LayoutComponent()
        {
            int w = Const.TileSize.Width;
            int h = Const.TileSize.Height;

            int marginRight = 250;
            int marginBottom = 100;

            pnlBoard.Width = Const.ColCount * w;
            pnlBoard.Height = Const.RowCount * h;
            pnlBoard.Location = new Point(30, 30);

            this.Width = pnlBoard.Location.X + marginRight + pnlBoard.Width;
            this.Height = pnlBoard.Location.Y + marginBottom + pnlBoard.Height;
        }

        private void OnClickTile(object sender, MouseEventArgs e)
        {
            if (isBlocked)
                return;
            Tile clickedTile = (Tile)sender;

            //Nếu có ô đang được chọn, xét xem có phải ô clicked là ô di chuyển hợp lệ:
            // + nếu ô clicked là ô di chuyển hợp lệ thì xử lý move_request di chuyển quân cờ
            // + ngược lại, deselect ô hiện tại, chuyển trạng thái sang NoSelectedPiece, xử lý tiếp
            if (state == BoardState.SelectingAPiece)
            {
                if (clickedTile.State == TileState.Selected)
                    return;

                if (clickedTile.State == TileState.AvalableMove)
                    gameManager.ProcessMoveRequest(selectedTile.Position, clickedTile.Position);
                else
                {
                    DeselectSelectedTile();
                    if (CanSelectTile(clickedTile))
                        SetSelectTile(clickedTile);
                }
            }
            //Nếu chưa ô nào được chọn, và ô clicked có quân cờ
            //thì set ô đó là được chọn, hiện các ô di chuyển hợp lệ
            else if (state == BoardState.NoSelectedPiece && CanSelectTile(clickedTile))
            {
                    SetSelectTile(clickedTile);
            }
        }

        private bool CanSelectTile(Tile clickedTile)
        {
            return clickedTile.Piece != null && clickedTile.Piece.Side == this.turn;
        }

        public void DoMove(Point src, Point des)
        {
            DeselectSelectedTile();
            Tile tileDes = tiles[des.X, des.Y];
            Tile tileSrc = tiles[src.X, src.Y];
            tileDes.Piece = tileSrc.Piece;
            tileSrc.Piece = null;
            gameManager.SwitchTurn();
        }

        private void SetSelectTile(Tile clickedTile)
        {
            selectedTile = clickedTile;
            state = BoardState.SelectingAPiece;
            selectedTile.SetState(TileState.Selected);

            List<Point> legalMoves = selectedTile.Piece.GetLegalMove();
            foreach (Point pos in legalMoves)
            {
                Tile legalMoveTile = tiles[pos.X, pos.Y];
                legalMoveTile.SetState(TileState.AvalableMove);
                availableMoveTiles.Add(legalMoveTile);
            }
        }

        private void DeselectSelectedTile()
        {
            if (selectedTile == null)
                return;
            selectedTile.SetState(TileState.Normal);
            selectedTile = null;

            foreach (Tile pieceUi in availableMoveTiles)
                pieceUi.SetState(TileState.Normal);
            availableMoveTiles.Clear();

            state = BoardState.NoSelectedPiece;
        }
    }
}
