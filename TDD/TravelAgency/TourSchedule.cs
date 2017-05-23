using System;
using System.Collections.Generic;
using System.Linq;

namespace TravelAgency
{
    public class TourSchedule
    {
        public List<Tour> tours { get; private set; }
        public TourSchedule()
        {
            tours = new List<Tour>();
        }

        public void CreateTour(string tourName, DateTime tourDate, int numberOfSeats)
        {

            var toursOnDate = tours.Where(x => x.TourDate == tourDate.Date).ToList();
            if (toursOnDate.Count() < 3)
            {
                tours.Add(new Tour(tourName, tourDate.Date, numberOfSeats));
            } else
            {
                throw new TourAllocationException();
            }
            
        }

        public List<Tour> GetToursFor(DateTime dateTime)
        {
            return tours.Where(x => x.TourDate == dateTime).ToList();
        }
    }
}