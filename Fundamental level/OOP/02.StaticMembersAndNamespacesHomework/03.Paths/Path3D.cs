namespace _03.Paths
{
    using System.Collections.Generic;

    public class Path3D
    {
        private static List<Point3D> sequence;

        public Path3D(params Point3D[] list)
        {
            sequence = new List<Point3D>();
            foreach (var item in list)
            {
                sequence.Add(item);
            }
        }

        public static IEnumerable<Point3D> Sequence
        {
            get { return sequence; }
        }

        public void AddToPath(Point3D point)
        {
            sequence.Add(point);
        }

        public override string ToString()
        {
            string result = string.Join("\n", sequence);
            return result;
        }
    }
}
