using System;
using Babylon.Domain;
using Babylon.Infrastructure;

namespace BabylonTest.ResourceTest
{
    public class TestBase
    {
        protected readonly ITripRepository TripRepository;

        public TestBase()
        {
            var dbInitializer = new DbInitializer();
            dbInitializer.Dispose();
            TripRepository = dbInitializer.TripRepository;
        }

        protected Trip PrepareTripData(int leftTickets)
        {
            var startTime = new DateTime(2015, 12, 26, 10, 30, 0);
            var endTime = new DateTime(2015, 12, 27, 6, 30, 0);
            var trip = new Trip("Z162", "WuHan", "Beijing", startTime, endTime, leftTickets);
            TripRepository.Save(trip);
            return trip;
        }
    }

    public class DbInitializer : IDisposable
    {
        private readonly CollectionTripRepository _tripRepository = new CollectionTripRepository();

        public CollectionTripRepository TripRepository
        {
            get { return _tripRepository; }
        }

        public void Dispose()
        {
            _tripRepository.Dispose();
        }
    }
}