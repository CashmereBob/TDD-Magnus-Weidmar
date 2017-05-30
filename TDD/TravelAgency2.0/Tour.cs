using System;

namespace TravelAgency2._0
{
    public class Tour
    {
        private int numberOfSeats;
        private DateTime tourDate;
        private string tourName;

        public DateTime TourDate
        {
            get { return tourDate; }
            set { tourDate = value; }
        }

        public int NumberOfSeats
        {
            get { return numberOfSeats; }
            set { numberOfSeats = value; }
        }

        public string TourName
        {
            get { return tourName; }
            set { tourName = value; }
        }

        public Tour(string tourName, DateTime tourDate, int numberOfSeats)
        {
            this.tourName = tourName;
            this.tourDate = tourDate;
            this.numberOfSeats = numberOfSeats;
        }

        public static bool operator ==(Tour a, Tour b)
        {
            if (ReferenceEquals(a, null))
            {
                return ReferenceEquals(b, null);
            }

            if (ReferenceEquals(b, null))
            {
                return ReferenceEquals(a, null);
            }

            if (a.tourName == b.tourName && a.tourDate == b.tourDate && a.numberOfSeats == b.numberOfSeats)
            {
                return a.Equals(b);
            }
            else
            {
                return false;
            }


        }

        public static bool operator !=(Tour a, Tour b)
        {
            if (a == b)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}