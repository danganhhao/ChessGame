using ChessGame.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.GameEngine
{
    public class AI
    {
        private static bool firstCall = true;
        public static int DEPTH = 4;
        public static bool RUNNING = false;
        public static bool STOP = false;
        private static PieceSide MAX = PieceSide.BLACK;

        public static Move DoMove(BoardData board, PieceSide turn)
        {
            BoardHelper.GetInstance().Config(firstCall);
            return MiniMaxAB(BoardHelper.GetInstance(), turn);
        }
        private static Move MiniMaxAB(BoardHelper board, PieceSide turn)
        {
            RUNNING = true; // we've started running
            STOP = false; // no interupt command sent
            MAX = turn; // who is maximizing

            // gather all possible moves
            Dictionary<Position, List<Position>> moves = LegalMoveSet.getPlayerMoves(board, turn);

            // because we're threading safely store best result from each thread
            int[] bestresults = new int[moves.Count];
            Move[] bestmoves = new Move[moves.Count];

            // thread the generation of each move
            Parallel.ForEach(moves, (movelist, state, index) =>
            {
                if (STOP) // interupt
                {
                    state.Stop();
                    return;
                }

                // initialize thread best
                bestresults[index] = int.MinValue;
                bestmoves[index] = new Move(new Position(-1, -1), new Position(-1, -1));

                // for each move for the current piece(thread)
                foreach (Position move in movelist.Value)
                {
                    if (STOP) // interupt
                    {
                        state.Stop();
                        return;
                    }

                    // make initial move and start recursion
                    BoardHelper b2 = LegalMoveSet.move(board, new Move(movelist.Key, move));
                    int result = mimaab(b2, (turn == PieceSide.WHITE) ? PieceSide.BLACK : PieceSide.WHITE, 1, Int32.MinValue, Int32.MaxValue);

                    // if result is better or best hasn't been set yet
                    if (bestresults[index] < result || (bestmoves[index].to.Equals(new Position(-1, -1)) && bestresults[index] == int.MinValue))
                    {
                        bestresults[index] = result;
                        bestmoves[index].from = movelist.Key;
                        bestmoves[index].to = move;
                    }
                }
            });

            // interupted
            if (STOP)
                return new Move(new Position(-1, -1), new Position(-1, -1));

            // find the best of the thread results
            int best = int.MinValue;
            Move m = new Move(new Position(-1, -1), new Position(-1, -1));
            for (int i = 0; i < bestmoves.Length; i++)
            {
                if (best < bestresults[i] || (m.to.Equals(new Position(-1, -1)) && !bestmoves[i].to.Equals(new Position(-1, -1))))
                {
                    best = bestresults[i];
                    m = bestmoves[i];
                }
            }
            return m;
        }
         
        private static int mimaab(BoardHelper board, PieceSide turn, int depth, int alpha, int beta)
        {
            // base case, at maximum depth return board fitness
            if (depth >= DEPTH)
                return board.fitness(MAX);
            else
            {
                List<BoardHelper> boards = new List<BoardHelper>();

                // get available moves / board states from moves for the current player
                foreach (Position pos in board.Pieces[turn])
                {
                    if (STOP) return -1; // interupts
                    List<Position> moves = LegalMoveSet.getLegalMove(board, pos);
                    foreach (Position move in moves)
                    {
                        if (STOP) return -1; // interupts
                        BoardHelper b2 = LegalMoveSet.move(board, new Move(pos, move));
                        boards.Add(b2);
                    }
                }

                int a = alpha, b = beta;
                if (turn != MAX) // minimize
                {
                    foreach (BoardHelper b2 in boards)
                    {
                        if (STOP) return -1; // interupt
                        b = Math.Min(b, mimaab(b2, (turn == PieceSide.WHITE) ? PieceSide.BLACK : PieceSide.WHITE, depth + 1, a, b));
                        if (a >= b)
                            return a;
                    }
                    return b;
                }
                else // maximize
                {
                    foreach (BoardHelper b2 in boards)
                    {
                        if (STOP) return -1; // interupt
                        a = Math.Max(a, mimaab(b2, (turn == PieceSide.WHITE) ? PieceSide.BLACK : PieceSide.WHITE, depth + 1, a, b));
                        if (a >= b)
                            return b;
                    }
                    return a;
                }
            }
        }
        public static void UpdateFirstCall(bool value)
        {
            firstCall = value;
        }
    }
}
