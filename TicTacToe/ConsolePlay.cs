using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class ConsolePlay
    {
        public TicTacToe player;
        public ConsolePlay(int player, string playerName)
        {
            this.player = new TicTacToe(player, playerName);
        }

        public void displayBoard(int[,] board)
        {
            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < 3; c++)
                {
                    Console.Write(board[r, c] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public bool PlayGame()
        {
            int r = 0;
            int c = 0;

            if (player.PlayerName != "computer") // playing against a human player
            {
                Console.WriteLine("Please enter where to place your symbol");
                int.TryParse(Console.ReadLine().Trim(), out r);
                int.TryParse(Console.ReadLine().Trim(), out c);
            }
            else // Playing against the computer
            {
                Random rand = new Random();
                r = rand.Next(1, 4);
                c = rand.Next(1, 4);
            }

            while (!player.checkBoard(r, c))
            {
                if (player.PlayerName != "computer")
                {
                    Console.WriteLine("You entered incorrect coordinates. Try again!");
                    int.TryParse(Console.ReadLine().Trim(), out r);
                    int.TryParse(Console.ReadLine().Trim(), out c);
                }
                else
                {
                    Random rand = new Random();
                    r = rand.Next(1, 4);
                    c = rand.Next(1, 4);
                }
            }

            player.updateBoard(r, c, player.Player);
            displayBoard(player.getBoard()); // display updated board

            if (player.win())
            {
                if (player.PlayerName.Equals("computer"))
                    Console.WriteLine("Computer Wins!!");
                else
                    Console.WriteLine("Congratulations " + player.PlayerName + ". You WIN!");

                return true;
            }
            else if (player.draw())
            {
                Console.WriteLine("It's a DRAW!");
                return true;
            }

            return false;
        }
    }
}
