namespace _01.SoftUniAirline
{
    using System;
    using System.Linq;

    public class SoftUniAirLineMain
    {
        public static void Main(string[] args)
        {
            int flightsCount = int.Parse(Console.ReadLine());
            decimal[] flightsOverallIncome = new decimal[flightsCount];
            for (int flight = 0; flight < flightsCount; flight++)
            {
                int adultsCount = int.Parse(Console.ReadLine());
                decimal adultTicketCost = decimal.Parse(Console.ReadLine());

                int youngstersCount = int.Parse(Console.ReadLine());
                decimal youngestersTicketCount = decimal.Parse(Console.ReadLine());

                decimal flightPerHour = decimal.Parse(Console.ReadLine());
                decimal fuelConsumption = decimal.Parse(Console.ReadLine());
                decimal flightDuration = decimal.Parse(Console.ReadLine());

                decimal totalExpense = (adultsCount * adultTicketCost * 1.0M)
                                      + (youngstersCount * youngestersTicketCount * 1.0M)
                                      - (flightPerHour * fuelConsumption * flightDuration * 1.0M);

                if (totalExpense >= 0)
                {
                    Console.WriteLine($"You are ahead with {totalExpense :F3}$.");
                }
                else
                {
                    Console.WriteLine($"We've got to sell more tickets! We've lost {totalExpense:F3}$.");
                }

                flightsOverallIncome[flight] = totalExpense;
            }

            Console.WriteLine($"Overall profit -> {flightsOverallIncome.Sum():F3}$.\nAverage profit -> {flightsOverallIncome.Average():F3}$.");
        }
    }
}
