using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Data
{
    class BoardData
    {
        //List<Piece> pieces;
        int idAvailable = 0;

        //public List<Piece> ListPiece { get => pieces; set => pieces = value; }
        Piece[][] gridPiece = new Piece[8][];

        public BoardData()
        {
        }

        public void InitListPiece()
        {
            
        }

        public Piece[][] GetGridPiece()
        {
            return gridPiece;
        }
    }
}
