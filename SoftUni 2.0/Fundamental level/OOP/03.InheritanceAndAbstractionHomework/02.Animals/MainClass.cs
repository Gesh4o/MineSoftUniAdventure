namespace _02.Animals
{
    using System;
    using System.Linq;

    public class MainClass
    {
        private static void Main()
        {
            Cat tom = new Cat("Tom", "male", 2);
            Dog spike = new Dog("Spike", "male", 3);
            Frog kermit = new Frog("Kermit", "male", 2);

            Tomcat tomjr = new Tomcat("Prinkles", 1);
            Kitten marge = new Kitten("Marge", 1);

            Dog lassy = new Dog("Lassy", "female", 2);
            Frog molly = new Frog("Molly", "female", 4);

            Animals[] animals = new Animals[7];

            animals[0] = tom;
            animals[1] = spike;
            animals[2] = kermit;
            animals[3] = tomjr;
            animals[4] = marge;
            animals[5] = lassy;
            animals[6] = molly;

            //Took this one from forums - source [borislavml] only difference is this is a separeted as a method.
            CalculateAndPrintAvarageAge(animals);
            
            // Optional(mine desicion)
            double catAvgAge = GetAvarageAges("Cat", animals);
            double dogAvgAge = GetAvarageAges("Dog", animals);
            double frogAvgAge = GetAvarageAges("Frog", animals);

            Console.WriteLine(catAvgAge);
            Console.WriteLine(dogAvgAge);
            Console.WriteLine(frogAvgAge);

        }

        private static void CalculateAndPrintAvarageAge(Animals[] animals)
        {
            var avarageAge =
                from animal in animals
                group animal by new { GroupName = animal.GetType().Name } into gr
                select new
                {
                    GroupName = gr.Key.GroupName,
                    avarageAge = gr.Average(animal => animal.Age)
                };

            foreach (var animal in avarageAge)
            {
                Console.WriteLine("Animal: {0}, Avarage age: {1}", animal.GroupName, animal.avarageAge);
            }
                
        }

        private static double GetAvarageAges(string animalClass, Animals[] animals)
        {
            double animalAvgAge = 0;
            int animalCount = 0;

            foreach (var animal in animals)
            {
                if (animal.GetType().BaseType.Name == animalClass || animal.GetType().Name == animalClass)
                {
                    animalAvgAge += animal.Age;
                    animalCount++;
                }
               
            }

            animalAvgAge /= (animalCount * 1.0);
            return animalAvgAge;
        }
    }
}
