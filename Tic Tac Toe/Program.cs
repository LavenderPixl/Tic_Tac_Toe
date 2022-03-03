using System;
using System.Collections.Generic;

namespace TicTacToe
{
    class Program
    {
        static int gameStage =
            0; //0 = Running | 1 = Player 1 Won | 2 = Player 2 Won | 3 = Draw! |
        static string[] plads =
            new string[9] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };

        private static int currPlayer = 1;
        private static int rounds = 0;

        private static Dictionary<int, string> PlayerChar = new Dictionary<int, string>
        {
            {1, "X"},
            {2, "O"}
        };

        static int GameStatus()
        {
            var playerChar = PlayerChar[currPlayer];
            if ((plads[0] == playerChar && plads[1] == playerChar && plads[2] == playerChar) || (plads[3] == playerChar && plads[4] == playerChar && plads[5] == playerChar) ||
                (plads[6] == playerChar && plads[7] == playerChar && plads[8] == playerChar) || (plads[0] == playerChar && plads[4] == playerChar && plads[8] == playerChar) ||
                (plads[0] == playerChar && plads[3] == playerChar && plads[6] == playerChar) || (plads[1] == playerChar && plads[4] == playerChar && plads[7] == playerChar) ||
                (plads[2] == playerChar && plads[5] == playerChar && plads[8] == playerChar) || (plads[2] == playerChar && plads[4] == playerChar && plads[6] == playerChar))
            {
                return gameStage = currPlayer;
            }
            if (rounds == 10 && gameStage == 0)
                return gameStage = 3;
            return gameStage = 0;
        }
        static void Board()
        {
            Console.WriteLine("               |       |       ");
            Console.WriteLine($"          [{plads[0]}]  |  [{plads[1]}]  |  [{plads[2]}]  ");
            Console.WriteLine("        _______|_______|_______");
            Console.WriteLine("               |       |       ");
            Console.WriteLine($"          [{plads[3]}]  |  [{plads[4]}]  |  [{plads[5]}]  ");
            Console.WriteLine("        _______|_______|_______");
            Console.WriteLine("               |       |       ");
            Console.WriteLine($"          [{plads[6]}]  |  [{plads[7]}]  |  [{plads[8]}]  ");
            Console.WriteLine("               |       |       ");
        }
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("__________|Welcome to TicTacToe|__________");
                Console.WriteLine("What is the name over Player 1?");
                var player1 = Console.ReadLine();
                Console.WriteLine("Thank you, what is the name of Player 2?");
                var player2 = Console.ReadLine();
                Console.WriteLine("Thank you.\n" + player1 + " is X, and " + player2 + " is O. \nGame is ready to start, please press Any Key.");
                Console.ReadKey();
                do
                {
                    rounds += 1;
                    Console.Clear();
                    Console.WriteLine("\n");
                    Board();

                    Console.WriteLine($"\n  {(currPlayer == 1 ? player1 : player2)}'s turn.");
                    var choice = Console.ReadLine();
                    bool isValid = int.TryParse(choice, out var index);
                    while (!isValid || index is > 9 or < 1 || plads[index - 1] == "X" || plads[index - 1] == "O")
                    {
                        string text;
                        if (!isValid || index is > 9 or < 1) text = $"{choice} is not a valid input. Number 1-9 are valid inputs!";
                        else
                            text = $"Field {index} is already taken. Choose a new field:\n";
                        Console.WriteLine(text);
                        choice = Console.ReadLine();
                        isValid = int.TryParse(choice, out index);
                    }
                    plads[index - 1] = currPlayer == 1 ? "X" : "O";

                    GameStatus();
                    currPlayer = currPlayer == 1 ? 2 : 1;

                }
                while (gameStage != 1 && gameStage != 2 && gameStage != 3);
                Console.Clear();
                Console.WriteLine("\n");
                Board();
                var endText = gameStage == 3
                    ? "It's a draw!"
                    : $"Congratulations, player {(currPlayer == 1 ? player1 : player2)} has won!";
                Console.WriteLine(endText);
                Console.WriteLine("Press Any Key, to restart.");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

    }
}
