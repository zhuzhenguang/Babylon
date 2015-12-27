using System;

namespace Babylon.Domain
{
    public interface ITripRepository
    {
        Trip FindTrip(string trainNo, string from, string to, DateTime startTime);
        Trip FindTrip(string tripId);
        void Save(Trip trip);
    }
}