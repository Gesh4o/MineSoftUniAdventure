namespace _13.Tour
{
    using System;
    using System.Linq;

    public class TourMain
    {
        public static void Main(string[] args)
        {
            int dimension = int.Parse(Console.ReadLine());
            var graph = InitializeGraph(dimension);

            var distance = GetDistance(graph);

            Console.WriteLine(distance);
        }

        private static int GetDistance(int[,] graph)
        {
            int[] pathInfo =
                Console.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int distance = 0;
            int currentCity = 0;

            foreach (int city in pathInfo)
            {
                distance += graph[currentCity, city];
                currentCity = city;
            }

            return distance;
        }

        private static int[,] InitializeGraph(int dimension)
        {
            int[,] graph = new int[dimension, dimension];

            for (int row = 0; row < graph.GetLength(0); row++)
            {
                int[] currentRow =
                    Console.ReadLine()
                        .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

                for (int col = 0; col < graph.GetLength(1); col++)
                {
                    graph[row, col] = currentRow[col];
                }
            }

            return graph;
        }
    }
}
