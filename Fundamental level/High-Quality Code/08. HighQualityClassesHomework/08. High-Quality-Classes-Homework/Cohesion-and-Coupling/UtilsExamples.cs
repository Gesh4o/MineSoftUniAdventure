namespace CohesionAndCoupling
{
    using System;

    public class UtilsExamples
    {
        public static void Main()
        {
            Console.WriteLine(StringUtilities.GetFileExtension("example"));
            Console.WriteLine(StringUtilities.GetFileExtension("example.pdf"));
            Console.WriteLine(StringUtilities.GetFileExtension("example.new.pdf"));

            Console.WriteLine(StringUtilities.GetFileNameWithoutExtension("example"));
            Console.WriteLine(StringUtilities.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(StringUtilities.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine("Distance in the 2D space = {0:f2}", DistanceCalculator.CalculateDistance2D(1, -2, 3, 4));
            Console.WriteLine("Distance in the 3D space = {0:f2}", DistanceCalculator.CalculateDistance3D(5, 2, -1, 3, -6, 4));

            Cuboid cube = new Cuboid(3, 4, 5);

            Console.WriteLine("Volume = {0:f2}", cube.GetVolume());
            Console.WriteLine("Diagonal XYZ = {0:f2}", cube.GetDiagonalXYZ());
            Console.WriteLine("Diagonal XY = {0:f2}", cube.GetDiagonalXY());
            Console.WriteLine("Diagonal XZ = {0:f2}", cube.GetDiagonalXZ());
            Console.WriteLine("Diagonal YZ = {0:f2}", cube.GetDiagonalYZ());
        }
    }
}
