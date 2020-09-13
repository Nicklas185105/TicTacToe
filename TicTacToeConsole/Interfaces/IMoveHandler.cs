namespace TicTacToeAI.Interfaces
{
    public interface IMoveHandler
    {
        bool IsHandled { get; set; }

        MoveHandler HandleStrategicMove();
        MoveHandler HandeOWinOnNext();
        MoveHandler HandeXWin();
        MoveHandler HandlePossibleFork();
        bool IsGameADraw();
        void Reset(IBoard board);
    }
}
