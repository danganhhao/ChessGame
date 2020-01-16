using ChessGame.Data.PiecesClass;
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
                arrPiece[x, 1] = new Pawn(PieceSide.WHITE);
                arrPiece[x, 6] = new Pawn(PieceSide.BLACK);
            }

            arrPiece[0, 0] = new Rook(PieceSide.WHITE);
            arrPiece[7, 0] = new Rook(PieceSide.WHITE);
            arrPiece[0, 7] = new Rook(PieceSide.BLACK);
            arrPiece[7, 7] = new Rook(PieceSide.BLACK);

            arrPiece[1, 0] = new Knight(PieceSide.WHITE);
            arrPiece[6, 0] = new Knight(PieceSide.WHITE);
            arrPiece[1, 7] = new Knight(PieceSide.BLACK);
            arrPiece[6, 7] = new Knight(PieceSide.BLACK);

            arrPiece[2, 0] = new Bishop(PieceSide.WHITE);
            arrPiece[5, 0] = new Bishop(PieceSide.WHITE);
            arrPiece[2, 7] = new Bishop(PieceSide.BLACK);
            arrPiece[5, 7] = new Bishop(PieceSide.BLACK);

            arrPiece[3, 0] = new Queen(PieceSide.WHITE);
            arrPiece[3, 7] = new Queen(PieceSide.BLACK);
            arrPiece[4, 0] = new King(PieceSide.WHITE);
            arrPiece[4, 7] = new King(PieceSide.BLACK);
        }

        internal Piece[,] ArrPiece { get => arrPiece; set => arrPiece = value; }
        public Piece this[int x, int y] { get => arrPiece[x, y]; }
        public Piece this[Point p] { get => arrPiece[p.X, p.Y]; }

        public bool IsChecked(PieceSide side)
        {
            Point KingPosition = this.GetKingPosition(side);
            return false;
        }

        public bool IsCheckmated(PieceSide side)
        {
            return false;
        }

        public bool CheckMove(Point src, Point des)
        {
            //Kiểm tra nước cờ có hợp logic của quân cờ
            Piece pieceSrc = this.arrPiece[src.X, src.Y];
            if (pieceSrc == null || !pieceSrc.IsAvailableMove(des))
                return false;

            //Thử đi nước cờ và kiểm tra xem nước cờ có làm cho quân vua bị chiếu
            PieceSide side = pieceSrc.Side;
            Piece tmp = this.arrPiece[des.X, des.Y]; //Lưu quân cờ ở vị trí mới
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
            throw new NotImplementedException();
        }
    }
}
