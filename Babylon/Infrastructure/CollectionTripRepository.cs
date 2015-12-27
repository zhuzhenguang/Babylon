using System;
using System.Collections.ObjectModel;
using System.Linq;
using Babylon.Domain;

namespace Babylon.Infrastructure
{
    public class CollectionTripRepository : ITripRepository, IDisposable
    {
        private readonly Collection<Trip> _trips;

        public CollectionTripRepository()
        {
            _trips = new Collection<Trip>();
        }

        public void Dispose()
        {
            _trips.Clear();
        }

        public Trip FindTrip(string trainNo, string @from, string to, DateTime startTime)
        {
            return _trips.Single(trip => trip.TrainNo == trainNo &&
                                         trip.From == @from &&
                                         trip.To == to &&
                                         trip.StartTime == startTime);
        }

        public Trip FindTrip(string tripId)
        {
            return _trips.Single(trip => trip.Id == tripId);
        }

        public void Save(Trip trip)
        {
            _trips.Add(trip);
        }
    }
}