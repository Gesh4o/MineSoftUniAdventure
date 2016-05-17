namespace Minesweeper.Core
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Contracts;
    using Models;
    using Models.Interfaces;

    public class GameEngine : IGameEngine
    {
        private char[,] gameField;
        private char[,] bombs;
        private bool hasStarted;
        private bool hasEnded;
        private bool isBombed;
        private int counter;
        private IRankList rankList;
        private ICommandFactory commandFactory;
        private IInputHandler inputHandler;
        private IRenderer renderer;

        public GameEngine(IRankList rankList, ICommandFactory commandFactory, IInputHandler inputHandler, IRenderer renderer)
        {
            this.hasStarted = true;
            this.hasEnded = false;
            this.isBombed = false;
            this.counter = 0;
            this.rankList = rankList;
            this.commandFactory = commandFactory;
            this.inputHandler = inputHandler;
            this.renderer = renderer;
        }

        public int Counter
        {
            get
            {
                return this.counter;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(string.Format($"{nameof(Counter)} cannot be negative!"));
                }

                this.counter = value;
            }
        }

        public bool HasStarted
        {
            get
            {
                return this.hasStarted;
            }

            set
            {
                this.hasStarted = value;
            }
        }

        public bool HasEnded
        {
            get
            {
                return this.hasEnded;
            }

            set
            {
                this.hasEnded = value;
            }
        }

        public bool IsBombed
        {
            get
            {
                return this.isBombed;
            }

            set
            {
                this.isBombed = value;
            }
        }

        public char[,] Bombs
        {
            get
            {
                return this.bombs;
            }

            set
            {
                this.bombs = value;
            }
        }

        public char[,] GameField
        {
            get
            {
                return this.gameField;
            }

            set
            {
                this.gameField = value;
            }
        }

        IRankList IGameEngine.RankList
        {
            get
            {
                return this.rankList;
            }
        }

        public IInputHandler InputHandler
        {
            get
            {
                return this.inputHandler;
            }
        }

        public IRenderer Renderer
        {
            get
            {
                return this.renderer;
            }
        }

        public virtual void Run()
        {
            do
            {
                if (this.HasStarted == true)
                {
                    this.EnterInitialState();
                }

                this.renderer.Print("Insert command or choose row and collumn : ");
                try
                {
                    string commandArgs = this.InputHandler.ReadInput().Trim();
                    ICommand command = this.commandFactory.CreateCommand(this, commandArgs);
                    command.Execute();

                    if (this.IsBombed)
                    {
                        this.EnterDefeatGameState();
                    }

                    if (this.HasEnded)
                    {
                        this.EnterVictoryGameState();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                    throw;
                }
            }
            while (true);
        }

        public virtual char[,] GenerateBombs()
        {
            const int DefaultRowsCount = 5;
            const int DefaultColsCount = 10;

            // Generating the game field here.
            char[,] gameField = new char[DefaultRowsCount, DefaultColsCount];

            for (int row = 0; row < DefaultRowsCount; row++)
            {
                for (int col = 0; col < DefaultColsCount; col++)
                {
                    gameField[row, col] = '-';
                }
            }

            List<int> bombsFieldIndexes = new List<int>(15);

            // Generating bombs' field indexes(linear) on random.
            while (bombsFieldIndexes.Count < 15)
            {
                Random random = new Random();
                int index = random.Next(50);
                if (!bombsFieldIndexes.Contains(index))
                {
                    bombsFieldIndexes.Add(index);
                }
            }

            foreach (int bombIndex in bombsFieldIndexes)
            {
                // Now turning the index in coordinates.
                // Linear index into multi-dimentional indexES.
                int row = bombIndex / DefaultColsCount;
                int col = bombIndex % DefaultColsCount;
                if (col == 0 && bombIndex != 0)
                {
                    row--;
                    col = DefaultColsCount;
                }
                else
                {
                    col++;
                }

                gameField[row, col - 1] = '*';

                // Placing the bombs on the game field.
            }

            return gameField;
        }

        public virtual char[,] GenerateGameField()
        {
            const int BoardRows = 5;
            const int BoardColumns = 10;
            char[,] board = new char[BoardRows, BoardColumns];
            for (int row = 0; row < BoardRows; row++)
            {
                for (int col = 0; col < BoardColumns; col++)
                {
                    board[row, col] = '?';
                }
            }

            return board;
        }

        public virtual void Draw(char[,] board)
        {
            {
                int rows = board.GetLength(0);
                int cols = board.GetLength(1);

                StringBuilder result = new StringBuilder();
                result.AppendLine("\n    0 1 2 3 4 5 6 7 8 9");
                result.AppendLine("   ---------------------");
                for (int row = 0; row < rows; row++)
                {
                    result.AppendFormat("{0} | ", row);
                    for (int col = 0; col < cols; col++)
                    {
                        result.AppendFormat(string.Format("{0} ", board[row, col]));
                    }

                    result.AppendFormat("|");
                    result.AppendLine();
                }

                this.Renderer.Print(result.ToString());
            }
        }

        private void EnterVictoryGameState()
        {
            this.Renderer.Print("\nNice job! You are victorious.");
            this.Draw(this.bombs);
            this.Renderer.Print("Give us your name, champion: ");
            string currentPlayerName = this.InputHandler.ReadInput();
            Player currentPlayer = new Player(currentPlayerName, this.counter);

            this.LogChampionInfo(currentPlayer);

            this.rankList.PrintRankList(this);
            this.GameField = this.GenerateGameField();
            this.Bombs = this.GenerateBombs();
            this.Counter = 0;
            this.HasEnded = false;
            this.HasStarted = true;
        }

        private void EnterDefeatGameState()
        {
            this.Draw(this.bombs);
            this.renderer.Print("{0}Hrrrrrr! Your death was heroic with {1} points. " + "Give us your nickname: ", Environment.NewLine, this.counter);
            string currentPlayerName = this.InputHandler.ReadInput();
            Player currentPlayer = new Player(currentPlayerName, this.counter);

            this.LogChampionInfo(currentPlayer);

            this.GameField = this.GenerateGameField();
            this.Bombs = this.GenerateBombs();
            this.Counter = 0;
            this.IsBombed = false;
            this.HasStarted = true;
        }

        private void LogChampionInfo(IPlayer player)
        {
            if (!this.rankList.IsUpdateNeeded)
            {
                this.rankList.AddChampion(player);
            }
            else
            {
                this.rankList.Update(player);
            }

            this.rankList.Sort();
        }

        private void EnterInitialState()
        {
            this.PrintInitialStateMessage();
            this.GameField = this.GenerateGameField();
            this.Bombs = this.GenerateBombs();
            this.Draw(this.GameField);
            this.HasStarted = false;
        }

        private void PrintInitialStateMessage()
        {
            const string InitialMessage = "Let's play \"Minesweepers\". Try your best to find all fields with no mines!";
            const string CommandInformation = "Command \"top\" shows the Ranklist, \"restart\" restartst the game, and \"exit\" to close the game";

            this.renderer.Print("{0}{1}{2}", InitialMessage, Environment.NewLine, CommandInformation);
        }
    }
}
