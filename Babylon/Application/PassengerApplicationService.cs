using Babylon.Domain;

namespace Babylon.Application
{
    public class PassengerApplicationService
    {
        private readonly ITripRepository _tripRepository;
        private readonly IPassengerRepository _passengerRepository;

        public PassengerApplicationService(ITripRepository tripRepository, IPassengerRepository passengerRepository)
        {
            _tripRepository = tripRepository;
            _passengerRepository = passengerRepository;
        }

        public void BookTicket(string tripId, string passengerIdCarNo)
        {
            var trip = _tripRepository.FindTrip(tripId);
            var passenger = _passengerRepository.OfCardNo(passengerIdCarNo);
            
            if (trip.AddPassenger(passenger))
            {
                _passengerRepository.Save(passenger);    
            }
        }

        public Passenger FindByCardId(string userCardIdNo)
        {
            return _passengerRepository.OfCardNo(userCardIdNo);
        }
    }
}