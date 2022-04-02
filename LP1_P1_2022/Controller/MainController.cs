using System;
using LP1_P1_2022.Model;
using LP1_P1_2022.View;
namespace LP1_P1_2022.Controller
{
    public class MainController
    {
        // Game table
        private Table _table;

        // Random number generated
        private Random _rnd;

        // Players array
        private Player[] _players;

        // Current player turn
        private Player _playerTurn;

        /// <summary>
        /// Controller constructor, receives table instance
        /// </summary>
        /// <param name="table">Game table</param>
        public MainController(Table table)
        {
            _table = table;
        }

        /// <summary>
        /// Sets up the game table and players
        /// </summary>
        private void Setup()
        {
            // Create players
            _players = new[] { new Player('A'), new Player('B') };

            // Sets player turn to the first player
            _playerTurn = _players[0];


            // Fill the table with spaces of type Normal
            for (int i = 0; i < _table.Spaces.GetLength(0); i++)
                for (int j = 0; j < _table.Spaces.GetLength(1); j++)
                    _table.SetSpace(i, j, Space.Normal);

            _rnd = new Random();

            // Generate Snakes
            GenerateSpace(Space.Snakes, 2, 4, 1, _table.X);
            // Generate Ladders
            GenerateSpace(Space.Ladders, 2, 4, 0, _table.X - 1);
            // Generate Cobras
            GenerateSpace(Space.Cobra, 1, 1, 2, _table.X);
            // Generate Boosts
            GenerateSpace(Space.Boost, 0, 2, 0, _table.X - 1);
            // Generate U-Turns
            GenerateSpace(Space.UTurn, 0, 2, 1, _table.X);

            // GenerateSpace(Space.ExtraDie, 1, 1, 0, _table.X);
            // GenerateSpace(Space.CheatDie, 1, 1, 0, _table.X);
        }

        /// <summary>
        /// Generate a random amount of a given space type within the
        /// given amount and row limits
        /// </summary>
        /// <param name="space">Space to generate</param>
        /// <param name="min">Minimum amount that can be generated</param>
        /// <param name="max">Maximum amount that can be generated</param>
        /// <param name="rowMin">Lowest row to place space</param>
        /// <param name="rowMax">Highest row to place space</param>
        private void GenerateSpace(Space space, int min, int max, int rowMin,
                                   int rowMax)
        {
            /// <summary>
            /// Amount of generated spaces of the specified type
            /// </summary>
            /// <returns>Random number in the given range</returns>
            int amount = _rnd.Next(min, max + 1);

            // Get random table positions until the given amount
            // of the space type is generated
            for (int i = 0; i < amount;)
            {
                int x = _rnd.Next(0, _table.Y);
                int y = _rnd.Next(rowMin, rowMax);

                // Continue the loop if it's not a Normal space or if
                // it is the first or last space of the board
                if (_table.Spaces[y, x] != Space.Normal ||
                    x == 0 && y == 0 ||
                    x == _table.X - 1 && y == _table.Y - 1)
                    continue;

                // Sets the table space
                _table.SetSpace(x, y, space);
                i++;
            }
        }

        /// <summary>
        /// /// Gameloop, runs endlessly until the player quits the game
        /// </summary>
        /// <param name="view">View object that outputs data and receives input
        /// from the user</param>
        public void CoreLoop(MainView view)
        {
            bool menu = true;
            bool game = false;

            // Menu loop
            do
            {
                view.PrintMenu();

                string option = view.ReadInput();

                // Switch case to read the selected option
                switch (option)
                {
                    case "1":
                        Setup();

                        view.PrintTable(_table, _players, "");

                        game = true;

                        break;

                    case "2":

                        break;

                    case "3":
                        menu = false;

                        break;

                    default:
                        view.PrintError("menu");

                        break;
                }

                // Game loop
                while (game)
                {
                }
            } while (menu);
        }
    }
}