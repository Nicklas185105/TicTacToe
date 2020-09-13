using TicTacToeAI.Interfaces;

namespace TicTacToeAI
{
    public class LineService : ILineService
    {
        private readonly int[] searchOrder = new int[] { 1, 0, 2 };

        public bool TryFindEmptySquare(Line line, out int result)
        {
            for (int i = 0; i < line.Squares.Length; i++)
            {
                if (line.Squares[searchOrder[i]].IsEmpty)
                {
                    result = line.Squares[searchOrder[i]].BoardIndex;
                    return true;
                }
            }
            result = -1;
            return false;
        }

        public bool TrySelectAntiForkSquare(IBoard board, out int result)
        {
            int[,] cornerLines = board.CornerLines;
            for (int i = 0; i < cornerLines.GetLength(0); i++)
            {
                if (board.Lines[cornerLines[i, 0]].OScore == 1
                    && board.Lines[cornerLines[i, 1]].OScore == 1
                    && board[cornerLines[i, 2]].Content != 'O')
                {
                    return TryFindEmptySquare(board.Lines[cornerLines[i, 0]], out result);
                }
            }
            result = -1;
            return false;
        }
    }
}
