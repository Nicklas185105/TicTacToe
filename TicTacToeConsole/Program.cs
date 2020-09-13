using MatchBoxCore;
using TicTacToeAI.Interfaces;

namespace TicTacToeAI
{
    class Program
    {
        static void Main(string[] args)
        {
            var Ioc = new MatchBox();

            ConfigureServices(Ioc);
            var game = Ioc.Get<IGame>();
            game.StartGame();
        }

        private static void ConfigureServices(MatchBox Ioc)
        {
            Ioc.RegisterSingleton<IBoard, OXBoard>();
            Ioc.Register<ILineService, LineService>();
            Ioc.Register<IOutputInputService, ConsoleService>();
            Ioc.Register<IGameScorer, GameScorer>();
            Ioc.Register<IMoveHandler, MoveHandler>();
            Ioc.Register<IGame, Game>();
        }
    }
}
