namespace _02.LaptopShop
{
    using System;

    public class LaptopShop
    {
        private static void Main()
        {
            Laptop firstLaptop = new Laptop("Toshiba", 444.3M);

            Battery firstBatery = new Battery("Lion",5);

            Laptop secondLaptop = new Laptop("Lenovo Yoga 2 Pro", "Lenovo", "Intel Core i5-4210U (2-core, 1.70 - 2.70 GHz, 3MB cache)"
                ,"8 GB", "Intel HD Graphics 4400", "128GB SSD", "13.3\"(33.78 cm) – 3200 x 1800(QHD +), IPS sensor display",firstBatery, 2259.00M);

            Laptop thirdLaptop = new Laptop("Lenovo Yoga 2 Pro", "Lenovo", "Intel Core i5-4210U (2-core, 1.70 - 2.70 GHz, 3MB cache)"
                , "8 GB", "Intel HD Graphics 4400", "128GB SSD", "13.3\"(33.78 cm) – 3200 x 1800(QHD +), IPS sensor display", 2259.00M);

            Console.WriteLine(firstLaptop);
            Console.WriteLine(secondLaptop);
            Console.WriteLine(thirdLaptop);
        }
    }
}