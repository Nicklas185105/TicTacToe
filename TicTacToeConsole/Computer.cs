using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToeConsole
{
    class Computer
    {
        Player player;
        public Computer(int playerNumber)
        {
            player = new Player("Computer", playerNumber);
        }

        public Player GetPlayer()
        {
            return player;
        }
    }
}
