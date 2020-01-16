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
        PieceSide mySide = PieceSide.White;
        int time = 60 * 30;
        Timer timer;
        BoardData boardData = BoardData.GetInstance();
        Form1 ui;
        GameModeStrategy gameModeStrategy;

        private Dictionary<PieceSide, int> timePerPlayer;
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
            this.InitFieldValue();
            this.InitTimer();
        }

        private void InitFieldValue()
        {
            timePerPlayer = new Dictionary<PieceSide, int>();
            timePerPlayer.Add(PieceSide.Black, this.time);
            timePerPlayer.Add(PieceSide.White, this.time);
        }

        private void InitTimer()
        {
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(this.CountDown);
            timer.Start();
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

        private void CountDown(object sender, EventArgs e)
        {
            this.timePerPlayer[turn] -= 1;
            this.ui.SetLabelClock(turn, this.timePerPlayer[turn]);
            if (this.timePerPlayer[turn] <= 0)
            {
                timer.Stop();
                this.ui.SetBlockBoard(true);
            }
        }
    }
}
