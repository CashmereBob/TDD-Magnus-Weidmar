using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency3._0;

namespace TravelAgency2._0.Test
{
    [TestFixture]
    public class TourScheduleTests
    {
        private TourSchedule sut;

        [SetUp]
        public void Setup()
        {
            sut = new TourSchedule();
        }

        [Test]
        public void CanCreateNewTour()
        {
            sut.CreateTour("Monkey safari", new DateTime(2017, 12, 30), 20);

            List<Tour> tours = sut.GetToursFor(new DateTime(2017, 12, 30));

            Assert.AreEqual(1, tours.Count());
        }

        [Test]
        public void ToursAreScheduledByDateOnly()
        {
            sut.CreateTour("New years day safari", new DateTime(2018, 1, 1, 10, 15, 0), 20);

            List<Tour> tours = sut.GetToursFor(new DateTime(2018, 1, 1));

            Assert.AreEqual(1, tours.Count());

        }

        [Test]
        public void GetToursForGivenDayOnly()
        {
            sut.CreateTour("Monkey safari1", new DateTime(2017, 12, 1), 20);
            sut.CreateTour("Monkey safari2", new DateTime(2017, 12, 2), 20);
            sut.CreateTour("Monkey safari3", new DateTime(2017, 12, 2), 20);
            sut.CreateTour("Monkey safari4", new DateTime(2017, 12, 4), 20);

            List<Tour> tours = sut.GetToursFor(new DateTime(2017, 12, 1));

            Assert.AreEqual(1, tours.Count());
        }

        [Test]
        public void BookingAllocationOverflow()
        {
            sut.CreateTour("Monkey safari1", new DateTime(2017, 12, 1), 20);
            sut.CreateTour("Monkey safari2", new DateTime(2017, 12, 1), 20);
            sut.CreateTour("Monkey safari3", new DateTime(2017, 12, 1), 20);

            var e = Assert.Throws<TourAllocationException>(() =>
            {
                sut.CreateTour("Monkey safari4", new DateTime(2017, 12, 1), 20);
            });

            Assert.AreEqual(new DateTime(2017, 12, 2), e.SuggestedTime);
            Assert.AreEqual("Date was fully booked", e.Message);
        }

        [Test]
        public void BookingToursOnSameDayWithTheSameName()
        {
            sut.CreateTour("Monkey safari", new DateTime(2017, 12, 1), 20);

            var e = Assert.Throws<TourAllocationException>(() =>
            {
                sut.CreateTour("Monkey safari", new DateTime(2017, 12, 1), 20);
            });

            Assert.AreEqual("Tour with that name already exists on the same date", e.Message);

        }

        [Test]
        public void CreateTourWithInvalidNumberOfSeets()
        {
            var e = Assert.Throws<TourAllocationException>(() => {

                sut.CreateTour("Monkey safari", new DateTime(2017, 12, 1), 0);

            });

            Assert.AreEqual("Invalid number of seats", e.Message);
        }

        [Test]
        public void GetToursOnUnbookedDay()
        {

            var e = Assert.Throws<TourAllocationException>(() => {
                var tours = sut.GetToursFor(DateTime.Now.Date);
            });

            Assert.AreEqual("No bookings on this date", e.Message);
        }

        [Test]
        public void GetToursOnDateAfterCreatingTour()
        {
            List<Tour> tours = new List<Tour>();
            tours = sut.CreateTour("Monkey safari1", new DateTime(2017, 12, 1), 20);

            Assert.AreEqual(1, tours.Count());

            tours = sut.CreateTour("Monkey safari2", new DateTime(2017, 12, 1), 20);

            Assert.AreEqual(2, tours.Count());

        }
    }
}