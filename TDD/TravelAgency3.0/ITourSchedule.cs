using System;
using System.Collections.Generic;

namespace TravelAgency3._0
{
    public interface ITourSchedule
    {
        List<Tour> tours { get; }

        List<Tour> CreateTour(string tourName, DateTime tourDate, int numberOfSeats);
        List<Tour> GetToursFor(DateTime dateTime);
    }
}