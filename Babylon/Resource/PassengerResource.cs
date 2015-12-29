using Babylon.Application;
using Babylon.Domain;

namespace Babylon.Resource
{
    public class PassengerResource
    {
        private readonly PassengerApplicationService _passengerApplicationService;

        public PassengerResource(PassengerApplicationService passengerApplicationService)
        {
            _passengerApplicationService = passengerApplicationService;
        }

        public void BookTicket(string tripId, string userCardIdNo)
        {
            _passengerApplicationService.BookTicket(tripId, userCardIdNo);
        }

        public Passenger FindPassenger(string userCardIdNo)
        {
            return _passengerApplicationService.FindByCardId(userCardIdNo);
        }
    }
}