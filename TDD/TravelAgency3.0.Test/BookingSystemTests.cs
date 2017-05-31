using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;

namespace TravelAgency3._0.Test
{
    [TestFixture]
    class BookingSystemTests
    {
        private TourScheduleStub TourSchedule;
        private BookingSystem sut;
        private IMailSender mailSender;

        [SetUp]
        public void Setup()
        {
            TourSchedule = new TourScheduleStub();
            sut = new BookingSystem(TourSchedule);
            mailSender = Substitute.For<IMailSender>();
        }

        [Test]
        public void CanCreateBooking()
        {
            Tour tour = new Tour("Safari", new DateTime(2018, 01, 01), 1);
            TourSchedule.tours = new List<Tour> { tour };
            var toursOnDate = TourSchedule.GetToursFor(new DateTime(2018, 01, 01));

            Passanger passanger = new Passanger { FirstName = "Sven", LastName = "Svensson" };

            sut.CreateBooking("Safari", new DateTime(2018, 01, 01), passanger);
            List<Booking> bookings = sut.GetBookingFor(passanger);

            Assert.AreEqual(1, bookings.Count());
            Assert.AreEqual(tour, bookings.FirstOrDefault().Tour);
            Assert.AreEqual(passanger, bookings.FirstOrDefault().Passanger);

            Assert.AreEqual(1, toursOnDate.Count());
            Assert.AreEqual(new DateTime(2018, 01, 01), tour.TourDate);
        }

        [Test]
        public void ExceptionOnCreateBookingOnMissingTour()
        {

            Passanger passanger = new Passanger { FirstName = "Sven", LastName = "Svensson" };

            var e = Assert.Throws<MissingBookingException>(() => {
                sut.CreateBooking("Safari", new DateTime(2018, 01, 01), passanger);
            });

            List<Booking> bookings = sut.GetBookingFor(passanger);

            Assert.AreEqual(null, bookings);
        }

        [Test]
        public void ExeptionOnBookingToManyPassangersOnTour()
        {
            Tour tour = new Tour("Safari", new DateTime(2018, 01, 01), 1);
            TourSchedule.tours = new List<Tour> { tour };

            Passanger passanger1 = new Passanger { FirstName = "Sven", LastName = "Svensson" };
            Passanger passanger2 = new Passanger { FirstName = "Janne", LastName = "Jannesson" };

            sut.CreateBooking("Safari", new DateTime(2018, 01, 01), passanger1);

            var e = Assert.Throws<SeatsAllocationException>(() => {
                sut.CreateBooking("Safari", new DateTime(2018, 01, 01), passanger2);
            });

            Assert.AreEqual(0, sut.SeatsLeftOnTour(tour));
        }

        [Test]
        public void CanCancleBooking()
        {
            Tour tour = new Tour("Safari", new DateTime(2018, 01, 01), 1);
            TourSchedule.tours = new List<Tour> { tour };

            Passanger passanger = new Passanger { FirstName = "Sven", LastName = "Svensson" };

            sut.CreateBooking("Safari", new DateTime(2018, 01, 01), passanger);
            sut.CancelBooking("Safari", new DateTime(2018, 01, 01), passanger);

            List<Booking> bookings = sut.GetBookingFor(passanger);

            Assert.AreEqual(null, bookings);
            Assert.AreEqual(1, sut.SeatsLeftOnTour(tour));

        }


    }

    class TourScheduleStub : ITourSchedule
    {
        public List<Tour> tours { get; set; }
        public List<DateTime> requestedDateData { get; set; }

        public TourScheduleStub()
        {
            requestedDateData = new List<DateTime>();
        }

        public List<Tour> CreateTour(string tourName, DateTime tourDate, int numberOfSeats)
        {
            throw new NotImplementedException();
        }

        public List<Tour> GetToursFor(DateTime dateTime)
        {
            requestedDateData.Add(dateTime.Date);
            return tours;

        }
    }
}
