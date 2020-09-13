using System;

namespace TicTacToeHardCodedLogic
{
    class ConsoleUI
    {
        int width;
        int heigth;

        public ConsoleUI(int width, int height)
        {
            this.width = width;
            this.heigth = height;
        }

        public void DisplayBoard(int[,] board)
        {
            //"   1   2   3  "
            //" +---+---+---+"
            //"1| X | O | X |"
            //" +---+---+---+"
            //"2| O | X | O |"
            //" +---+---+---+"
            //"3| X | O | X |"
            //" +---+---+---+"

            for (int c = 0; c < width; c++)
            {
                Console.Write("   " + (c + 1).ToString());
            }

            Console.WriteLine();
            PrintLine();

            for (int r = 0; r < heigth; r++)
            {
                Console.WriteLine();
                Console.Write((r + 1).ToString());
                for (int c = 0; c < width; c++)
                {
                    Console.Write("| " + (board[r,c] == 0 ? " " : board[r,c].ToString()) + " ");
                }
                Console.Write("|");
                Console.WriteLine();
                PrintLine();
            }
        }

        void PrintLine()
        {
            Console.Write(" ");
            for (int c = 0; c < width; c++)
            {
                Console.Write("+---");
            }
            Console.Write("+");
        }

        public void ClearConsole()
        {
            Console.Clear();
        }
    }
}
