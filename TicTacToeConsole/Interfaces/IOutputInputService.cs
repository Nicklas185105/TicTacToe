namespace TicTacToeAI.Interfaces
{
    public interface IOutputInputService
    {
        int GetMoveFromPlayer();
        void OutputGameResult(Move gameResult, IBoard board);
        void ShowBoard(IBoard board);
        bool GetIsYes(string prompt);
        void ResetFreeSquareChoices();
        void DisplayMessage(string msg);
    }
}
