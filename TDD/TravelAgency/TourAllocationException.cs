using System;

namespace TravelAgency
{
    public class TourAllocationException : Exception
    {
        public DateTime? SuggestedTime { get; private set; }

        public TourAllocationException(DateTime? sugestedTime = null, string message = null) : base(message)
        {
            this.SuggestedTime = sugestedTime;

        }
    }
}