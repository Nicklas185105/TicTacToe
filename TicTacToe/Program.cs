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
            ConsolePlay player1 = new ConsolePlay(1, playerName);

            Console.WriteLine("Enter player 2 name: (Type 'computer' if you want to play against computer)");
            playerName = Console.ReadLine();
            ConsolePlay player2 = new ConsolePlay(2, playerName);

            while (!gameOver)
            {
                TicTacToe.initializeBoard();
                player1.displayBoard(player1.player.getBoard());

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
