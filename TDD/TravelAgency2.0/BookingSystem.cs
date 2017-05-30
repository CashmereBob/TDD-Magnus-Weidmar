using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency2._0
{
    public class BookingSystem
    {
        private ITourSchedule tourSchedule;
        public List<Booking> Bookings { get; set; }

        public BookingSystem(ITourSchedule tourSchedule)
        {
            this.tourSchedule = tourSchedule;
            Bookings = new List<Booking>();
        }

        public void CreateBooking(string v, DateTime dateTime, Passanger passanger)
        {
            try
            {
                var tour = tourSchedule.GetToursFor(dateTime).FirstOrDefault(x => x.TourName == v);

                if (SeatsLeftOnTour(tour) <= 0)
                {
                    throw new SeatsAllocationException();
                }

                Bookings.Add(new Booking { Tour = tour, Passanger = passanger });
            }
            catch (SeatsAllocationException)
            {
                throw new SeatsAllocationException();
            }
            catch
            {
                throw new MissingBookingException();
            }
           
        }

        public List<Booking> GetBookingFor(Passanger passanger)
        {
            var bookings = Bookings.Where(x => x.Passanger == passanger).ToList();

            if (bookings.Count() == 0)
            {
                return null;
            }

            return bookings;
        }

        public int SeatsLeftOnTour(Tour tour)
        {
            List<Booking> tourBookings = Bookings.Where(x => x.Tour == tour).ToList();

            return tour.NumberOfSeats - tourBookings.Count();
            

        }

        public void CancelBooking(string v, DateTime dateTime, Passanger passanger)
        {
            try
            {
                var tour = tourSchedule.GetToursFor(dateTime).FirstOrDefault(x => x.TourName == v);
                var booking = Bookings.FirstOrDefault(x => x.Passanger == passanger && x.Tour == tour);


                Bookings.Remove(booking);
            }
            catch
            {
                throw new MissingBookingException();
            }
        }
    }
}
