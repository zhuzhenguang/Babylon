using System.Collections.Generic;
using Babylon.Domain;

namespace Babylon.Application
{
    public class TripStatisticsApplicationService
    {
        private readonly ITripRepository _tripRepository;

        public TripStatisticsApplicationService(ITripRepository tripRepository)
        {
            _tripRepository = tripRepository;
        }

        public IList<int> ReportFreeSeats(string tripId)
        {
            var trip = _tripRepository.FindTrip(tripId);
            Assert.NotNull(trip);

            if (trip.FreeSeatsCount() > 0)
            {
                return trip.FreeSeats();
            }
            return null;
        }

        public IDictionary<int, string> ReportBookedSeats(string tripId)
        {
            var trip = _tripRepository.FindTrip(tripId);
            Assert.NotNull(trip);

            if (trip.BookedSeatsCount() > 0)
            {
                return trip.BookedSeats();
            }
            return null;
        }
    }
}