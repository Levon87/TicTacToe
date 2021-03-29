//using System;

//namespace TicTacToe.Logic
//{
//	public sealed class Logic
//    {
//        private const byte Player = 1;
//        private const byte Opponent = 0;

//        private static bool IsMovesLeft(byte?[,] board)
//        {
//            for (var i = 0; i < 3; i++)
//            for (var j = 0; j < 3; j++)
//                if (board[i, j] == null)
//                    return true;
//            return false;
//        }

//        private static int Evaluate(byte?[,] board)
//        {
//            // Checking for Rows for X or O victory.
//            for (var row = 0; row < 3; row++)
//            {
//                if (board[row, 0] != board[row, 1] && board[row, 1] != board[row, 2])
//                    continue;

//                if (board[row, 0] == Player)
//                    return +10;
//                if (board[row, 0] == Opponent)
//                    return -10;
//            }

//            // Checking for Columns for X or O victory.
//            for (var col = 0; col < 3; col++)
//                if (board[0, col] == board[1, col] &&
//                    board[1, col] == board[2, col])
//                {
//                    if (board[0, col] == Player)
//                        return +10;

//                    if (board[0, col] == Opponent)
//                        return -10;
//                }

//            // Checking for Diagonals for X or O victory.
//            if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
//            {
//                if (board[0, 0] == Player)
//                    return +10;
//                if (board[0, 0] == Opponent)
//                    return -10;
//            }

//            if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
//            {
//                if (board[0, 2] == Player)
//                    return +10;
//                if (board[0, 2] == Opponent)
//                    return -10;
//            }

//            // Else if none of them have won then return 0
//            return 0;
//        }

//        private static int MiniMax(byte?[,] board, int depth, bool isMax)
//        {
//            var score = Evaluate(board);

//            switch (score)
//            {
//                // If Maximizer has won the game
//                // return his/her evaluated score
//                case 10:
//                    return score;
//                // If Minimizer has won the game
//                // return his/her evaluated score
//                case -10:
//                    return score;
//            }

//            // If there are no more moves and
//            // no winner then it is a tie
//            if (IsMovesLeft(board) == false)
//                return 0;

//            // If this maximizer's move
//            if (isMax)
//            {
//                var best = -1000;

//                // Traverse all cells
//                for (var i = 0; i < 3; i++)
//                for (var j = 0; j < 3; j++)
//                    // Check if cell is empty
//                    if (board[i, j] == null)
//                    {
//                        // Make the move
//                        board[i, j] = Player;

//                        // Call minimax recursively and choose
//                        // the maximum value
//                        best = Math.Max(best, MiniMax(board, depth + 1, !isMax));

//                        // Undo the move
//                        board[i, j] = null;
//                    }

//                return best;
//            }

//            // If this minimizer's move
//            else
//            {
//                var best = 1000;

//                // Traverse all cells
//                for (var i = 0; i < 3; i++)
//                for (var j = 0; j < 3; j++)
//                {
//                    // Check if cell is empty
//                    if (board[i, j] != null)
//                        continue;
//                    // Make the move
//                    board[i, j] = Opponent;

//                    // Call minimax recursively and choose
//                    // the minimum value
//                    best = Math.Min(best, MiniMax(board,
//                        depth + 1, !isMax));

//                    // Undo the move
//                    board[i, j] = null;
//                }

//                return best;
//            }
//        }

//        public static (int row, int col) FindBestMove(byte?[,] board)
//        {
//            var bestVal = -1000;
//            var bestMove = (row: -1, col: -1);

//            // Traverse all cells, evaluate minimax function
//            // for all empty cells. And return the cell
//            // with optimal value.
//            for (var i = 0; i < 3; i++)
//            for (var j = 0; j < 3; j++)
//            {
//                // Check if cell is empty
//                if (board[i, j] != null)
//                    continue;

//                // Make the move
//                board[i, j] = Player;

//                // compute evaluation function for this
//                // move.
//                var moveVal = MiniMax(board, 0, false);

//                // Undo the move
//                board[i, j] = null;

//                // If the value of the current move is
//                // more than the best value, then update
//                // best/
//                if (moveVal <= bestVal)
//                    continue;

//                bestMove.row = i;
//                bestMove.col = j;
//                bestVal = moveVal;
//            }

//            var isWin = Evaluate(board);

//            return bestMove;
//        }
//    }
//}