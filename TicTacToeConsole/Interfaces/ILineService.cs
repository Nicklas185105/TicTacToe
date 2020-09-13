namespace TicTacToeAI.Interfaces
{
    public interface ILineService
    {
        bool TryFindEmptySquare(Line line, out int result);
        bool TrySelectAntiForkSquare(IBoard board, out int result);
    }
}
