﻿using ChessGame.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.GameEngine
{
    public class BoardHelper
    {

        private static int[] pieceWeights = { 1, 3, 4, 5, 7, 20 };

        public piece_t[][] Grid { get; private set; }
        public Dictionary<PieceSide, Position> Kings { get; private set; }
        public Dictionary<PieceSide, List<Position>> Pieces { get; private set; }
        public Dictionary<PieceSide, Position> LastMove { get; private set; }

        private BoardHelper() { }
        private static BoardHelper instance = null;

        public static BoardHelper GetInstance()
        {
            if (instance == null)
                instance = new BoardHelper();
            return instance;
        }

        public void Config(bool firstCall, BoardData board, PieceSide turn)
        {
            if (firstCall)
            {
                AI.GetInstance().UpdateFirstCall(false);
                Grid = new piece_t[Const.RowCount][];
                for (int i = 0; i < Const.RowCount; i++)
                {
                    Grid[i] = new piece_t[Const.ColCount];
                    for (int j = 0; j < Const.ColCount; j++)
                        if (board.ArrPiece[j, i] != null)
                            Grid[i][j] = new piece_t(board.ArrPiece[j, i].Type, board.ArrPiece[j, i].Side);
                        else
                            Grid[i][j] = new piece_t(PieceType.None, PieceSide.White);
                }

                LastMove = new Dictionary<PieceSide, Position>();
                LastMove[PieceSide.Black] = new Position();
                LastMove[PieceSide.White] = new Position();
                Kings = new Dictionary<PieceSide, Position>();
                Pieces = new Dictionary<PieceSide, List<Position>>();
                List<Position> blackPos = new List<Position>();
                List<Position> whitePos = new List<Position>();

                for (int i = 0; i < Const.RowCount; i++)
                {
                    for (int j = 0; j < Const.ColCount; j++)
                    {
                        Piece temp = BoardData.GetInstance().ArrPiece[j, i];
                        if (temp != null)
                        {
                            if (temp.Side == PieceSide.Black)
                            {
                                if (temp.Type == PieceType.King)
                                {
                                    Kings[PieceSide.Black] = new Position(temp.Position.X, temp.Position.Y);
                                }
                                blackPos.Add(new Position(temp.Position.X, temp.Position.Y));
                            }
                            else
                            {
                                if (temp.Type == PieceType.King)
                                {
                                    Kings[PieceSide.White] = new Position(temp.Position.X, temp.Position.Y);
                                }
                                whitePos.Add(new Position(temp.Position.X, temp.Position.Y));
                            }
                        }
                    }
                }
                Pieces.Add(PieceSide.Black, blackPos);
                Pieces.Add(PieceSide.White, whitePos);
            }
        }

        public BoardHelper(BoardHelper copy)
        {
            // init piece position lists
            Pieces = new Dictionary<PieceSide, List<Position>>();
            Pieces.Add(PieceSide.Black, new List<Position>());
            Pieces.Add(PieceSide.White, new List<Position>());

            // init board grid to copy locations
            Grid = new piece_t[8][];
            for (int i = 0; i < 8; i++)
            {
                Grid[i] = new piece_t[8];
                for (int j = 0; j < 8; j++)
                {
                    Grid[i][j] = new piece_t(copy.Grid[i][j]);

                    // add piece location to list
                    if (Grid[i][j].piece != PieceType.None)
                        Pieces[Grid[i][j].player].Add(new Position(j, i));
                }
            }

            // copy last known move
            LastMove = new Dictionary<PieceSide, Position>();
            LastMove[PieceSide.Black] = new Position(copy.LastMove[PieceSide.Black]);
            LastMove[PieceSide.White] = new Position(copy.LastMove[PieceSide.White]);

            // copy king locations
            Kings = new Dictionary<PieceSide, Position>();
            Kings[PieceSide.Black] = new Position(copy.Kings[PieceSide.Black]);
            Kings[PieceSide.White] = new Position(copy.Kings[PieceSide.White]);
        }

        public int fitness(PieceSide max)
        {
            int fitness = 0;
            int[] blackPieces = { 0, 0, 0, 0, 0, 0 };
            int[] whitePieces = { 0, 0, 0, 0, 0, 0 };
            int blackMoves = 0;
            int whiteMoves = 0;

            // sum up the number of moves and pieces
            foreach (Position pos in Pieces[PieceSide.Black])
            {
                blackMoves += LegalMoveSet.getLegalMove(this, pos).Count;
                blackPieces[(int)Grid[pos.number][pos.letter].piece]++;
            }

            // sum up the number of moves and pieces
            foreach (Position pos in Pieces[PieceSide.White])
            {
                whiteMoves += LegalMoveSet.getLegalMove(this, pos).Count;
                whitePieces[(int)Grid[pos.number][pos.letter].piece]++;
            }

            // if viewing from black side
            if (max == PieceSide.Black)
            {
                // apply weighting to piece counts
                for (int i = 0; i < 6; i++)
                {
                    fitness += pieceWeights[i] * (blackPieces[i] - whitePieces[i]);
                }

                // apply move value
                fitness += (int)(0.5 * (blackMoves - whiteMoves));
            }
            else
            {
                // apply weighting to piece counts
                for (int i = 0; i < 6; i++)
                {
                    fitness += pieceWeights[i] * (whitePieces[i] - blackPieces[i]);
                }

                // apply move value
                fitness += (int)(0.5 * (whiteMoves - blackMoves));
            }

            return fitness;
        }


        public void Update(Point src, Point des)
        {
            PieceSide turn = Grid[src.Y][src.X].player;

            // Update King
            if (Grid[src.Y][src.X].piece == PieceType.King) {
                Kings[turn] = new Position(des.X, des.Y);
            }

            // Update LastMove
            LastMove[turn] = new Position(des.X, des.Y);

            // Update Grid
            Grid[des.Y][des.X].lastPosition = new Position(src.Y, src.X);
            Grid[des.Y][des.X].piece = Grid[src.Y][src.X].piece;
            Grid[des.Y][des.X].player = Grid[src.Y][src.X].player;
            Grid[src.Y][src.X].piece = PieceType.None;

            // Update piece list
            for (int i =0; i< Pieces[turn].Count; i++)
            {
                if (Pieces[turn][i].letter == src.X && Pieces[turn][i].number == src.Y)
                {
                    Pieces[turn][i] = new Position(des.X, des.Y);
                    break;
                }
            } 
        }
    }
}
