namespace TicTacToeAI.Interfaces
{
    public interface IGame
    {
        Move MoveO();
        Move MoveX(IBoard board);
        void StartGame();
    }
}
