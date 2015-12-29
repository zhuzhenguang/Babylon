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
            return _trips.Single(trip => trip.Train.TrainNo == trainNo &&
                                         trip.Train.From == @from &&
                                         trip.Train.To == to &&
                                         trip.StartTime == startTime);
        }

        public Trip FindTrip(string tripId)
        {
            return _trips.SingleOrDefault(trip => trip.Id == tripId);
        }

        public void Save(Trip trip)
        {
            if (!TripExist(trip))
            {
                _trips.Add(trip);
            }
            else
            {
                var ids = _trips.Select(t => t.Id).ToList();
                var index = ids.IndexOf(trip.Id);
                _trips[index] = trip;
            }
        }

        private bool TripExist(Trip trip)
        {
            return FindTrip(trip.Id) != null;
        }
    }
}