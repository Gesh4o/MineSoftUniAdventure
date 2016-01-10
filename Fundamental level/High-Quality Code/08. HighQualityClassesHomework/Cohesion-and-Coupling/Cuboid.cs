namespace CohesionAndCoupling
{
    using System;

    public class Cuboid
    {
        private double width;
        private double heigth;
        private double depth;

        public Cuboid(double width, double heigth, double depth)
        {
            this.Width = width;
            this.Height = heigth;
            this.Depth = depth;
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
                return this.heigth;
            }

            set
            {
                ValidateNumber(value, nameof(this.Height));

                this.heigth = value;
            }
        }

        public double Depth
        {
            get
            {
                return this.depth;
            }

            set
            {
                ValidateNumber(value, nameof(this.Depth));

                this.depth = value;
            }
        }

        public double GetVolume()
        {
            double volume = this.width * this.heigth * this.depth;
            return volume;
        }

        public double GetDiagonalXYZ()
        {
            double distance = DistanceCalculator.CalculateDistance3D(0, 0, 0, this.width, this.heigth, this.depth);
            return distance;
        }

        public double GetDiagonalXY()
        {
            double distance = DistanceCalculator.CalculateDistance2D(0, 0, this.width, this.heigth);
            return distance;
        }

        public double GetDiagonalXZ()
        {
            double distance = DistanceCalculator.CalculateDistance2D(0, 0, this.width, this.depth);
            return distance;
        }

        public double GetDiagonalYZ()
        {
            double distance = DistanceCalculator.CalculateDistance2D(0, 0, this.heigth, this.depth);
            return distance;
        }

        private static void ValidateNumber(double argumentValue, string argumentName)
        {
            if (argumentValue < 0)
            {
                throw  new ArgumentException(string.Format($"{argumentName} cannot be negative!"));
            }
        }
    }
}
