namespace _05.ClosestPoints
{
    using System;
    using System.Linq;

    public class PointsMain
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Point[] points = new Point[n];

            for (int i = 0; i < n; i++)
            {
                int[] pointCoordinates = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                Point point = new Point(pointCoordinates[0], pointCoordinates[1]);
                points[i] = point;
            }

            double currentMinDistance = double.MaxValue;
            Point startingPoint = null;
            Point endingPoint = null;

            for (int i = 0; i < points.Length; i++)
            {
                for (int j = 0; j < points.Length; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    double currentDistance = Point.FindDistanceBetween(points[i], points[j]);
                    if (currentDistance < currentMinDistance)
                    {
                        currentMinDistance = currentDistance;
                        startingPoint = points[i];
                        endingPoint = points[j];
                    }
                }
            }

            Console.WriteLine($"{currentMinDistance:F3}");
            Console.WriteLine(startingPoint);
            Console.WriteLine(endingPoint);
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

        public override string ToString()
        {
            string stringView = $"({this.X}, {this.Y})";
            return stringView;
        }
    }
}
