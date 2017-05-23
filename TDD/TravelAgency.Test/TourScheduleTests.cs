using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency;

namespace TravelAgency.Test
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
            sut.CreateTour("New years day safari", new DateTime(2018, 1 ,1 , 10, 15, 0), 20);

            List<Tour> tours = sut.GetToursFor(new DateTime(2018, 1, 1));

            Assert.AreEqual(1, tours.Count());

        }

        [Test]
        public void GetToursForGivenDayOnly()
        {
            sut.CreateTour("Monkey safari", new DateTime(2017, 12, 1), 20);
            sut.CreateTour("Monkey safari", new DateTime(2017, 12, 2), 20);
            sut.CreateTour("Monkey safari", new DateTime(2017, 12, 2), 20);
            sut.CreateTour("Monkey safari", new DateTime(2017, 12, 4), 20);

            List<Tour> tours = sut.GetToursFor(new DateTime(2017, 12, 1));

            Assert.AreEqual(1, tours.Count());
        }

        [Test]
        public void BookingAllocationOverflow()
        {
            Assert.Throws<TourAllocationException>(() => {

                sut.CreateTour("Monkey safari", new DateTime(2017, 12, 1), 20);
                sut.CreateTour("Monkey safari", new DateTime(2017, 12, 1), 20);
                sut.CreateTour("Monkey safari", new DateTime(2017, 12, 1), 20);
                sut.CreateTour("Monkey safari", new DateTime(2017, 12, 1), 20);


            });
        }
    }
}