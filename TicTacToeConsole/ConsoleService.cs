using System;
using System.Collections.Generic;
using TicTacToeAI.Interfaces;

namespace TicTacToeAI
{
    public class ConsoleService : IOutputInputService
    {
        private List<int> FreeSquareNmbers;
        private readonly Dictionary<GameState, string> GameResultDictionary;
        public ConsoleService(IBoard board)
        {
            ResetFreeSquareChoices();
            for (int i = 0; i < 9; i++)
            {
                board[i].SquareContentChangedEvent += SquareChangedEventHandler;
            }
            GameResultDictionary = new Dictionary<GameState, string>
            {
                {GameState.Draw,Constants.DrawResult },
                {GameState.Owin,Constants.WinOResult },
                {GameState.Xwin,Constants.WinXResult },
                {GameState.InPlay,Constants.NoResult }
            };

        }

        public void DisplayMessage(string msg)
        {
            Console.WriteLine(msg);
        }

        public bool GetIsYes(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadKey().Key == ConsoleKey.Y;
        }

        public int GetMoveFromPlayer()
        {
            bool isMoveValid = false;
            int squareIndex = 0;
            while (!isMoveValid)
            {
                Console.WriteLine();
                Console.Write(Constants.PromptInput);
                string cellChoice = Console.ReadKey().KeyChar.ToString();
                //squareNumber will be set to 0 if TryParse fails
                int.TryParse(cellChoice, out int squareNumber);
                if (FreeSquareNmbers.Contains(squareNumber))
                {
                    FreeSquareNmbers.Remove(squareNumber);
                    squareIndex = squareNumber - 1;
                    isMoveValid = true;
                }
            }
            return squareIndex;
        }

        public void OutputGameResult(Move gameResult, IBoard board)
        {
            //will throw an exception if the key 'gameResult' is not found
            string msg = GameResultDictionary[gameResult.MoveResult];
            Console.WriteLine("\r\n" + msg);
            ShowBoard(board);
        }

        public void ResetFreeSquareChoices()
        {
            FreeSquareNmbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        }

        public void ShowBoard(IBoard board)
        {
            Console.Clear();
            int ColCount = 0;
            PrintLine();
            Console.Write("\r\n| ");
            for (int i = 0; i < 9; i++)
            {
                Console.Write(board[i].Content);
                Console.Write(" | ");
                ColCount++;
                if (ColCount == 3 && i < 8)
                {
                    ColCount = 0;
                    Console.WriteLine();
                    PrintLine();
                    Console.Write("\r\n| ");
                }
            }
            Console.WriteLine();
            PrintLine();
            Console.WriteLine();
        }

        void PrintLine()
        {
            for (int c = 0; c < 3; c++)
            {
                Console.Write("+---");
            }
            Console.Write("+");
        }

        private void SquareChangedEventHandler(object sender, EventArgs e)
        {
            Square square = sender as Square;
            UpdateInputChoices(square.BoardIndex);
        }

        private void UpdateInputChoices(int boardIndex)
        {
            FreeSquareNmbers.Remove(boardIndex + 1);
        }
    }
}
