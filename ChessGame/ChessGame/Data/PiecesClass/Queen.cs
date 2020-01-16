﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Data.PiecesClass
{
    class Queen : Piece
    {
        public Queen(PieceSide side, Point pos, bool isMoved = false) : base(side, PieceType.QUEEN, pos, isMoved)
        {
        }

        public override List<Point> GetPossibleMove()
        {
            List<Point> ArrPossibleMove = new List<Point>();

            return ArrPossibleMove;
        }
    }
}