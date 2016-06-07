namespace _03.Circles
{
    using System;
    using System.Linq;

    public class CirclesMain
    {
        public static void Main(string[] args)
        {
            int[] firstCircleInfo = Console.ReadLine()
                   .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                   .Select(int.Parse)
                   .ToArray();
            Circle firstCircle = new Circle(firstCircleInfo[0], firstCircleInfo[1], firstCircleInfo[2]);

            int[] secondCircleInfo = Console.ReadLine()
                .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Circle secondCircle = new Circle(secondCircleInfo[0], secondCircleInfo[1], secondCircleInfo[2]);

            if (Circle.IsIntersecting(firstCircle, secondCircle))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }

    public class Circle
    {
        public Circle(int x, int y, int radius)
        {
            this.X = x;
            this.Y = y;
            this.Radius = radius;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public int Radius { get; set; }

        public static bool IsIntersecting(Circle firstCircle, Circle secondCircle)
        {
            int distanceBetweenCentersX = Math.Abs(firstCircle.X - secondCircle.X);
            int distanceBetweenCentersY = Math.Abs(firstCircle.Y - secondCircle.Y);

            int radiusSum = firstCircle.Radius + secondCircle.Radius;

            bool isIntersecting = radiusSum >= distanceBetweenCentersX && radiusSum >= distanceBetweenCentersY;

            return isIntersecting;
        }
    }
}
