namespace _04.DistanceBetweenPoints
{
    using System;
    using System.Linq;

    public class PointsMain
    {
        public static void Main(string[] args)
        {
            int[] firstPointsCoordinates = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] secondPointsCoordinates = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Point firstPoint = new Point(firstPointsCoordinates[0], firstPointsCoordinates[1]);
            Point secondPoint = new Point(secondPointsCoordinates[0], secondPointsCoordinates[1]);

            Console.WriteLine("{0:F3}", Point.FindDistanceBetween(firstPoint, secondPoint));
        }
    }

    public class Point
    {
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public static double FindDistanceBetween(Point firstPoint, Point secondPoint)
        {
            double x = Math.Pow((firstPoint.X * 1.0) - secondPoint.X, 2);
            double y = Math.Pow((firstPoint.Y * 1.0) - secondPoint.Y, 2);

            double result = Math.Sqrt(x + y);

            return result;
        }
    }
}
