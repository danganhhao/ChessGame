﻿using ChessGame.Data.PiecesClass;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Data
{
    public class BoardData
    {
        Piece[,] arrPiece = new Piece[Const.ColCount, Const.RowCount];
        private static BoardData instance = null;

        public static BoardData GetInstance()
        {
            if (instance == null)
                instance = new BoardData();
            return instance;
        }

        private BoardData()
        {
            for (var i = 0; i < 8; i++)
                for (var j = 0; j < 8; j++)
                    arrPiece[i, j] = null;

            for (int x = 0; x < 8; x++)
            {
                arrPiece[x, 1] = new Pawn(PieceSide.WHITE, new Point(x, 1));
                arrPiece[x, 6] = new Pawn(PieceSide.BLACK, new Point(x, 6));
            }

            arrPiece[0, 0] = new Rook(PieceSide.WHITE, new Point(0, 0));
            arrPiece[7, 0] = new Rook(PieceSide.WHITE, new Point(7, 0));
            arrPiece[0, 7] = new Rook(PieceSide.BLACK, new Point(0, 7));
            arrPiece[7, 7] = new Rook(PieceSide.BLACK, new Point(7, 7));

            arrPiece[1, 0] = new Knight(PieceSide.WHITE, new Point(1, 0));
            arrPiece[6, 0] = new Knight(PieceSide.WHITE, new Point(6, 0));
            arrPiece[1, 7] = new Knight(PieceSide.BLACK, new Point(1, 7));
            arrPiece[6, 7] = new Knight(PieceSide.BLACK, new Point(6, 7));

            arrPiece[2, 0] = new Bishop(PieceSide.WHITE, new Point(2, 0));
            arrPiece[5, 0] = new Bishop(PieceSide.WHITE, new Point(5, 0));
            arrPiece[2, 7] = new Bishop(PieceSide.BLACK, new Point(2, 7));
            arrPiece[5, 7] = new Bishop(PieceSide.BLACK, new Point(5, 7));

            arrPiece[3, 0] = new Queen(PieceSide.WHITE, new Point(3, 0));
            arrPiece[3, 7] = new Queen(PieceSide.BLACK, new Point(3, 7));
            arrPiece[4, 0] = new King(PieceSide.WHITE, new Point(4, 0));
            arrPiece[4, 7] = new King(PieceSide.BLACK, new Point(4, 7));
        }

        internal Piece[,] ArrPiece { get => arrPiece; set => arrPiece = value; }
        public Piece this[int x, int y] { get => GetPieceAt(x, y); }
        public Piece this[Point p] { get => GetPieceAt(p.X, p.Y); }

        public bool CheckPositionInBoard(int x, int y)
        {
            return (x >= 0 && x < 8 && y >= 0 && y < 8);
        }

        internal void MovePiece(Point p1, Point p2)
        {
            Piece piece = arrPiece[p1.X, p1.Y];
            piece.IsMoved = true;
            piece.Position = new Point(p2.X, p2.Y);
            arrPiece[p2.X, p2.Y] = piece;
            arrPiece[p1.X, p1.Y] = null;
        }

        public bool CheckPositionInBoard(Point p)
        {
            return CheckPositionInBoard(p.X, p.Y);
        }

        private Piece GetPieceAt(int x, int y)
        {
            if (CheckPositionInBoard(x, y))
                return arrPiece[x, y];
            return null;
        }

        public bool IsChecked(PieceSide side)
        {
            Point KingPosition = this.GetKingPosition(side);
            return false;
        }

        public bool IsCheckmated(PieceSide side)
        {
            return false;
        }

        public bool IsLegalMove(Point src, Point des)
        {
            //Kiểm tra nước cờ có hợp logic của quân cờ
            Piece pieceSrc = this.arrPiece[src.X, src.Y];
            if (pieceSrc == null || !pieceSrc.IsAvailableMove(des))
                return false;

            //Thử đi nước cờ và kiểm tra xem nước cờ có làm cho quân vua bị chiếu
            PieceSide side = pieceSrc.Side;
            Piece tmp = this.arrPiece[des.X, des.Y]; //Lưu quân cờ ở vị trí mới
            this.arrPiece[des.X, des.Y] = this.arrPiece[src.X, src.Y]; //Chuyển cờ từ vị trí cũ sang vị trí mới
            this.arrPiece[src.X, src.Y] = null; //Xóa quân cờ ở vị trí cũ
            bool result = true;
            if (this.IsChecked(side))
                result = false; //Nếu phe mình bị chiếu, nước đi là không hợp lệ

            //rollback lại trạng thái trước
            this.arrPiece[src.X, src.Y] = this.arrPiece[des.X, des.Y];
            this.arrPiece[des.X, des.Y] = tmp;

            //trả về kết quả
            return result;

            /**
             * TODO: Cài đặt để trả về một trong các kết quả:
             * - Nước đi không hợp lệ (vì vua bị chiếu)
             * - Nước đi hợp lệ và
             *      + Chiếu quân vua của đối phương
             *      + Chiếu bí quân vua của đối phương
             **/
        }

        private Point GetKingPosition(PieceSide side)
        {
            return new Point(4, 0);
        }
    }
}
