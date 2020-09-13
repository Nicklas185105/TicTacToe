using System.Collections.Generic;

namespace TicTacToeAI.Interfaces
{
    public interface IBoard
    {
        Square this[int index] { get; set; }

        List<Line> Lines { get; }
        IBoard Clone();
        int GetOccupiedSquaresCount();
        IEnumerable<int> GetUnOccupiedSquaresIndexes();
        int[,] CornerLines { get; }
        bool Compare(IBoard test);
        void Reset();
    }
}
