using ChessGame.GameEngine;
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
            {
                this.gameManager.SetBlockBoard(true);
                Move move = GetAIMove();
                this.gameManager.ProcessMoveRequest(new Point(move.from.letter, move.from.number), 
                    new Point(move.to.letter, move.to.number));
            }
            else this.gameManager.SetBlockBoard(false);
        }

        private Move GetAIMove()
        {
            GameManager gameManager = GameManager.GetInstance();
            return AI.GetInstance().DoMove(gameManager.GetBoardData(), gameManager.Turn);
        }
    }
}
