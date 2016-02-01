namespace VehicleParkSystem.Infrastructure
{
    using System;

    public class Layout
    {
        private int occupiedPlacesInSector;

        private int sectorsCount;

        public Layout(int numberOfSectors, int placesPerSector)
        {
            if (numberOfSectors <= 0)
            {
                throw new DivideByZeroException("The number of sectors must be positive.");
            }

            this.sectorsCount = numberOfSectors;
            if (placesPerSector <= 0)
            {
                throw new DivideByZeroException("The number of places per sector must be positive.");
            }

            this.occupiedPlacesInSector = placesPerSector;
        }

        public int OccupiedPlacesInSector
        {
            get
            {
                return this.occupiedPlacesInSector;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The number of places per sector must be positive");
                }

                this.occupiedPlacesInSector = value;
            }
        }

        public int SectorsCount
        {
            get
            {
                return this.sectorsCount;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The number of sectors must be positive");
                }

                this.sectorsCount = value;
            }
        }
    }
}
