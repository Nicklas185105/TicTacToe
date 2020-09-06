using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class TicTacToe
    {
        static int[,] _board;
        string _playerName;

        public TicTacToe(int player, string playerName)
        {
            PlayerName = playerName;
            Player = player;
            _board = new int[3, 3];
        }

        public int Player { get; set; }
        public string PlayerName
        {
            get { return _playerName; }
            set
            {
                if (value.Length > 0)
                    _playerName = value;
                else
                {
                    while(value.Length < 1) //name cannot be an empty string
                    {
                        Console.WriteLine("Invalid entry. Please re-enter player's name: ");
                        value = Console.ReadLine();
                    }
                }
            }
        }

        public bool PlayGame()
        {
            int r = 0;
            int c = 0;

            if (PlayerName != "computer") // playing against a human player
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

            while (!checkBoard(r, c))
            {
                if (PlayerName != "computer")
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

            _board[r - 1, c - 1] = Player;
            displayBoard(); // display updated board

            if (win())
            {
                if (PlayerName.Equals("computer"))
                    Console.WriteLine("Computer Wins!!");
                else
                    Console.WriteLine("Congratulations " + PlayerName + ". You WIN!");

                return true;
            }
            else if (draw())
            {
                Console.WriteLine("It's a DRAW!");
                return true;
            }

            return false;
        }

        private bool win()
        {
            // check rows
            if (_board[0, 0] == Player && _board[0, 1] == Player && _board[0, 2] == Player)
                return true;
            if (_board[1, 0] == Player && _board[1, 1] == Player && _board[1, 2] == Player)
                return true;
            if (_board[2, 0] == Player && _board[2, 1] == Player && _board[2, 2] == Player)
                return true;

            // check columns
            if (_board[0, 0] == Player && _board[1, 0] == Player && _board[2, 0] == Player)
                return true;
            if (_board[0, 1] == Player && _board[1, 1] == Player && _board[2, 1] == Player)
                return true;
            if (_board[0, 2] == Player && _board[1, 2] == Player && _board[2, 2] == Player)
                return true;

            // check diagonals
            if (_board[0, 0] == Player && _board[1, 1] == Player && _board[2, 2] == Player)
                return true;
            if (_board[0, 2] == Player && _board[1, 1] == Player && _board[2, 0] == Player)
                return true;

            return false;
        }

        private bool draw()
        {
            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < 3; c++)
                {
                    if (_board[r, c] == 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private bool checkBoard(int r, int c)
        {
            if (r > 3 || c > 3 || r < 1 || c < 1)
            {
                return false;
            }
            else if (_board[r - 1, c - 1] != 1 && _board[r - 1, c - 1] != 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void intBoard()
        {
            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < 3; c++)
                {
                    _board[r, c] = 0;
                }
            }

            displayBoard();
        }

        private static void displayBoard()
        {
            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < 3; c++)
                {
                    Console.Write(_board[r,c] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
