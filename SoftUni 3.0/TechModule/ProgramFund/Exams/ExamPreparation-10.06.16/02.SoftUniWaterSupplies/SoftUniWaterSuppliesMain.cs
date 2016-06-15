namespace _02.SoftUniWaterSupplies
{
    using System;
    using System.Linq;

    public class SoftUniWaterSuppliesMain
    {
        public static void Main(string[] args)
        {
            decimal initialWaterSupply = int.Parse(Console.ReadLine());
            decimal waterSupply = initialWaterSupply;

            decimal[] bottlesPerPerson = Console.ReadLine()
                .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(decimal.Parse)
                .ToArray();

            int bottleCapacity = int.Parse(Console.ReadLine());

            bool isInitialWaterSupplyEven = initialWaterSupply % 2 == 0;
            bool isWaterEnough = true;
            int index = 0;
            decimal amountOfWaterNeeded = Math.Abs(bottlesPerPerson.Length * bottleCapacity - waterSupply);

            if (isInitialWaterSupplyEven)
            {
                while (index < bottlesPerPerson.Length)
                {
                    initialWaterSupply -= (bottleCapacity - bottlesPerPerson[index]);

                    if (initialWaterSupply < 0)
                    {
                        isWaterEnough = false;
                        bottlesPerPerson[index] += initialWaterSupply + bottleCapacity;

                        int amountOfBottles = bottlesPerPerson.Count(b => b < bottleCapacity);
                        int[] indexes = new int[amountOfBottles];
                        for (int i = 0; i < amountOfBottles; i++)
                        {
                            indexes[i] = index++;
                        }

                        PrintFalseResult(amountOfBottles, amountOfWaterNeeded, indexes);
                        break;

                    }

                    bottlesPerPerson[index] = bottleCapacity;
                    index++;
                }
            }
            else
            {
                index = bottlesPerPerson.Length - 1;
                while (index >= 0)
                {
                    initialWaterSupply -= (bottleCapacity - bottlesPerPerson[index]);

                    if (initialWaterSupply < 0)
                    {
                        isWaterEnough = false;

                        bottlesPerPerson[index] += initialWaterSupply + bottleCapacity;

                        int amountOfBottles = bottlesPerPerson.Count(b => b < bottleCapacity);

                        int[] indexes = new int[amountOfBottles];
                        for (int i = 0; i < amountOfBottles; i++)
                        {
                            indexes[i] = index--;
                        }


                        PrintFalseResult(amountOfBottles, amountOfWaterNeeded, indexes);

                        break;
                    }
                    bottlesPerPerson[index] = bottleCapacity;
                    index--;
                }
            }

            if (isWaterEnough)
            {
                Console.WriteLine("Enough water!");
                Console.WriteLine($"Water left: {initialWaterSupply}l.");
            }
        }

        private static void PrintFalseResult(int amountOfBottles, decimal amountOfWaterNeeded, int[] indexes)
        {
            Console.WriteLine("We need more water!");
            Console.WriteLine($"Bottles left: {amountOfBottles}");
            Console.WriteLine($"With indexes: {string.Join(", ", indexes)}");
            Console.WriteLine($"We need {amountOfWaterNeeded} more liters!");
        }
    }
}
