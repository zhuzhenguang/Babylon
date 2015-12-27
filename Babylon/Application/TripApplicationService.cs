using System;
using Babylon.Domain;

namespace Babylon.Application
{
    public class TripApplicationService
    {
        private readonly ITripRepository _tripRepository;

        public TripApplicationService(ITripRepository tripRepository)
        {
            _tripRepository = tripRepository;
        }

        public Trip FindTrip(string trainNo, string from, string to, DateTime startTime)
        {
            return _tripRepository.FindTrip(trainNo, from, to, startTime);
        }
    }
}