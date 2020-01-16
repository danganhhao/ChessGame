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
        PieceUi[,] pieceUis;
        PieceUi CurrentSelected = null;
        List<PieceUi> LegalPieceUis = new List<PieceUi>();
        BoardData boardData;
        GameManager game = new GameManager();
        public Form1()
        {
            InitializeComponent();
            boardData = BoardData.GetInstance();
            InitBoardUi();
            ShowPiece();
        }

        private void InitBoardUi()
        {

            pieceUis = new PieceUi[Const.ColCount, Const.RowCount];

            int w = Const.TileSize.Width;
            int h = Const.TileSize.Height;
            for (var x = 0; x < 8; x++)
                for (var y = 0; y < 8; y++)
                {
                    TileColor color;
                    if ((x + y) % 2 != 0)
                        color = TileColor.WHITE;
                    else color = TileColor.BLACK;
                    PieceUi ui = new PieceUi(color, new Point(x, y));
                    ui.Location = new Point(w * x, h * (7 - y));
                    ui.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnClickTile);
                    pnlBoard.Controls.Add(ui);
                    pieceUis[x, y] = ui;
                }

            pnlBoard.Width = Const.ColCount * w;
            pnlBoard.Height = Const.RowCount * h;
        }

        private void ShowPiece()
        {
            Piece[,] arrPiece = boardData.ArrPiece;
            for (var x = 0; x < Const.ColCount; x++)
                for (var y = 0; y < Const.RowCount; y++)
                {
                    if (arrPiece[x, y] != null)
                    {
                        pieceUis[x, y].SetPiece(arrPiece[x, y]);
                    }
                }
        }

        private void OnClickTile(object sender, MouseEventArgs e)
        {
            PieceUi selectedTile = (PieceUi)sender;
            if (selectedTile.IsLegalMove())
            {
                if (boardData.IsLegalMove(CurrentSelected.Position, selectedTile.Position))
                {
                    boardData.MovePiece(CurrentSelected.Position, selectedTile.Position);
                    ShowEffectMovePiece(CurrentSelected, selectedTile);
                    DeselectCurrentTile();
                }
            }
            else
            {
                if (CurrentSelected != null)
                {
                    DeselectCurrentTile();
                }
                if (selectedTile.Piece != null)
                {
                    CurrentSelected = selectedTile;
                    CurrentSelected.SetState(TileState.SELECTED);
                    ShowEffectSelectTile();
                }
            }
        }

        private void ShowEffectMovePiece(PieceUi currentSelected, PieceUi selectedTile)
        {
            selectedTile.SetPiece(currentSelected.Piece);
            currentSelected.SetPiece(null);
        }

        private void ShowEffectSelectTile()
        {
            List<Point> legalMoves = CurrentSelected.Piece.GetLegalMove();
            foreach (Point pos in legalMoves)
            {
                LegalPieceUis.Add(pieceUis[pos.X, pos.Y]);
                pieceUis[pos.X, pos.Y].SetState(TileState.AVAILABLE_MOVE);
            }
        }

        private void DeselectCurrentTile()
        {
            CurrentSelected.SetState(TileState.NORMAL);
            CurrentSelected = null;

            foreach (PieceUi pieceUi in LegalPieceUis)
            {
                pieceUi.SetState(TileState.NORMAL);
            }
            LegalPieceUis.Clear();
        }

        //private void InitChessBoard()
        //{
        //    const int distance = 25;
        //    const int tileSize = 50;
        //    const int gridSize = 8;
        //    var clr1 = Color.DarkGray;
        //    var clr2 = Color.White;
        //    chessBoard = new Panel[gridSize, gridSize];
        //    PieceStrategy pieceStrategy = new PieceStrategy(new BasicPiece());
        //    for (var i = 0; i < gridSize; i++)
        //    {
        //        for (var j = 0; j < gridSize; j++)
        //        {
        //            var newPanel = new Panel
        //            {
        //                Size = new Size(tileSize, tileSize),
        //                Location = new Point(tileSize * i + distance, tileSize * j + distance)
        //            };
        //            var bm = new Bitmap(pieceStrategy.GetPiece(PIECE.BlackBishop), new Size(newPanel.Width, newPanel.Height));
        //            newPanel.BackgroundImage = bm;

        //            Controls.Add(newPanel);
        //            chessBoard[i, j] = newPanel;
        //            if (i % 2 == 0)
        //                newPanel.BackColor = j % 2 != 0 ? clr1 : clr2;
        //            else
        //                newPanel.BackColor = j % 2 != 0 ? clr2 : clr1;
        //        }
        //    }
        //}
    }
}
