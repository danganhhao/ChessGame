using ChessGame.Data.PiecesClass;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Data
{
    class BoardData
    {
        Piece[,] arrPiece = new Piece[Const.RowCount + 1, Const.ColCount + 1];
        private static BoardData instance = null;

        public static BoardData GetInstance()
        {
            if (instance == null)
                instance = new BoardData();
            return instance;
        }

        private BoardData()
        {}

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
