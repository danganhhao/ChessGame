using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Data
{
    class BoardData
    {
        List<Piece> pieces;
        int idAvailable = 0;

        public List<Piece> ListPiece { get => pieces; set => pieces = value; }

        public BoardData()
        {
        }

        public void InitListPiece()
        {
            
        }
    }
}
