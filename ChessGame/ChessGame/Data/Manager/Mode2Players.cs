using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Data
{
    class Mode2Players : GameModeStrategy
    {
        public Mode2Players(GameManager gameManager) : base(gameManager){}

        internal override void ProcessMoveRequest(Point src, Point des)
        {
            BoardData board = this.gameManager.GetBoardData();
            if (board.IsLegalMove(src, des))
                gameManager.DoMove(src, des);
        }

        internal override void SetTurn(PieceSide turn)
        {
            this.gameManager.SetBlockBoard(false);
        }
    }
}
