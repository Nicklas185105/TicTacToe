namespace TicTacToeAI.Interfaces
{
    public interface IGameScorer
    {
        Line BestLineO { get; }
        Line BestLineX { get; }
        int BestScoreO { get; }
        int BestScoreX { get; }
        int GetBestImpactSquare();
        void Reset(IBoard board);
    }
}
