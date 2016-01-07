namespace _02.DistanceCalc
{
    using System;

    class MainClass
    {
        private static void Main(string[] args)
        {
            Point3D a = new Point3D(-7, -4, 3);
            Point3D b = new Point3D(17, 6, 2.5);

            double distanceBetweenAAndB = DistanceCalculator.DistanceCalculate(a, b);
            Console.WriteLine(distanceBetweenAAndB);

            // http://www.calculatorsoup.com/calculators/geometry-solids/distance-two-points.php - distance checker's source
        }
    }
}
