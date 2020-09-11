using System;
using TicTacToeLogic;

namespace TicTacToeConsole
{
    class Program
    {
        static int height;
        static int width;
        static bool vsComputer;

        static Computer computer;

        static void Main(string[] args)
        {
            GameLoop();
        }

        static void GameLoop()
        {
            Player player1;
            Player player2;

            string answer = "";
            bool answerBool = false;
            bool gameLoop = true;
            bool gameDone = false;
            #region Start
            Console.WriteLine("Welcome to Tic Tac Toe Console Edition!");
            Console.WriteLine();
            Console.WriteLine("What is your name?");
            player1 = new Player(Console.ReadLine(), 1);
            Console.WriteLine();
            Console.WriteLine(player1.GetPlayerName() + " are you going to play against the computer?");
            Console.WriteLine("y/n");
            while (!answerBool)
            {
                answer = Console.ReadLine().ToLower();
                if (answer.Equals("y"))
                {
                    vsComputer = true;
                    answerBool = true;
                }
                else if (answer.Equals("n"))
                {
                    vsComputer = false;
                    answerBool = true;
                }
            }

            computer = new Computer(2);
            player2 = new Player("", 2);
            if (vsComputer)
            {
                Console.WriteLine();
                Console.WriteLine("The computer is now generated and ready for to play");
                height = 3;
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("What is the name of the second player?");
                player2.UpdatePlayerName(Console.ReadLine());

                Console.WriteLine();
                Console.WriteLine("You can player with the traditional board size (3x3) or a bigger one");
                Console.WriteLine("Please enter height and width for the board");
                answerBool = false;
                while (!answerBool)
                {
                    int.TryParse(Console.ReadLine().Trim(), out height);
                    if (height < 3)
                        Console.WriteLine("Please write a bigger number!");
                    else
                        answerBool = true;
                }
            }
            width = height;
            #endregion

            while (gameLoop)
            {
                Logic logic = new Logic(width, height);
                ConsoleUI consoleUI = new ConsoleUI(width, height);
                computer = new Computer(2);
                consoleUI.ClearConsole();
                consoleUI.DisplayBoard(logic.GetBoard());
                int turn = 0;

                while (!gameDone)
                {
                    Console.WriteLine();
                    if (turn % 2 == 0) // Player1
                    {
                        PlayerTurn(player1, logic, false);
                    }
                    else // Player2
                    {
                        PlayerTurn(vsComputer ? computer.GetPlayer() : player2, logic, vsComputer);
                    }

                    consoleUI.ClearConsole();

                    // Check game state
                    if (logic.Win(player1.GetPlayerNumber()))
                    {
                        Console.WriteLine("Congratulations " + player1.GetPlayerName() + ". You Win!");
                        player1.UpdatePlayerWins(player1.GetPlayerWins() + 1);
                        gameDone = true;
                    }
                    else if (logic.Draw())
                    {
                        Console.WriteLine("It's a Draw!");
                        gameDone = true;
                    }
                    else if (logic.Win(vsComputer ? computer.GetPlayer().GetPlayerNumber() : player2.GetPlayerNumber()))
                    {
                        if (vsComputer)
                        {
                            Console.WriteLine("The computer wins!");
                            computer.GetPlayer().UpdatePlayerWins(computer.GetPlayer().GetPlayerWins() + 1);
                        }
                        else
                        {
                            Console.WriteLine("Congratulations " + player2.GetPlayerName() + ". You Win!");
                            player2.UpdatePlayerWins(player2.GetPlayerWins() + 1);
                        }
                        gameDone = true;
                    }
                    else
                        consoleUI.DisplayBoard(logic.GetBoard());

                    turn++;
                }

                // Display the score here
                Console.WriteLine();
                Console.WriteLine("Score: ");
                Console.WriteLine(player1.GetPlayerName() + ": " + player1.GetPlayerWins() + " Wins.");
                if (vsComputer)
                    Console.WriteLine(computer.GetPlayer().GetPlayerName() + ": " + computer.GetPlayer().GetPlayerWins() + " Wins.");
                else
                    Console.WriteLine(player2.GetPlayerName() + ": " + player2.GetPlayerWins() + " Wins.");

                Console.WriteLine();
                Console.WriteLine("Do you want to player again? Press ESC to quit");
                if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                    gameLoop = false;
                else
                    gameDone = false;

                Console.WriteLine();
            }
        }

        static void PlayerTurn(Player player, Logic logic, bool vsComputer)
        {
            int r = 0;
            int c = 0;
            if (!vsComputer)
            {
                Console.WriteLine(player.GetPlayerName() + " please enter board coordinates!");
                int.TryParse(Console.ReadLine().Trim(), out r);
                int.TryParse(Console.ReadLine().Trim(), out c);
                while (!logic.CheckBoard(r, c))
                {
                    Console.WriteLine("That place is already occupied! Please pick another place");
                    int.TryParse(Console.ReadLine().Trim(), out r);
                    int.TryParse(Console.ReadLine().Trim(), out c);
                }
                logic.UpdateBoard(r, c, player.GetPlayerNumber());
            }
            else
            {
                // Run computer logic
                computer.NextMove(logic, out r, out c);

                logic.UpdateBoard(r, c, player.GetPlayerNumber());
            }
        }
    }
}
