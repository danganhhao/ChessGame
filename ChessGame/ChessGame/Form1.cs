using ChessGame.ResourceManager;
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
        private Panel[,] chessBoard;
        public Form1()
        {
            InitializeComponent();
            //ShowChessBoard();
        }

        private void ShowChessBoard()
        {
            throw new NotImplementedException();
        }

        private void InitChessBoard()
        {
            const int distance = 25;
            const int tileSize = 50;
            const int gridSize = 8;
            var clr1 = Color.DarkGray;
            var clr2 = Color.White;
            chessBoard = new Panel[gridSize, gridSize];
            for (var i = 0; i < gridSize; i++)
            {
                for (var j = 0; j < gridSize; j++)
                {
                    var newPanel = new Panel
                    {
                        Size = new Size(tileSize, tileSize),
                        Location = new Point(tileSize * i + distance, tileSize * j + distance)
                    };
                    
                    Controls.Add(newPanel);
                    chessBoard[i, j] = newPanel;
                    if (i % 2 == 0)
                        newPanel.BackColor = j % 2 != 0 ? clr1 : clr2;
                    else
                        newPanel.BackColor = j % 2 != 0 ? clr2 : clr1;
                }
            }
        }
    }
}
