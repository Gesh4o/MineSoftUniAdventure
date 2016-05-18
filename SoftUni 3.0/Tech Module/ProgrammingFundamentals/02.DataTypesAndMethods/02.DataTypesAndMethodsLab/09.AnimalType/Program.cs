namespace _09.AnimalType
{
    using System;

    public class Program
    {
        private const string Mammal = "mammal";
        private const string Reptile = "reptile";
        private const string Other = "unknown";

        public static void Main(string[] args)
        {
            string animalType = Console.ReadLine();

            switch (animalType)
            {
                case "dog":
                    Console.WriteLine(Mammal);
                    break;
                case "snake":
                case "tortoise":
                case "crocodile":
                    Console.WriteLine(Reptile);
                    break;
                default:
                    Console.WriteLine(Other);
                    break;
            }
        }
    }
}
