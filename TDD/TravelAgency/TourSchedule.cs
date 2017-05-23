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
                int counter = 0;
                while (true)
                {
                    counter++;
                    var sugestedTime = tourDate.Date.AddDays(counter);
                    var toursOnSugestedTime = tours.Where(x => x.TourDate == sugestedTime).ToList();

                    if (toursOnSugestedTime.Count() < 3)
                    {
                        throw new TourAllocationException(sugestedTime);
                    }

                    if (counter >= 365)
                    {
                        throw new TourAllocationException(null);

                    }

                }


            }
            
        }

        public List<Tour> GetToursFor(DateTime dateTime)
        {
            return tours.Where(x => x.TourDate == dateTime).ToList();
        }
    }
}