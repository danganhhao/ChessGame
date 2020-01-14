using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Data
{
    abstract class Piece
    {
        protected int id;
        protected PieceColor color;
        protected PieceType type;
        protected List<Position> moveCells;
        protected List<Position> attackCells;
        protected Position position;
        protected bool isMoved;

        public Piece()
        {
        }

        public Piece(int id, PieceColor color, PieceType type, Position pos)
        {
            this.InitListMoveCell();
            this.InitListAttackCell();
            this.id = id;
            this.color = color;
            this.type = type;
            this.SetCell(pos);
        }

        protected abstract void InitListMoveCell();

        public void SetCell(Position pos)
        {
            this.position = pos;
            this.CalcMoveCell();
            this.CalcAttackCell();
        }

        protected abstract void CalcMoveCell();
        protected abstract Bitmap GetResource();

        public List<Position> GetMoveCell()
        {
            return this.moveCells;
        }


        protected virtual void CalcAttackCell() { }
        protected virtual void InitListAttackCell() { }
        public virtual List<Position> GetAttackCell()
        {
            return this.moveCells;
        }
    }
}
