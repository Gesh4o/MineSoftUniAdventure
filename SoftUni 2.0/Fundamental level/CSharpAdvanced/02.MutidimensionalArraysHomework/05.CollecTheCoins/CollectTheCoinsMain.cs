namespace _05.CollecTheCoins
{
    using System;

    using _05.CollecTheCoins.Core;

    public class CollectTheCoinsMain
    {
        public static void Main()
        {
            // Here are two solutions for this problem: one tool me 20-30 mins to write it, the another one about and hour and a half- guess which is it!
            // I have low abstraction and probably bad coupling inside the engine class so any others remarks will be highly valued(or even example ways to fix it)
            var commandFactory = new CommandFactory();
            var engine = new Engine(commandFactory);
            engine.Run();

// The another solution.
#region
            const int DefaultGameboardRows = 4;
            char[][] gameboard = new char[DefaultGameboardRows][];

            for (int i = 0; i < DefaultGameboardRows; i++)
            {
                gameboard[i] = Console.ReadLine().ToCharArray();
            }

            char[] commands = Console.ReadLine().ToCharArray();
            int coinsCollected = 0;
            int wallsHit = 0;

            int[] currentPosition = { 0, 0 };
            if (gameboard[0][0] == '$')
            {
                coinsCollected++;
            }

            for (int command = 0; command < commands.Length; command++)
            {
                switch (commands[command])
                {
                    case 'V':
                        if (currentPosition[0] + 1 >= DefaultGameboardRows)
                        {
                            wallsHit++;
                        }
                        else if (gameboard[currentPosition[0] + 1].Length - 1 < currentPosition[1])
                        {
                            wallsHit++;
                        }
                        else
                        {
                            currentPosition[0]++;
                        }

                        break;
                    case '^':
                        if (currentPosition[0] - 1 < 0)
                        {
                            wallsHit++;
                        }
                        else if (gameboard[currentPosition[0] - 1].Length - 1 < currentPosition[1])
                        {
                            wallsHit++;
                        }
                        else
                        {
                            currentPosition[0]--;
                        }

                        break;
                    case '<':
                        if (currentPosition[1] - 1 < 0)
                        {
                            wallsHit++;
                        }
                        else
                        {
                            currentPosition[1]--;
                        }

                        break;
                    case '>':
                        if (currentPosition[1] + 1 > gameboard[currentPosition[0]].Length - 1)
                        {
                            wallsHit++;
                        }
                        else
                        {
                            currentPosition[1]++;
                        }

                        break;
                }

                if (gameboard[currentPosition[0]][currentPosition[1]] == '$')
                {
                    coinsCollected++;
                }
            }

            Console.WriteLine("Coins collected: {0}", coinsCollected);
            Console.WriteLine("Walls hit: {0}", wallsHit);
#endregion
        }
    }
}
