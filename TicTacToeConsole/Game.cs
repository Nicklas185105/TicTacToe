using System.Linq;
using TicTacToeAI.Interfaces;

namespace TicTacToeAI
{
    public class Game : IGame
    {
        private IBoard board;
        private IOutputInputService inputOutputService;
        private IMoveHandler moveHandler;
        public Game(IBoard board, IOutputInputService inputOutputSerice, IMoveHandler moveHandler)
        {
            this.board = board;
            this.inputOutputService = inputOutputSerice;
            this.moveHandler = moveHandler;
        }

        public Move MoveO()
        {
            int squareIndex = inputOutputService.GetMoveFromPlayer();
            Move move;
            move.Index = squareIndex;
            if (board.Lines.Any((l) => l.OScore == 4))
            {
                move.MoveResult = GameState.Owin;
                return move;
            }
            move.MoveResult = GameState.InPlay;
            return move;
        }

        public Move MoveX(IBoard board)
        {
            this.board = board;
            moveHandler.Reset(board);
            Move result = moveHandler.
                HandeXWin().
                HandeOWinOnNext().
                HandlePossibleFork().
                HandleStrategicMove().Result;
            return result;
        }

        public void StartGame()
        {
            bool isPlayAgain = true;
            while (isPlayAgain)
            {
                Play();
                isPlayAgain = inputOutputService.GetIsYes(Constants.PromptPlayAgain);
                if (isPlayAgain)
                {
                    board.Reset();
                    inputOutputService.ResetFreeSquareChoices();
                }
            }
        }

        private Move Play()
        {
            inputOutputService.ShowBoard(board);
            char firstPlayer = inputOutputService.GetIsYes(Constants.PromptGoFirst) ? 'O' : 'X';
            char[] Players = firstPlayer == 'O' ? new char[] { 'O', 'X' } : new char[] { 'X', 'O' };
            int moveNumber = 0;
            Move move;
            move.MoveResult = GameState.InPlay;
            move.Index = -1;
            while (move.MoveResult == GameState.InPlay)
            {
                char player = Players[moveNumber % 2];
                move = player == 'X' ? MoveX(board) : MoveO();

                board[move.Index].Content = player;
                moveNumber++;
                if (player == 'X')
                {
                    inputOutputService.ShowBoard(board);
                }
                if (move.MoveResult == GameState.InPlay && moveHandler.IsGameADraw())
                {
                    move.MoveResult = GameState.Draw;
                }
            }
            inputOutputService.OutputGameResult(move, board);
            return move;
        }
    }
}
