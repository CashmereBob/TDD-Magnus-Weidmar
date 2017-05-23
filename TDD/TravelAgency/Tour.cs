using System;

namespace TravelAgency
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
    }
}