namespace Minesweeper.Models.Commands
{
    using Contracts;

    public class TurnCommand : AbstractCommand
    {
        private string[] inputArgs;

        public TurnCommand(IGameEngine engine, string[] inputArgs) 
            : base(engine)
        {
            this.inputArgs = inputArgs;
        }

        public override void Execute()
        {
            const int MaxCellsToOpenCount = 35;

            int row = int.Parse(this.inputArgs[0]);
            int col = int.Parse(this.inputArgs[1]);

            if (this.GameEngine.Bombs[row, col] != '*')
            {
                if (this.GameEngine.Bombs[row, col] == '-')
                {
                    PerformTurn(this.GameEngine.GameField, this.GameEngine.Bombs, row, col);
                    this.GameEngine.Counter++;
                }

                if (MaxCellsToOpenCount == this.GameEngine.Counter++)
                {
                    this.GameEngine.HasEnded = true;
                }
                else
                {
                    this.GameEngine.Draw(this.GameEngine.GameField);
                }
            }
            else
            {
                this.GameEngine.IsBombed = true;
            }
        }

        private static void PerformTurn(char[,] field, char[,] bombs, int row, int col)
        {
            char neighbouringBombsCount = GetNeighbouringBombsCount(bombs, row, col);
            bombs[row, col] = neighbouringBombsCount;
            field[row, col] = neighbouringBombsCount;
        }

        private static char GetNeighbouringBombsCount(char[,] bombs, int row, int col)
        {
            // We have our bomb field and we can get its rows and cols length and also current coordinates on the field.
            // The task here is to find all neighbouring bombs count.
            int neighbouringBombsCounter = 0;
            int rows = bombs.GetLength(0);
            int cols = bombs.GetLength(1);

            // Checking all rows above first one.
            if (row - 1 >= 0)
            {
                // If there is bomb below it- increment the counter.
                if (bombs[row - 1, col] == '*')
                {
                    neighbouringBombsCounter++;
                }
            }

            // Checking all rows below the last one.
            if (row + 1 < rows)
            {
                // Same logic here- incrementing the counter if neighbouring bomb is avaible(in our case right below the current coordinates).
                if (bombs[row + 1, col] == '*')
                {
                    neighbouringBombsCounter++;
                }
            }

            // The same logic goes for the collumns.
            if (col - 1 >= 0)
            {
                if (bombs[row, col - 1] == '*')
                {
                    neighbouringBombsCounter++;
                }
            }

            if (col + 1 < cols)
            {
                if (bombs[row, col + 1] == '*')
                {
                    neighbouringBombsCounter++;
                }
            }

            // Checking for a neighbouring bomb top left from the current coordinates.
            if ((row - 1 >= 0) && (col - 1 >= 0))
            {
                if (bombs[row - 1, col - 1] == '*')
                {
                    neighbouringBombsCounter++;
                }
            }

            // Same here but for the bottom right.
            if ((row - 1 >= 0) && (col + 1 < cols))
            {
                if (bombs[row - 1, col + 1] == '*')
                {
                    neighbouringBombsCounter++;
                }
            }

            // Upper left.
            if ((row + 1 < rows) && (col - 1 >= 0))
            {
                if (bombs[row + 1, col - 1] == '*')
                {
                    neighbouringBombsCounter++;
                }
            }

            // Upper right.
            if ((row + 1 < rows) && (col + 1 < cols))
            {
                if (bombs[row + 1, col + 1] == '*')
                {
                    neighbouringBombsCounter++;
                }
            }

            // Now the counter will be returned as a char so it can be put in the bomb field and the field itself so it can be later displayed.
            return char.Parse(neighbouringBombsCounter.ToString());
        }
    }
}
