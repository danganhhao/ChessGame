﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public enum PieceColor
    {
        WHITE,
        BLACK
    }

    public enum PieceType
    {
        NONE = -1,
        KING,
        QUEEN,
        ROOK,
        BISHOP,
        KNIGHT,
        PAWN
    }

    public enum Direction
    {
        UP,
        DOWN
    }

    public enum TURN
    {
        BLACK,
        WHITE
    }

    public struct Position
    {
        public int letter;
        public int number;

        public Position(int letter, int number)
        {
            this.letter = letter;
            this.number = number;
        }
        public Position(Position copy)
        {
            this.letter = copy.letter;
            this.number = copy.number;
        }

        public override bool Equals(object obj)
        {
            return letter == ((Position)obj).letter && number == ((Position)obj).number;
        }
    }

    public struct piece_t
    {
        public PieceType piece;
        public TURN player;
        public Position lastPosition;

        public piece_t(PieceType piece, TURN player)
        {
            this.piece = piece;
            this.player = player;
            this.lastPosition = new Position(-1, -1);
        }

        public piece_t(piece_t copy)
        {
            this.piece = copy.piece;
            this.player = copy.player;
            this.lastPosition = copy.lastPosition;
        }
    }

    public struct Move
    {
        public Position from;
        public Position to;

        public Move(Position from, Position to)
        {
            this.from = from;
            this.to = to;
        }
    }
}
