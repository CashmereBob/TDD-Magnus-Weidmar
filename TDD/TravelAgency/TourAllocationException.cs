using System;

namespace TravelAgency
{
    public class TourAllocationException : Exception
    {
        public DateTime? SuggestedTime { get; private set; }

        public TourAllocationException(DateTime? sugestedTime)
        {
            this.SuggestedTime = sugestedTime;
        
        }
    }
}