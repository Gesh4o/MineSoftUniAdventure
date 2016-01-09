namespace Abstraction
{
    using System;

    public abstract class Figure
    {
        private double width;
        private double height;
        private double radius;

        protected Figure()
        {
        }

        public double Width
        {
            get
            {
                return this.width;
            }
            set
            {
                ValidateNumber(value, nameof(this.Width));

                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }
            set
            {
                ValidateNumber(value, nameof(this.Height));

                this.height = value;
            }
        }

        public double Radius
        {
            get
            {
                return this.radius;
            }
            set
            {
                ValidateNumber(value, nameof(this.Radius));

                this.radius = value;
            }
        }

        public abstract double CalculateSurface();

        public abstract double CalculatePerimeter();
          
        /// <summary>
        /// Checks if number is negative and throws exception.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="argName"></param>
        private static void ValidateNumber(double number, string argName)
        {
            if (number < 0)
            {
                throw new ArgumentException(string.Format($"{argName} cannot be negative!"));
            }
        }
    }
}
