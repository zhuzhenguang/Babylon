using System.Linq;
using Babylon.Application;
using Babylon.Domain;
using Babylon.Resource.Request;

namespace Babylon.Resource
{
    public class TripResource
    {
        private readonly TripApplicationService _tripApplicationService;
        private readonly TripStatisticsApplicationService _tripStatisticsApplicationService;

        public TripResource(TripApplicationService tripApplicationService, TripStatisticsApplicationService tripStatisticsApplicationService)
        {
            _tripApplicationService = tripApplicationService;
            _tripStatisticsApplicationService = tripStatisticsApplicationService;
        }

        public string ReportFreeSeats(string tripId)
        {
            return string.Join(", ", _tripStatisticsApplicationService.ReportFreeSeats(tripId));
        }

        public string ReportBookedSeats(string tripId)
        {
            var bookedSeats = _tripStatisticsApplicationService.ReportBookedSeats(tripId);
            var bookedSeatsString = bookedSeats.ToList().Select(v => v.Key + "-" + v.Value);
            return string.Join(", ", bookedSeatsString);
        }

        public Trip GetByTrainNo(TripQueryRequest queryRequest)
        {
            return _tripApplicationService.FindTrip(
                queryRequest.TrainNo, 
                queryRequest.From, 
                queryRequest.To, 
                queryRequest.StartTime);
        }
    }
}