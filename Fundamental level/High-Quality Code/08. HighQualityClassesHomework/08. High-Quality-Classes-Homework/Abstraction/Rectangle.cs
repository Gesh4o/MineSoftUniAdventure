namespace Abstraction
{
    public class Rectangle : Figure
    {
        public Rectangle(double width, double height)

        {
            this.Width = width;
            this.Height = height;
        }

        public override double CalculatePerimeter()
        {
            double perimeter = 2 * (this.Width + this.Height);
            return perimeter;
        }

        public override double CalculateSurface()
        {
            double surface = this.Width * this.Height;
            return surface;
        }
    }
}
