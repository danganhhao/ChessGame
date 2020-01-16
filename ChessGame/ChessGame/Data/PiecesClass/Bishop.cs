﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Data.PiecesClass
{
    class Bishop:Piece
    {
        public Bishop(PieceSide side, bool isMoved = false) : base(side, PieceType.BISHOP, isMoved)
        {
        }

        public override List<Point> GetPossibleMove()
        {
            List<Point> ArrPossibleMove = new List<Point>();

            return ArrPossibleMove;
        }
    }
}
