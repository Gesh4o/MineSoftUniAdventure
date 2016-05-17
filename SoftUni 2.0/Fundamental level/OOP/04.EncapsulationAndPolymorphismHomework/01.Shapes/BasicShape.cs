namespace _01.Shapes
{
    using _01.Shapes.Interfaces;
    using System;

    public abstract class BasicShape : IShape
    {
        private double height;
        private double width;

        public BasicShape(double height, double width)
        {
            this.Height = height;
            this.Width = width;
        }

        public double Height
        {
            get { return this.height; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Height cannot be negative!");
                }

                this.height = value;
            }
        }

        public double Width
        {
            get { return this.width; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Height cannot be negative!");
                }

                this.width = value;
            }
        }

        public abstract double CalculateArea();

        public abstract double CalculatePerimeter();

    }
}
