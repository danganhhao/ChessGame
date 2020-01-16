using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Data
{
    class ModeWithComp : GameModeStrategy
    {
        public ModeWithComp(GameManager gameManager) : base(gameManager)
        {

        }

        internal override void ProcessMoveRequest(Point src, Point des)
        {
            BoardData board = this.gameManager.GetBoardData();
            if (board.IsLegalMove(src, des))
                gameManager.DoMove(src, des);
        }

        internal override void SetTurn(PieceSide turn)
        {
            if (turn != this.gameManager.MySide)
                this.gameManager.SetBlockBoard(true);
            else this.gameManager.SetBlockBoard(false);
        }
    }
}
