using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Data
{
    class ModeOnLan : GameModeStrategy
    {
        public ModeOnLan(GameManager gameManager) : base(gameManager)
        {
        }

        internal override void ProcessMoveRequest(Point src, Point des)
        {
            //Send moveRequestTo all client
        }

        internal override void SetTurn(PieceSide turn)
        {
            if (turn != this.gameManager.MySide)
                this.gameManager.SetBlockBoard(true);
            else this.gameManager.SetBlockBoard(false);
        }
    }
}
