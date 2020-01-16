using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessGame.Data
{
    class GameManager
    {
        GameMode mode = GameMode.TwoPlayers;
        PieceSide turn = PieceSide.White;
        PieceSide mySide = PieceSide.Black;
        BoardData boardData = BoardData.GetInstance();
        Form1 ui;
        GameModeStrategy gameModeStrategy;

        private Dictionary<PieceSide, int> timePerPlayer = new Dictionary<PieceSide, int>();
        public PieceSide Turn { get => turn; set => turn = value; }
        public PieceSide MySide { get => mySide; set => mySide = value; }
        public GameMode Mode { get => mode; set => SetMode(value); }

        private static GameManager instance = null;
        public static GameManager GetInstance()
        {
            if (instance == null)
                instance = new GameManager();
            return instance;
        }

        private GameManager()
        {
            this.SetMode(GameMode.TwoPlayers);
        }

        private void SetMode(GameMode value)
        {
            gameModeStrategy = new Mode2Players(this);
        }

        internal BoardData GetBoardData()
        {
            return this.boardData;
        }

        internal Piece[,] GetArrayPiece()
        {
            return boardData.ArrPiece;
        }

        public void SwitchTurn()
        {
            if (turn == PieceSide.Black)
                turn = PieceSide.White;
            else turn = PieceSide.Black;
            gameModeStrategy.SetTurn(turn);
            ui.SetTurn(turn);
        }

        public void SetBlockBoard(bool block)
        {
            ui.SetBlockBoard(block);
        }

        public void SetForm(Form1 form)
        {
            ui = form;
        }


        internal void ProcessMoveRequest(Point src, Point des)
        {
            gameModeStrategy.ProcessMoveRequest(src, des);
        }

        internal void DoMove(Point src, Point des)
        {
            boardData.MovePiece(src, des);
            ui.DoMove(src, des);
        }
    }
}
