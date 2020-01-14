using ChessGame.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChessGame.GameEngine
{
    //class Chess
    //{
    //    public BoardData Board { get; private set; }
    //    public TURN Turn { get; private set; }
    //    public Position Selection { get; private set; }

    //    //private UIBoard m_UI;
    //    private int m_nPlayers;

    //    public Chess(UIBoard ui, int nPlayers = 1, bool setupBoard = true)
    //    {
    //        // callback setup
    //        //this.m_UI = ui;
    //        //this.m_UI.SetStatus(true, "Generating...");


    //        // number of players = {0, 1, 2}
    //        this.m_nPlayers = nPlayers;
    //        // white always starts
    //        this.Turn = TURN.WHITE;

    //        // create a new blank board unless setup is true
    //        this.Board = new BoardData();
    //        if (setupBoard)
    //        {
    //            this.Board.SetInitialPlacement();
    //        }

    //        // update ui
    //        //this.m_UI.SetBoard(Board);
    //        //this.m_UI.SetStatus(false, "White's turn.");
    //    }

    //    public void AISelect()
    //    {
    //        // wait for previous ai thread to stop
    //        while (AI.RUNNING)
    //        {
    //            Thread.Sleep(100);
    //        }

    //        // ai is dump
    //        //this.m_UI.SetStatus(true, "Thinking...");

    //        // calculate move
    //        Move move = AI.MiniMaxAB(this.Board, this.Turn);

    //        // if valid move, make the move
    //        if (move.to.letter >= 0 && move.to.number >= 0)
    //        {
    //            MakeMove(move);
    //        }
    //        else // if invalid move 
    //        {
    //            if (!AI.STOP) // and not caused by AI interupt
    //            {
    //                // fuuuuuu
    //                //this.m_UI.LogMove("Null Move\n");
    //            }
    //        }

    //        bool checkmate = false;

    //        // if the AI wasn't interupted finish our turn
    //        if (!AI.STOP)
    //        {
    //            switchPlayer();
    //            checkmate = detectCheckmate();
    //        }

    //        // we're done now
    //        AI.RUNNING = false;

    //        // if the AI wan't interupted 
    //        // and we're in AI vs AI mode
    //        // and not in checkmate/stalemate
    //        // start the next AI's turn
    //        if (!AI.STOP && this.m_nPlayers == 0 && !checkmate)
    //        {
    //            new Thread(AISelect).Start();
    //        }
    //    }

    //    public List<Position> Select(Position pos)
    //    {
    //        // has previously selected something
    //        if (this.Board.Grid[this.Selection.number][this.Selection.letter].piece != PieceType.NONE
    //            && this.Turn == this.Board.Grid[this.Selection.number][this.Selection.letter].player
    //            && (this.m_nPlayers == 2
    //            || this.Turn == TURN.WHITE))
    //        {
    //            // get previous selections moves and determine if we chose a legal one by clicking
    //            List<Position> moves = LegalMoveSet.getLegalMove(this.Board, this.Selection);
    //            foreach (Position move in moves)
    //            {
    //                if (move.Equals(pos))
    //                {
    //                    // we selected a legal move so update the board
    //                    MakeMove(new Move(this.Selection, pos));

    //                    // If piece that was just moved is a king and it moved anyhthing other than 1 square, it was 
    //                    // a castling move, so we need to move the rook
    //                    if (this.Board.Grid[pos.number][pos.letter].piece == PieceType.KING && Math.Abs(pos.letter - this.Selection.letter) == 2)
    //                    {
    //                        int row = (this.Turn == TURN.WHITE) ? 0 : 7;

    //                        // Left rook
    //                        if (pos.letter < 4)
    //                        {
    //                            LegalMoveSet.move(this.Board, new Move(new Position(0, row), new Position(3, row)));
    //                        }
    //                        // right rook
    //                        else
    //                        {
    //                            LegalMoveSet.move(this.Board, new Move(new Position(7, row), new Position(5, row)));
    //                        }
    //                    }

    //                    // finish move
    //                    switchPlayer();
    //                    if (detectCheckmate()) return new List<Position>();

    //                    if (this.m_nPlayers == 1) // start ai
    //                    {
    //                        new Thread(AISelect).Start(); // thread turn
    //                    }
    //                    return new List<Position>();
    //                }
    //            }
    //        }

    //        // first click, let's show possible moves
    //        if (this.Board.Grid[pos.number][pos.letter].player == this.Turn && (this.m_nPlayers == 2 || this.Turn == TURN.WHITE))
    //        {
    //            List<Position> moves = LegalMoveSet.getLegalMove(this.Board, pos);
    //            this.Selection = pos;
    //            return moves;
    //        }

    //        // reset
    //        this.Selection = new Position();
    //        return new List<Position>();
    //    }

    //    private void MakeMove(Move m)
    //    {
    //        // start move log output
    //        string move = (this.Turn == TURN.WHITE) ? "W" : "B";

    //        move += ":\t";

    //        // piece
    //        switch (this.Board.Grid[m.from.number][m.from.letter].piece)
    //        {
    //            case PieceType.PAWN:
    //                move += "P";
    //                break;
    //            case PieceType.ROOK:
    //                move += "R";
    //                break;
    //            case PieceType.KNIGHT:
    //                move += "k";
    //                break;
    //            case PieceType.BISHOP:
    //                move += "B";
    //                break;
    //            case PieceType.QUEEN:
    //                move += "Q";
    //                break;
    //            case PieceType.KING:
    //                move += "K";
    //                break;
    //        }

    //        // kill
    //        if (this.Board.Grid[m.to.number][m.to.letter].piece != PieceType.NONE || LegalMoveSet.isEnPassant(this.Board, m))
    //        {
    //            move += "x";
    //        }

    //        // letter
    //        switch (m.to.letter)
    //        {
    //            case 0: move += "a"; break;
    //            case 1: move += "b"; break;
    //            case 2: move += "c"; break;
    //            case 3: move += "d"; break;
    //            case 4: move += "e"; break;
    //            case 5: move += "f"; break;
    //            case 6: move += "g"; break;
    //            case 7: move += "h"; break;
    //        }

    //        // number
    //        move += (m.to.number + 1).ToString();

    //        // update board / make actual move
    //        this.Board = LegalMoveSet.move(this.Board, m);

    //        // if that move put someone in check
    //        if (LegalMoveSet.isCheck(this.Board, (Turn == TURN.WHITE) ? TURN.BLACK : TURN.WHITE))
    //        {
    //            move += "+";
    //        }

    //        // show log
    //        //this.m_UI.LogMove(move + "\n");
    //    }

    //    /// <summary>
    //    /// Toggle who's turn it is
    //    /// </summary>
    //    private void switchPlayer()
    //    {
    //        this.Turn = (this.Turn == TURN.WHITE) ? TURN.BLACK : TURN.WHITE;
    //        //this.m_UI.SetTurn(this.Turn);
    //        //this.m_UI.SetStatus(false, ((this.Turn == TURN.WHITE) ? "White" : "Black") + "'s Turn.");
    //        //this.m_UI.SetBoard(this.Board);
    //    }

    //    /// <summary>
    //    /// Detects Checkmate, Stalemate or Draw conditions.
    //    /// </summary>
    //    /// <returns>True if no legal moves, or only kings left.</returns>
    //    public bool detectCheckmate()
    //    {
    //        bool wkingonly = this.Board.Pieces[TURN.WHITE].Count == 1 && this.Board.Grid[this.Board.Pieces[TURN.WHITE][0].number][this.Board.Pieces[TURN.WHITE][0].letter].piece == PieceType.KING;
    //        bool bkingonly = this.Board.Pieces[TURN.BLACK].Count == 1 && this.Board.Grid[this.Board.Pieces[TURN.BLACK][0].number][this.Board.Pieces[TURN.BLACK][0].letter].piece == PieceType.KING;

    //        if (!LegalMoveSet.hasMoves(this.Board, this.Turn))
    //        {
    //            if (LegalMoveSet.isCheck(this.Board, this.Turn))
    //            {
    //                //this.m_UI.LogMove("Checkmate!\n");
    //                //this.m_UI.SetStatus(false, ((this.Turn == TURN.WHITE) ? "Black" : "White") + " wins!");
    //            }
    //            else
    //            {
    //                //this.m_UI.LogMove("Stalemate!\n");
    //            }
    //            return true;
    //        }
    //        else if (wkingonly && bkingonly)
    //        {
    //            //this.m_UI.LogMove("Draw.\n");
    //            return true;
    //        }
    //        return false;
    //    }
    //}
}
