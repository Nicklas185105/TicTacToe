using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToeAI
{
    public enum GameState
    {
        InPlay,
        Xwin,
        Owin,
        Draw,
        SearchCompleted
    }

    public struct Move
    {
        public int Index;
        public GameState MoveResult;
    }
}
