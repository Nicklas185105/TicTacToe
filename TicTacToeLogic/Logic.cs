using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToeLogic
{
    public class Logic
    {
        int[,] _board;
        int width;
        int height;

        public Logic(int width, int height)
        {
            this.width = width;
            this.height = height;
            _board = new int[width, height];
            InitializeBoard();
        }

        void InitializeBoard()
        {
            for (int r = 0; r < height; r++)
            {
                for (int c = 0; c < width; c++)
                {
                    _board[r, c] = 0;
                }
            }
        }

        public int[,] GetBoard()
        {
            return _board;
        }

        public void UpdateBoard(int r, int c, int playerNumber)
        {
            _board[r - 1, c - 1] = playerNumber;
        }

        public bool CheckBoard(int r, int c)
        {
            if (r > height || c > width || r < 1 || c < 1)
                return false;
            else if (_board[r - 1, c - 1] == 0)
                return true;
            else
                return false;
        }

        public bool Draw()
        {
            for (int r = 0; r < height; r++)
            {
                for (int c = 0; c < width; c++)
                {
                    if (_board[r, c] == 0)
                        return false;
                }
            }

            return true;
        }

        public bool Win(int playerNumber)
        {
            // Rows
            if (_board[0, 0] == playerNumber && _board[0, 1] == playerNumber && _board[0, 2] == playerNumber)
                return true;
            if (_board[1, 0] == playerNumber && _board[1, 1] == playerNumber && _board[1, 2] == playerNumber)
                return true;
            if (_board[2, 0] == playerNumber && _board[2, 1] == playerNumber && _board[2, 2] == playerNumber)
                return true;

            // Columns
            if (_board[0, 0] == playerNumber && _board[1, 0] == playerNumber && _board[2, 0] == playerNumber)
                return true;
            if (_board[0, 1] == playerNumber && _board[1, 1] == playerNumber && _board[2, 1] == playerNumber)
                return true;
            if (_board[0, 2] == playerNumber && _board[1, 2] == playerNumber && _board[2, 2] == playerNumber)
                return true;

            // Diagonals
            if (_board[0, 0] == playerNumber && _board[1, 1] == playerNumber && _board[2, 2] == playerNumber)
                return true;
            if (_board[0, 2] == playerNumber && _board[1, 1] == playerNumber && _board[2, 0] == playerNumber)
                return true;

            return false;
        }
    }
}
