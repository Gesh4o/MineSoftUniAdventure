namespace _01.Shapes
{
    internal class Rhombus : BasicShape
    {
        //Note that here height and width are a bit different the in other figures.
        public Rhombus( double height, double width) :base(height, width)
        {

        }
        public override double CalculateArea()
        {
            return this.Height * this.Width;
        }

        public override double CalculatePerimeter()
        {
            return 4 * Width;
        }
    }
}
