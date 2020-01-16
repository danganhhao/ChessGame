using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Data
{
    abstract class GameModeStrategy
    {
        protected GameManager gameManager;

        public GameModeStrategy(GameManager gameManager)
        {
            this.gameManager = gameManager;
        }

        internal abstract void ProcessMoveRequest(Point src, Point des);

        internal abstract void SetTurn(PieceSide turn);
    }
}
