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
        BoardData boardData;
        public Form1()
        {
            InitializeComponent();
            ShowChessBoard();
        }

        private void ShowChessBoard()
        {
            //pieceUis = new PieceUi[Const.RowCount, Const.ColCount];

            //for (var i = 0; i < 8; i++)
            //    for (var j = 0; j < 8; j++)
            //    {
            //        PieceUi ui = new PieceUi();
            //        ui.Location = new Point(10 + 50*i, 10 + 50*j);
            //        if ((i % 2 + j % 2) % 2 == 0)
            //            ui.BackColor = Const.ColorWhiteTile;
            //        else ui.BackColor = Const.ColorBlackTile;
            //        Controls.Add(ui);
            //        pieceUis[i, j] = ui;
            //    }

            //List<Piece> listPiece = boardData.ListPiece;
            //for (int i = 0; i < listPiece.Count; i++)
            //{
            //    Cell pos = listPiece[i].GetPosition();
            //    pieceUis[pos.row, pos.col].SetPiece(listPiece[i]);
            //}
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
