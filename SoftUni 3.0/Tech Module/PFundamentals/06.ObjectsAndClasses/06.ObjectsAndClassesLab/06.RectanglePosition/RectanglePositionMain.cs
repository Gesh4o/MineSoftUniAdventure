namespace _06.RectanglePosition
{
    using System;
    using System.Linq;

    public class RectanglePositionMain
    {
        public static void Main(string[] args)
        {
            Rectangle firstRectangle = ReadRectangle();
            Rectangle secondRectangle = ReadRectangle();

            bool isInside = firstRectangle.IsInside(secondRectangle);

            if (isInside)
            {
                Console.WriteLine("Inside");
            }
            else
            {
                Console.WriteLine("Not inside");
            }
        }

        private static Rectangle ReadRectangle()
        {
            int[] rectanglePos = Console.ReadLine()
                .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            return new Rectangle(rectanglePos[0], rectanglePos[1], rectanglePos[2], rectanglePos[3]);
        }
    }

    public class Rectangle
    {
        public Rectangle(int topX, int topY, int width, int height)
        {
            this.TopX = topX;
            this.TopY = topY;
            this.Width = width;
            this.Height = height;
        }   

        public int TopX { get; }

        public int TopY { get; }

        public int Width { get; }

        public int Height { get; }

        public bool IsInside(Rectangle secondRectangle)
        {
            bool isTopInside = this.TopX >= secondRectangle.TopX && this.TopY <= secondRectangle.TopY;
            bool isRectangleInside = this.TopX + this.Width <= secondRectangle.TopX + secondRectangle.Width
                                     && this.TopY + this.Height <= secondRectangle.TopY + secondRectangle.Height;
            return isTopInside && isRectangleInside;
        }
    }
}
