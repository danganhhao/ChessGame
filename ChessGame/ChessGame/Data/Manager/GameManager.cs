using ChessGame.GameEngine;
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
        bool isEndGame = false;

        private Dictionary<PieceSide, int> timePerPlayer;
        public PieceSide Turn { get => turn; set => turn = value; }
        public PieceSide MySide { get => mySide; set => mySide = value; }
        public GameMode Mode { get => mode; set => SetMode(value); }
        public int Time { get => time; set => time = value; }

        private static GameManager instance = null;
        public static GameManager GetInstance()
        {
            if (instance == null)
                instance = new GameManager();
            return instance;
        }

        internal void OnLoadUiDone()
        {
            this.InitValue();
            this.InitTimer();
            this.ui.SetLabelClock(PieceSide.Black, timePerPlayer[PieceSide.Black]);
            this.ui.SetLabelClock(PieceSide.White, timePerPlayer[PieceSide.White]);
            gameModeStrategy.SetTurn(turn);
            this.ui.SetTurn(turn);
        }

        private GameManager()
        {
            this.SetMode(GameMode.WithComputer);
        }

        private void InitValue()
        {
            timePerPlayer = new Dictionary<PieceSide, int>();
            timePerPlayer.Add(PieceSide.Black, this.time);
            timePerPlayer.Add(PieceSide.White, this.time);
        }

        public void InitTimer()
        {
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(this.CountDown);
            timer.Start();
        }

        private void SetMode(GameMode value)
        {
            if (value == GameMode.WithComputer)
                gameModeStrategy = new ModeWithComp(this);
            else gameModeStrategy = new Mode2Players(this);
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
            AI.GetInstance().UpdateBoard(src, des);
            ui.DoMove(src, des);
            if (boardData.IsCheckmated(1 - turn))
                EndGame(1 - turn);
            else this.SwitchTurn();
        }

        private void EndGame(PieceSide loseTurn)
        {
            this.ui.EndGame(loseTurn);
            isEndGame = true;
        }

        private void CountDown(object sender, EventArgs e)
        {
            this.timePerPlayer[turn] -= 1;
            this.ui.SetLabelClock(turn, this.timePerPlayer[turn]);
            if (this.timePerPlayer[turn] <= 0 || isEndGame)
            {
                timer.Stop();
                this.EndGame(turn);
            }
        }

        public void SendMoveRequest(Point src, Point des)
        {
            //Gửi gói tin chứa nước đi của mình
        }

        public void ReceiveMoveResponse(Point src, Point des)
        {
            //Nếu các client đều đồng thuận với nước đi này
            //if (true)
            //{
            //    this.DoMove(src, des);
            //}
        }

        public void ReceiveMoveRequest(Point src, Point des)
        {
            if (boardData.IsLegalMove(src, des))
                this.SendMoveResponse(src, des, true);
            else this.SendMoveResponse(src, des, false);
        }

        public void SendMoveResponse(Point src, Point des, bool result)
        {
            //Send response
        }
    }
}
