using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToeLogic
{
    public class Computer
    {
        Player player;
        int moveCounter;

        public Computer(int playerNumber)
        {
            player = new Player("Computer", playerNumber);
            moveCounter = 0;
        }

        public Player GetPlayer()
        {
            return player;
        }

        public void NextMove(Logic logic, out int r, out int c)
        {
            moveCounter++;
            int[,] board = logic.GetBoard();
            r = 0;
            c = 0;

            switch (moveCounter)
            {
                case 1:
                    if (board[0,0] == 1 || board[0,2] == 1 || board[2,0] == 1 || board[2,2] == 1)
                    {
                        r = 1;
                        c = 1;
                        break;
                    }
                    else if (board[1,1] == 1)
                    {
                        r = 2;
                        c = 2;
                        break;
                    }
                    else
                    {
                        r = 1;
                        c = 1;
                        break;
                    }
                case 2:
                    if (playerAbleToWin(board, 2, 1, out int r1, out int c1))
                    {
                        r = r1;
                        c = c1;
                        break;
                    }
                    else
                    {
                        playerAbleToWin(board, 1, 2, out r, out c);
                        break;
                    }
                case 3:
                    if(playerAbleToWin(board, 2, 1, out r1, out c1))
                    {
                        r = r1;
                        c = c1;
                        break;
                    }
                    else
                    {
                        playerAbleToWin(board, 1, 2, out r, out c);
                        break;
                    }
                case 4:
                    if (playerAbleToWin(board, 2, 1, out r1, out c1))
                    {
                        r = r1;
                        c = c1;
                        break;
                    }
                    else
                    {
                        playerAbleToWin(board, 1, 2, out r, out c);
                        break;
                    }
                case 5:
                    if (playerAbleToWin(board, 2, 1, out r1, out c1))
                    {
                        r = r1;
                        c = c1;
                        break;
                    }
                    else
                    {
                        playerAbleToWin(board, 1, 2, out r, out c);
                        break;
                    }
                default:
                    r = 0;
                    c = 0;
                    break;
            }

            r++;
            c++;
        }

        public bool playerAbleToWin(int[,] board, int one, int two, out int r, out int c)
        {
            int _1 = board[0,0];
            int _2 = board[0,1];
            int _3 = board[0,2];
            int _4 = board[1,0];
            int _5 = board[1,1];
            int _6 = board[1,2];
            int _7 = board[2,0];
            int _8 = board[2,1];
            int _9 = board[2,2];

            if (_1 == one)
            {
                if (_2 == one)
                    if (_3 != two)
                    {
                        r = 0; 
                        c = 2; 
                        return true;
                    }
                if (_3 == one)
                    if (_2 != two)
                    {
                        r = 0;
                        c = 1;
                        return true;
                    }
                if (_4 == one)
                    if (_7 != two)
                    {
                        r = 2;
                        c = 0;
                        return true;
                    }
                if (_5 == one)
                    if (_9 != two)
                    {
                        r = 2;
                        c = 2;
                        return true;
                    }
                if (_7 == one)
                    if (_4 != two)
                    {
                        r = 1;
                        c = 0;
                        return true;
                    }
                if (_9 == one)
                    if (_5 != two)
                    {
                        r = 1;
                        c = 1;
                        return true;
                    }
            }
            if (_2 == one)
            {
                if (_3 == one)
                    if (_1 != two)
                    {
                        r = 0;
                        c = 0;
                        return true;
                    }
                if (_5 == one)
                    if (_8 != two)
                    {
                        r = 2;
                        c = 1;
                        return true;
                    }
                if (_8 == one)
                    if (_5 != two)
                    {
                        r = 1;
                        c = 1;
                        return true;
                    }
            }
            if (_3 == one)
            {
                if (_5 == one)
                    if (_7 != two)
                    {
                        r = 2;
                        c = 0;
                        return true;
                    }
                if (_6 == one)
                    if (_9 != two)
                    {
                        r = 2;
                        c = 2;
                        return true;
                    }
                if (_7 == one)
                    if (_5 != two)
                    {
                        r = 1;
                        c = 1;
                        return true;
                    }
                if (_9 == one)
                    if (_6 != two)
                    {
                        r = 1;
                        c = 2;
                        return true;
                    }
            }
            if (_4 == one)
            {
                if (_5 == one)
                    if (_6 != two)
                    {
                        r = 1;
                        c = 2;
                        return true;
                    }
                if (_6 == one)
                    if (_5 != two)
                    {
                        r = 1;
                        c = 1;
                        return true;
                    }
                if (_7 == one)
                    if (_1 != two)
                    {
                        r = 0;
                        c = 0;
                        return true;
                    }
            }
            if (_5 == one)
            {
                if (_6 == one)
                    if (_4 != two)
                    {
                        r = 1;
                        c = 0;
                        return true;
                    }
                if (_7 == one)
                    if (_3 != two)
                    {
                        r = 0;
                        c = 2;
                        return true;
                    }
                if (_8 == one)
                    if (_2 != two)
                    {
                        r = 0;
                        c = 1;
                        return true;
                    }
                if (_9 == one)
                    if (_1 != two)
                    {
                        r = 0;
                        c = 0;
                        return true;
                    }
            }
            if (_6 == one)
            {
                if (_9 == one)
                    if (_3 != two)
                    {
                        r = 0;
                        c = 2;
                        return true;
                    }
            }
            if (_7 == one)
            {
                if (_8 == one)
                    if (_9 != two)
                    {
                        r = 2;
                        c = 2;
                        return true;
                    }
                if (_9 == one)
                    if (_8 != two)
                    {
                        r = 2;
                        c = 1;
                        return true;
                    }
            }
            if (_8 == one)
            {
                if (_9 == one)
                    if (_7 != two)
                    {
                        r = 2;
                        c = 0;
                        return true;
                    }
            }

            // Check where there is empty
            if (_1 == 0)
            {
                r = 0;
                c = 0;
                return false;
            }
            if (_2 == 0)
            {
                r = 0;
                c = 1;
                return false;
            }
            if (_3 == 0)
            {
                r = 0;
                c = 2;
                return false;
            }
            if (_4 == 0)
            {
                r = 1;
                c = 0;
                return false;
            }
            if (_5 == 0)
            {
                r = 1;
                c = 1;
                return false;
            }
            if (_6 == 0)
            {
                r = 1;
                c = 2;
                return false;
            }
            if (_7 == 0)
            {
                r = 2;
                c = 0;
                return false;
            }
            if (_8 == 0)
            {
                r = 2;
                c = 1;
                return false;
            }
            if (_9 == 0)
            {
                r = 2;
                c = 2;
                return false;
            }
            r = 0;
            c = 0;
            return false;
        }
    }
}
