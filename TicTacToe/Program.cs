using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            string playerName = "";
            bool gameOver = false;

            //Create players
            Console.WriteLine("Enter player 1 name: ");
            playerName = Console.ReadLine();
            TicTacToe player1 = new TicTacToe(1, playerName);

            Console.WriteLine("Enter player 2 name: (Type 'computer' if you want to play against computer)");
            playerName = Console.ReadLine();
            TicTacToe player2 = new TicTacToe(2, playerName);

            while (!gameOver)
            {
                TicTacToe.intBoard();

                while (!player1.PlayGame() && !player2.PlayGame())
                    gameOver = true;

                if (gameOver)
                {
                    Console.WriteLine("Do you want to play again? Press ESC to quit");
                    if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                        Console.WriteLine("Good Bye!");
                    else
                        gameOver = false;
                }
            }

            Console.ReadLine();
        }
    }
}
