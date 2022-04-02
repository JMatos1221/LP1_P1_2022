using LP1_P1_2022.Model;

namespace LP1_P1_2022.View
{
    public class MainView
    {
        /// <summary>
        /// Prints the menu options
        /// </summary>
        public void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("[1] Play");
            Console.WriteLine("[2] Rules");
            Console.WriteLine("[3] Quit");
            Console.WriteLine();
        }

        /// <summary>
        /// Prints the game table
        /// </summary>
        /// <param name="table">Game table</param>
        public void PrintTable(Table table)
        {
            Console.Clear();

            // Iterates the game table, and prints each space
            for (int i = table.Y - 1; i >= 0; i--)
            {
                if (i % 2 == 0)
                    for (int j = 0; j < table.X; j++)
                    {
                        Console.BackgroundColor = GetColor(table.Spaces[i, j]);
                        Console.Write($" {i * table.X + j + 1:D2} ");
                    }
                else
                    for (int j = table.X - 1; j >= 0; j--)
                    {
                        Console.BackgroundColor = GetColor(table.Spaces[i, j]);
                        Console.Write($" {i * table.X + j + 1:D2} ");
                    }

                Console.ResetColor();
                Console.WriteLine();
            }

            Console.ResetColor();
            Console.WriteLine();
        }

        /// <summary>
        /// Gets the color of a given space
        /// </summary>
        /// <param name="space">Space to get the color from</param>
        /// <returns></returns>
        private ConsoleColor GetColor(Space space)
        {
            return space switch
            {
                Space.Snakes => ConsoleColor.Red,
                Space.Ladders => ConsoleColor.Blue,
                Space.Cobra => ConsoleColor.Green,
                Space.Boost => ConsoleColor.Cyan,
                Space.UTurn => ConsoleColor.DarkMagenta,
                Space.ExtraDie => ConsoleColor.White,
                Space.CheatDie => ConsoleColor.Yellow,
                _ => ConsoleColor.Black
            };
        }

        /// <summary>
        /// Prints an error message
        /// </summary>
        /// <param name="errorName">Error type</param>
        public void PrintError(string errorName)
        {
            // Error output
            string error;

            error = errorName switch
            {
                "menu" =>
                    "Not a valid menu option, use the numeric options. [1] [2] [3]",
                _ => "Error!"
            };

            Console.WriteLine(error + "\n");
        }

        /// <summary>
        /// Prints the game end
        /// </summary>
        /// <param name="winner">Game winner</param>
        public void PrintGameEnd(Player winner)
        {
            Console.WriteLine($"Player {winner.Appearance} won the game!");
            Console.ReadKey();
        }

        /// <summary>
        /// Reads the user input
        /// </summary>
        /// <returns>User input in lowercase and without white spaces</returns>
        public string ReadInput()
        {
            return Console.ReadLine().Trim().ToLower();
        }
    }
}