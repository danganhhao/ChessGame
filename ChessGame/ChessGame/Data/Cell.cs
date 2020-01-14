using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Data
{
    class Cell
    {
        public int row;
        public int col;

        public Cell(int x, int y)
        {
            this.row = x;
            this.col = y;
        }
    }
}
