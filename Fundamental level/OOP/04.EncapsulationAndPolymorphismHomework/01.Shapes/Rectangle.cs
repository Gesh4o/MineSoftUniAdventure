namespace _01.Shapes
{
    public class Rectangle : BasicShape
    {
        public Rectangle(double height, double width) : base(height, width)
        {

        }
        public override double CalculateArea()
        {
            return Height * Width;
        }

        public override double CalculatePerimeter()
        {
            return 2 * (Height + Width);
        }
    }
}
