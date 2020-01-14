using ChessGame.ResourceManager;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Data.PiecesClass
{
    public class King : Piece
    {
        public King()
        {
        }

        public King(int id, PieceColor color, PieceType type, Position pos) : base(id, color, type, pos)
        {
        }

        protected override void CalcMoveCell()
        {
            throw new NotImplementedException();
        }

        protected override Bitmap GetResource()
        {
            return ResourceModule.GetInstance().GetPieceResourceByType(PieceType.KING, PieceColor.BLACK);
        }

        protected override void InitListAttackCell()
        {
            for (int i = 0; i < 8; i++)
                attackCells.Add(new Position(0, 0));
        }

        protected override void InitListMoveCell()
        {
            for (int i = 0; i < 8; i++)
                attackCells.Add(new Position(0, 0));
        }
    }
}
