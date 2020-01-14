using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Data
{
    class Move
    {
        public int pieceId;
        public Cell srcCell;
        public Cell desCell;

        public Move(int id, Cell src, Cell des)
        {
            this.pieceId = id;
            this.srcCell = src;
            this.desCell = des;
        }
    }
}
