using System;
using System.Collections.Generic;
using System.Linq;

namespace TravelAgency3._0
{


    public class TourSchedule : ITourSchedule
    {
        public List<Tour> tours { get; private set; }
        public TourSchedule()
        {
            tours = new List<Tour>();
        }

        public List<Tour> CreateTour(string tourName, DateTime tourDate, int numberOfSeats)
        {
            if (numberOfSeats <= 0)
            {
                throw new TourAllocationException(null, "Invalid number of seats");

            }


            var toursOnDate = tours.Where(x => x.TourDate == tourDate.Date).ToList();

            if (toursOnDate.Count() > 0)
            {
                var tourWithSameName = toursOnDate.FirstOrDefault(x => x.TourName == tourName);

                if (tourWithSameName != null)
                {
                    throw new TourAllocationException(null, "Tour with that name already exists on the same date");
                }
            }

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
                        throw new TourAllocationException(sugestedTime, "Date was fully booked");
                    }

                    if (counter >= 365)
                    {
                        throw new TourAllocationException(null, "No awailable dates this season");

                    }

                }


            }

            return tours.Where(x => x.TourDate == tourDate.Date).ToList();

        }

        public List<Tour> GetToursFor(DateTime dateTime)
        {
            var toursOnDate = tours.Where(x => x.TourDate == dateTime).ToList();

            if(toursOnDate.Count() < 1)
            {
                throw new TourAllocationException(null, "No bookings on this date");
            }

            return toursOnDate;
        }
    }
}