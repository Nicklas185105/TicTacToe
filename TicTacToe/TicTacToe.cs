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
            set { _playerName = value; }
        }

        public bool win()
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

        public bool draw()
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

        public void updateBoard(int r, int c, int player)
        {
            _board[r - 1, c - 1] = player;
        }

        public int[,] getBoard()
        {
            return _board;
        }

        public bool checkBoard(int r, int c)
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

        public static void initializeBoard()
        {
            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < 3; c++)
                {
                    _board[r, c] = 0;
                }
            }
        }
    }
}
