using System;
using Babylon.Application;
using Babylon.Domain;
using Babylon.Resource.Request;

namespace Babylon.Resource
{
    public class TripResource
    {
        private readonly TripApplicationService _tripApplicationService;

        public TripResource(TripApplicationService tripApplicationService)
        {
            _tripApplicationService = tripApplicationService;
        }

        public void BookTicket(string tripId, string userIdCardNo)
        {
            throw new NotImplementedException();
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