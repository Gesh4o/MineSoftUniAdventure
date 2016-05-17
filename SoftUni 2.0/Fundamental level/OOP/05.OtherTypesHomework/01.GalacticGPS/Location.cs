namespace _01.GalacticGPS
{
    using System;

    public struct Location
    {
        private double latitude;
        private double longtitude;
        private Planet planet;

        public Location(double latitude, double longtitude, Planet givenPlanet) : this()
        {
            this.Latitude = latitude;
            this.Longtitude = longtitude;
            this.planet = givenPlanet;
        }

        public double Latitude
        {
            get
            {
                return this.latitude;
            }

            set
            {
                const double UpperBound = 90;
                const double BottomBound = -90;
                if (!CheckLegitimacy(UpperBound, BottomBound, value))
                {
                    throw new ArgumentOutOfRangeException(string.Format("The latitude must be in range [{1} , {2}]",
                        BottomBound,
                        UpperBound));
                }

                this.latitude = value;
            }
        }

        public double Longtitude
        {
            get
            {
                return this.longtitude;
            }

            set
            {
                const double UpperBound = 180;
                const double BottomBound = -180;
                if (!CheckLegitimacy(UpperBound, BottomBound, value))
                {
                    throw new ArgumentOutOfRangeException(string.Format("The longtitude must be in range [{1} , {2}]",
                        BottomBound,
                        UpperBound));
                }

                this.longtitude = value;
            }
        }

        public override string ToString()
        {
            string result = string.Format("{0}, {1} - {2}", this.latitude, this.longtitude, this.planet);

            return result;
        }

        private static bool CheckLegitimacy(double upperBound, double bottomBound, double currentValue)
        {
            if (currentValue < bottomBound || currentValue > upperBound)
            {
                return false;
            }

            return true;
        }
    }
}
