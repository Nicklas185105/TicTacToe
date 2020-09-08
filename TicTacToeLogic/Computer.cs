using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToeLogic
{
    public class Computer
    {
        Player player;
        int moveCounter;
        bool tryWin;

        public Computer(int playerNumber)
        {
            player = new Player("Computer", playerNumber);
            moveCounter = 0;
            tryWin = false;
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
                        tryWin = false;
                        r = 1;
                        c = 1;
                        break;
                    }
                    else if (board[1,1] == 1)
                    {
                        tryWin = false;
                        r = 2;
                        c = 2;
                        break;
                    }
                    else
                    {
                        tryWin = true;
                        r = 1;
                        c = 1;
                        break;
                    }
                case 2:
                    if (!tryWin)
                    {
                        if (playerAbleToWin(board, out r, out c))
                        {
                            break;
                        }
                        else
                        {//TODO: fix winning sequence
                            r = 1;
                            c = 0;
                            break;
                        }
                    }
                    else
                    {
                        r = 2;
                        c = 0;
                        break;
                    }
                case 3:
                    if (!tryWin)
                    {
                        playerAbleToWin(board, out r, out c);
                        break;
                    }
                    else
                    {
                        r = 2;
                        c = 2;
                        break;
                    }
                case 4:
                    if (!tryWin)
                    {
                        playerAbleToWin(board, out r, out c);
                        break;
                    }
                    else
                    {
                        if (board[0,0] == 1)
                        {
                            r = 2;
                            c = 1;
                        }
                        else
                        {
                            r = 0;
                            c = 0;
                        }
                        break;
                    }
                case 5:
                    playerAbleToWin(board, out r, out c);
                    break;
                default:
                    r = 0;
                    c = 0;
                    break;
            }

            r++;
            c++;
        }

        public bool playerAbleToWin(int[,] board, out int r, out int c)
        {
            int _1 = 0;
            int _2 = 0;
            int _3 = 0;
            int _4 = 0;
            int _5 = 0;
            int _6 = 0;
            int _7 = 0;
            int _8 = 0;
            int _9 = 0;
            for (int i = 0; i < 9; i++)
            {
                switch (i)
                {
                    case 1:
                        if (board[0, 0] == 1)
                            _1 = 1;
                        else if (board[0, 0] == 2)
                            _1 = 2;
                        break;
                    case 2:
                        if (board[0, 1] == 1)
                            _2 = 1;
                        else if (board[0, 1] == 2)
                            _2 = 2;
                        break;
                    case 3:
                        if (board[0, 2] == 1)
                            _3 = 1;
                        else if (board[0, 2] == 2)
                            _3 = 2;
                        break;
                    case 4:
                        if (board[1, 0] == 1)
                            _4 = 1;
                        else if (board[1, 0] == 2)
                            _4 = 2;
                        break;
                    case 5:
                        if (board[1, 1] == 1)
                            _5 = 1;
                        else if (board[1, 1] == 2)
                            _5 = 2;
                        break;
                    case 6:
                        if (board[1, 2] == 1)
                            _6 = 1;
                        else if (board[2, 2] == 2)
                            _6 = 2;
                        break;
                    case 7:
                        if (board[2, 0] == 1)
                            _7 = 1;
                        else if (board[2, 0] == 2)
                            _7 = 2;
                        break;
                    case 8:
                        if (board[2, 1] == 1)
                            _8 = 1;
                        else if (board[2, 1] == 2)
                            _8 = 2;
                        break;
                    case 9:
                        if (board[2, 2] == 1)
                            _9 = 1;
                        else if (board[2, 2] == 2)
                            _9 = 2;
                        break;
                }
            }

            if (_1 == 1)
            {
                if (_2 == 1)
                    if (_3 != 2)
                    {
                        r = 0; 
                        c = 2; 
                        return true;
                    }
                if (_3 == 1)
                    if (_2 != 2)
                    {
                        r = 0;
                        c = 1;
                        return true;
                    }
                if (_4 == 1)
                    if (_7 != 2)
                    {
                        r = 2;
                        c = 0;
                        return true;
                    }
                if (_5 == 1)
                    if (_9 != 2)
                    {
                        r = 2;
                        c = 2;
                        return true;
                    }
                if (_7 == 1)
                    if (_4 != 2)
                    {
                        r = 1;
                        c = 0;
                        return true;
                    }
                if (_9 == 1)
                    if (_5 != 2)
                    {
                        r = 1;
                        c = 1;
                        return true;
                    }
            }
            if (_2 == 1)
            {
                if (_3 == 1)
                    if (_1 != 2)
                    {
                        r = 0;
                        c = 0;
                        return true;
                    }
                if (_5 == 1)
                    if (_8 != 2)
                    {
                        r = 2;
                        c = 1;
                        return true;
                    }
                if (_8 == 1)
                    if (_5 != 2)
                    {
                        r = 1;
                        c = 1;
                        return true;
                    }
            }
            if (_3 == 1)
            {
                if (_5 == 1)
                    if (_7 != 2)
                    {
                        r = 2;
                        c = 0;
                        return true;
                    }
                if (_6 == 1)
                    if (_9 != 2)
                    {
                        r = 2;
                        c = 2;
                        return true;
                    }
                if (_7 == 1)
                    if (_5 != 2)
                    {
                        r = 1;
                        c = 1;
                        return true;
                    }
                if (_9 == 1)
                    if (_6 != 2)
                    {
                        r = 1;
                        c = 2;
                        return true;
                    }
            }
            if (_4 == 1)
            {
                if (_5 == 1)
                    if (_6 != 2)
                    {
                        r = 1;
                        c = 2;
                        return true;
                    }
                if (_6 == 1)
                    if (_5 != 2)
                    {
                        r = 1;
                        c = 1;
                        return true;
                    }
                if (_7 == 1)
                    if (_1 != 2)
                    {
                        r = 0;
                        c = 0;
                        return true;
                    }
            }
            if (_5 == 1)
            {
                if (_6 == 1)
                    if (_4 != 2)
                    {
                        r = 1;
                        c = 0;
                        return true;
                    }
                if (_7 == 1)
                    if (_3 != 2)
                    {
                        r = 0;
                        c = 2;
                        return true;
                    }
                if (_8 == 1)
                    if (_2 != 2)
                    {
                        r = 0;
                        c = 1;
                        return true;
                    }
                if (_9 == 1)
                    if (_1 != 2)
                    {
                        r = 0;
                        c = 0;
                        return true;
                    }
            }
            if (_6 == 1)
            {
                if (_9 == 1)
                    if (_3 != 2)
                    {
                        r = 0;
                        c = 2;
                        return true;
                    }
            }
            if (_7 == 1)
            {
                if (_8 == 1)
                    if (_9 != 2)
                    {
                        r = 2;
                        c = 2;
                        return true;
                    }
                if (_9 == 1)
                    if (_8 != 2)
                    {
                        r = 2;
                        c = 1;
                        return true;
                    }
            }
            if (_8 == 1)
            {
                if (_9 == 1)
                    if (_7 != 2)
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
