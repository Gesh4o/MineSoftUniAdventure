namespace _02.DistanceCalc
{
    using System;

    static class DistanceCalculator
    {
       public static double DistanceCalculate(Point3D firstPoint, Point3D secondPoint)
        {
            double xDiff = Math.Pow((firstPoint.X - secondPoint.X), 2);
            double yDiff = Math.Pow((firstPoint.Y - secondPoint.Y), 2);
            double zDiff = Math.Pow((firstPoint.Z - secondPoint.Z), 2);
            double result = Math.Sqrt((xDiff + yDiff + zDiff));
            return result;
        }
    }
}
