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

        public int? BookTicket(string tripId, string passengerIdCarNo)
        {
            var trip = _tripRepository.FindTrip(tripId);
            var passenger = _passengerRepository.FindPassenger(passengerIdCarNo);

            var seatNo = trip.AddPassenger(passenger);
            if (seatNo.HasValue)
            {
                _tripRepository.Save(trip);
                _passengerRepository.Save(passenger);    
            }
            return seatNo;
        }

        public Passenger FindByCardId(string userCardIdNo)
        {
            return _passengerRepository.FindPassenger(userCardIdNo);
        }
    }
}