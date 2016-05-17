namespace _12.LabyrinthDash
{
    using System;

    public class LabyrinthDash
    {
        public static void Main()
        {
            // After hour of searching for mistakes I really regret the fact that I just ignored the DRY principle.
            int rows = int.Parse(Console.ReadLine());
            char[][] field = new char[rows][];

            for (int i = 0; i < field.Length; i++)
            {
                field[i] = Console.ReadLine().ToCharArray();
            }

            string command = Console.ReadLine();

            int currentPositionX = 0;
            int currentPositionY = 0;
            int movesMadeCount = 0;
            int livesCount = 3;
            bool isDead = livesCount <= 0;
            foreach (char posCommand in command)
            {
                if (isDead)
                {
                    break;
                }

                switch (posCommand)
                {
                    case '>':
                        if (currentPositionY + 1 >= field[currentPositionX].Length || 
                            field[currentPositionX][currentPositionY + 1] == ' ')
                        {
                            Console.WriteLine("Fell off a cliff! Game Over!");
                            movesMadeCount++;
                            isDead = true;
                        }
                        else if (field[currentPositionX][currentPositionY + 1] == '|' ||
                                 field[currentPositionX][currentPositionY + 1] == '_')
                        {
                            Console.WriteLine("Bumped a wall.");
                        }
                        else
                        {
                            currentPositionY += 1;
                            if (field[currentPositionX][currentPositionY] == '#' ||
                                field[currentPositionX][currentPositionY] == '@' ||
                                field[currentPositionX][currentPositionY] == '*')
                            {
                                livesCount--;
                                Console.WriteLine("Ouch! That hurt! Lives left: {0}", livesCount);

                                if (livesCount == 0)
                                {
                                    isDead = true;
                                    Console.WriteLine("No lives left! Game Over!");
                                }
                            }
                            else if (field[currentPositionX][currentPositionY] == '$')
                            {
                                livesCount++;
                                Console.WriteLine("Awesome! Lives left: {0}", livesCount);
                                field[currentPositionX][currentPositionY] = '.';
                            }
                            else if (field[currentPositionX][currentPositionY] == '.')
                            {
                                Console.WriteLine("Made a move!");
                            }

                            movesMadeCount++;
                        }

                        break;
                    case '<':
                        if (currentPositionY - 1 < 0 ||
                            field[currentPositionX][currentPositionY - 1] == ' ')
                        {
                            Console.WriteLine("Fell off a cliff! Game Over!");
                            movesMadeCount++;
                            isDead = true;
                        }
                        else if (field[currentPositionX][currentPositionY - 1] == '|' ||
                                 field[currentPositionX][currentPositionY - 1] == '_')
                        {
                            Console.WriteLine("Bumped a wall.");
                        }
                        else
                        {
                            currentPositionY -= 1;
                            if (field[currentPositionX][currentPositionY] == '#' ||
                                field[currentPositionX][currentPositionY] == '@' ||
                                field[currentPositionX][currentPositionY] == '*')
                            {
                                livesCount--;
                                Console.WriteLine("Ouch! That hurt! Lives left: {0}", livesCount);

                                if (livesCount == 0)
                                {
                                    isDead = true;
                                    Console.WriteLine("No lives left! Game Over!");
                                }
                            }
                            else if (field[currentPositionX][currentPositionY] == '$')
                            {
                                livesCount++;
                                Console.WriteLine("Awesome! Lives left: {0}", livesCount);
                                field[currentPositionX][currentPositionY] = '.';
                            }
                            else if (field[currentPositionX][currentPositionY] == '.')
                            {
                                Console.WriteLine("Made a move!");
                            }

                            movesMadeCount++;
                        }

                        break;

                    case '^':
                        if (currentPositionX - 1 < 0 ||
                            field[currentPositionX - 1].Length <= currentPositionY ||
                            field[currentPositionX - 1][currentPositionY] == ' ')
                        {
                            Console.WriteLine("Fell off a cliff! Game Over!");
                            movesMadeCount++;
                            isDead = true;
                        }
                        else if (field[currentPositionX - 1][currentPositionY] == '|'
                                    || field[currentPositionX - 1][currentPositionY] == '_')
                        {
                            Console.WriteLine("Bumped a wall.");
                        }
                        else
                        {
                            currentPositionX -= 1;
                            if (field[currentPositionX][currentPositionY] == '#' ||
                                field[currentPositionX][currentPositionY] == '@' ||
                                field[currentPositionX][currentPositionY] == '*')
                            {
                                livesCount--;
                                Console.WriteLine("Ouch! That hurt! Lives left: {0}", livesCount);

                                if (livesCount == 0)
                                {
                                    isDead = true;
                                    Console.WriteLine("No lives left! Game Over!");
                                }
                            }
                            else if (field[currentPositionX][currentPositionY] == '$')
                            {
                                livesCount++;
                                Console.WriteLine("Awesome! Lives left: {0}", livesCount);
                                field[currentPositionX][currentPositionY] = '.';
                            }
                            else if (field[currentPositionX][currentPositionY] == '.')
                            {
                                Console.WriteLine("Made a move!");
                            }

                            movesMadeCount++;
                        }

                        break;

                    case 'v':
                        if (currentPositionX + 1 >= field.Length ||
                            field[currentPositionX + 1].Length <= currentPositionY ||
                            field[currentPositionX + 1][currentPositionY] == ' ')
                        {
                            Console.WriteLine("Fell off a cliff! Game Over!");
                            movesMadeCount++;
                            isDead = true;
                        }
                        else if (field[currentPositionX + 1][currentPositionY] == '|' ||
                                 field[currentPositionX + 1][currentPositionY] == '_')
                        {
                            Console.WriteLine("Bumped a wall.");
                        }
                        else
                        {
                            currentPositionX += 1;
                            if (field[currentPositionX][currentPositionY] == '#' ||
                                field[currentPositionX][currentPositionY] == '@' ||
                                field[currentPositionX][currentPositionY] == '*')
                        {
                                livesCount--;
                                Console.WriteLine("Ouch! That hurt! Lives left: {0}", livesCount);
                                
                                if(livesCount == 0)
                                {
                                    isDead = true;
                                    Console.WriteLine("No lives left! Game Over!");
                                }
                            }
                            else if (field[currentPositionX][currentPositionY] == '$')
                            {
                                livesCount++;
                                Console.WriteLine("Awesome! Lives left: {0}", livesCount);
                                field[currentPositionX][currentPositionY] = '.';
                            }
                            else if (field[currentPositionX][currentPositionY] == '.')
                            {
                                Console.WriteLine("Made a move!");
                            }

                            movesMadeCount++;
                        }

                        break;
                }
            }

            Console.WriteLine("Total moves made: {0}", movesMadeCount);
        }
    }
}
