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
        public Queen(PieceSide side, Point pos, bool isMoved = false) : base(side, PieceType.Queen, pos, isMoved)
        {
        }

        public override List<Point> GetPossibleMove()
        {
            List<Point> ArrPossibleMove = new List<Point>();
            CheckLoop(ref ArrPossibleMove, 1, 1);
            CheckLoop(ref ArrPossibleMove, 1, -1);
            CheckLoop(ref ArrPossibleMove, -1, 1);
            CheckLoop(ref ArrPossibleMove, -1, -1);
            CheckLoop(ref ArrPossibleMove, 0, -1);
            CheckLoop(ref ArrPossibleMove, 0, 1);
            CheckLoop(ref ArrPossibleMove, 1, 0);
            CheckLoop(ref ArrPossibleMove, -1, 0);
            return ArrPossibleMove;
        }

        public override bool IsAvailableMove(Point des)
        {
            int dx = des.X - Position.X;
            int dy = des.Y - Position.Y;
            if (dx * dy != 0 && Math.Abs(dx) != Math.Abs(dy))
                return false;
            if (dx != 0)
                dx = dx / Math.Abs(dx);
            if (dy != 0)
                dy = dy / Math.Abs(dy);

            BoardData board = BoardData.GetInstance();
            int x = Position.X;
            int y = Position.Y;
            while (true)
            {
                x += dx;
                y += dy;
                if (x == des.X && y == des.Y)
                    break;
                if (board[x, y] != null)
                    return false;
            }

            return true;
        }

        private void CheckLoop(ref List<Point> arrPossibleMove, int v1, int v2)
        {
            BoardData board = BoardData.GetInstance();
            int x = Position.X;
            int y = Position.Y;
            while (true)
            {
                x += v1;
                y += v2;
                if (!board.CheckPositionInBoard(x, y))
                    return;
                if (board[x, y] == null)
                    arrPossibleMove.Add(new Point(x, y));
                else
                {
                    if (board[x,y].Side != Side)
                        arrPossibleMove.Add(new Point(x, y));
                    return;
                }
            }
        }
    }
}
