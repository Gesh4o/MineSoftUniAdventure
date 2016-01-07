namespace _03.Paths
{
    public class MainClass
    {
        private static void Main(string[] args)
        {
            Point3D firstPoint = new Point3D(0, 0, 2);
            Point3D secondPoint = new Point3D(7, 1, -3);
            Point3D thirdPoint = new Point3D(4, 2, 3);

            Path3D sequence = new Path3D(firstPoint, secondPoint);
            sequence.AddToPath(thirdPoint);
            Storage.SavePath(sequence);
            Storage.ReadPath();
            
        }
    }
}
