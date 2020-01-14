using ChessGame.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.GameEngine
{
    //public class ChessBoard
    //{
    //    private static int[] pieceWeights = { 1, 3, 4, 5, 7, 20 };

    //    public piece_t[][] Grid { get; private set; }
    //    public Dictionary<TURN, Position> Kings { get; private set; }
    //    public Dictionary<TURN, List<Position>> Pieces { get; private set; }
    //    public Dictionary<TURN, Position> LastMove { get; private set; }

    //    public ChessBoard()
    //    {
    //        // init blank board grid
    //        Grid = new piece_t[8][];
    //        for (int i = 0; i < 8; i++)
    //        {
    //            Grid[i] = new piece_t[8];
    //            for (int j = 0; j < 8; j++)
    //                Grid[i][j] = new piece_t(PieceType.NONE, TURN.WHITE);
    //        }

    //        // init last moves
    //        LastMove = new Dictionary<TURN, Position>();
    //        LastMove[TURN.BLACK] = new Position();
    //        LastMove[TURN.WHITE] = new Position();

    //        // init king positions
    //        Kings = new Dictionary<TURN, Position>();

    //        // init piece position lists
    //        Pieces = new Dictionary<TURN, List<Position>>();
    //        Pieces.Add(TURN.BLACK, new List<Position>());
    //        Pieces.Add(TURN.WHITE, new List<Position>());
    //    }

    //    public ChessBoard(BoardData board)
    //    {
    //        // init blank board grid
    //        Grid = new piece_t[8][];
    //        Piece[][] temp = board.GetGridPiece();
    //        for (int i = 0; i < 8; i++)
    //        {
    //            Grid[i] = new piece_t[8];
    //            for (int j = 0; j < 8; j++)
    //            {
    //                Grid[i][j] = new piece_t(temp[i][j].type, TURN.WHITE);
    //            }
    //        }

    //        // init last moves
    //        LastMove = new Dictionary<TURN, Position>();
    //        LastMove[TURN.BLACK] = new Position();
    //        LastMove[TURN.WHITE] = new Position();

    //        // init king positions
    //        Kings = new Dictionary<TURN, Position>();

    //        // init piece position lists
    //        Pieces = new Dictionary<TURN, List<Position>>();
    //        Pieces.Add(TURN.BLACK, new List<Position>());
    //        Pieces.Add(TURN.WHITE, new List<Position>());

    //        SetInitialPlacement();
    //    }

    //    public ChessBoard(ChessBoard copy)
    //    {
    //        // init piece position lists
    //        Pieces = new Dictionary<TURN, List<Position>>();
    //        Pieces.Add(TURN.BLACK, new List<Position>());
    //        Pieces.Add(TURN.WHITE, new List<Position>());

    //        // init board grid to copy locations
    //        Grid = new piece_t[8][];
    //        for (int i = 0; i < 8; i++)
    //        {
    //            Grid[i] = new piece_t[8];
    //            for (int j = 0; j < 8; j++)
    //            {
    //                Grid[i][j] = new piece_t(copy.Grid[i][j]);

    //                // add piece location to list
    //                if (Grid[i][j].piece != PieceType.NONE)
    //                    Pieces[Grid[i][j].player].Add(new Position(j, i));
    //            }
    //        }

    //        // copy last known move
    //        LastMove = new Dictionary<TURN, Position>();
    //        LastMove[TURN.BLACK] = new Position(copy.LastMove[TURN.BLACK]);
    //        LastMove[TURN.WHITE] = new Position(copy.LastMove[TURN.WHITE]);

    //        // copy king locations
    //        Kings = new Dictionary<TURN, Position>();
    //        Kings[TURN.BLACK] = new Position(copy.Kings[TURN.BLACK]);
    //        Kings[TURN.WHITE] = new Position(copy.Kings[TURN.WHITE]);
    //    }

    //    /// <summary>
    //    /// Calculate and return the boards fitness value.
    //    /// </summary>
    //    /// <param name="max">Who's side are we viewing from.</param>
    //    /// <returns>The board fitness value, what else?</returns>
    //    public int fitness(TURN max)
    //    {
    //        int fitness = 0;
    //        int[] blackPieces = { 0, 0, 0, 0, 0, 0 };
    //        int[] whitePieces = { 0, 0, 0, 0, 0, 0 };
    //        int blackMoves = 0;
    //        int whiteMoves = 0;

    //        // sum up the number of moves and pieces
    //        foreach (Position pos in Pieces[TURN.BLACK])
    //        {
    //            blackMoves += LegalMoveSet.getLegalMove(this, pos).Count;
    //            blackPieces[(int)Grid[pos.number][pos.letter].piece]++;
    //        }

    //        // sum up the number of moves and pieces
    //        foreach (Position pos in Pieces[TURN.WHITE])
    //        {
    //            whiteMoves += LegalMoveSet.getLegalMove(this, pos).Count;
    //            whitePieces[(int)Grid[pos.number][pos.letter].piece]++;
    //        }

    //        // if viewing from black side
    //        if (max == TURN.BLACK)
    //        {
    //            // apply weighting to piece counts
    //            for (int i = 0; i < 6; i++)
    //            {
    //                fitness += pieceWeights[i] * (blackPieces[i] - whitePieces[i]);
    //            }

    //            // apply move value
    //            fitness += (int)(0.5 * (blackMoves - whiteMoves));
    //        }
    //        else
    //        {
    //            // apply weighting to piece counts
    //            for (int i = 0; i < 6; i++)
    //            {
    //                fitness += pieceWeights[i] * (whitePieces[i] - blackPieces[i]);
    //            }

    //            // apply move value
    //            fitness += (int)(0.5 * (whiteMoves - blackMoves));
    //        }

    //        return fitness;
    //    }

    //    public void SetInitialPlacement()
    //    {
    //        for (int i = 0; i < 8; i++)
    //        {
    //            SetPiece(PieceType.PAWN, TURN.WHITE, i, 1);
    //            SetPiece(PieceType.PAWN, TURN.BLACK, i, 6);
    //        }

    //        SetPiece(PieceType.ROOK, TURN.WHITE, 0, 0);
    //        SetPiece(PieceType.ROOK, TURN.WHITE, 7, 0);
    //        SetPiece(PieceType.ROOK, TURN.BLACK, 0, 7);
    //        SetPiece(PieceType.ROOK, TURN.BLACK, 7, 7);

    //        SetPiece(PieceType.KNIGHT, TURN.WHITE, 1, 0);
    //        SetPiece(PieceType.KNIGHT, TURN.WHITE, 6, 0);
    //        SetPiece(PieceType.KNIGHT, TURN.BLACK, 1, 7);
    //        SetPiece(PieceType.KNIGHT, TURN.BLACK, 6, 7);

    //        SetPiece(PieceType.BISHOP, TURN.WHITE, 2, 0);
    //        SetPiece(PieceType.BISHOP, TURN.WHITE, 5, 0);
    //        SetPiece(PieceType.BISHOP, TURN.BLACK, 2, 7);
    //        SetPiece(PieceType.BISHOP, TURN.BLACK, 5, 7);

    //        SetPiece(PieceType.KING, TURN.WHITE, 4, 0);
    //        SetPiece(PieceType.KING, TURN.BLACK, 4, 7);
    //        Kings[TURN.WHITE] = new Position(4, 0);
    //        Kings[TURN.BLACK] = new Position(4, 7);
    //        SetPiece(PieceType.QUEEN, TURN.WHITE, 3, 0);
    //        SetPiece(PieceType.QUEEN, TURN.BLACK, 3, 7);
    //    }

    //    public void SetPiece(PieceType piece, TURN player, int letter, int number)
    //    {
    //        // set grid values
    //        Grid[number][letter].piece = piece;
    //        Grid[number][letter].player = player;

    //        // add piece to list
    //        Pieces[player].Add(new Position(letter, number));

    //        // update king position
    //        if (piece == PieceType.KING)
    //        {
    //            Kings[player] = new Position(letter, number);
    //        }
    //    }
    //}
}
