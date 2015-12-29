using System.Collections.ObjectModel;
using System.Linq;
using Babylon.Domain;

namespace Babylon.Infrastructure
{
    public class CollectionPassengerRepository : IPassengerRepository
    {
        private readonly Collection<Passenger> _passengers;

        public CollectionPassengerRepository()
        {
            _passengers = new Collection<Passenger>();
        }

        public void Save(Passenger aPassenger)
        {
            if (!PassengerExist(aPassenger))
            {
                _passengers.Add(aPassenger);
            }
            else
            {
                var ids = _passengers.Select(p => p.IdCardNo).ToList();
                var index = ids.IndexOf(aPassenger.IdCardNo);
                _passengers[index] = aPassenger;
            }
        }

        private bool PassengerExist(Passenger newPassenger)
        {
            return FindPassenger(newPassenger.IdCardNo) != null;
        }

        public Passenger FindPassenger(string idCardNo)
        {
            return _passengers.SingleOrDefault(passenger => passenger.IdCardNo == idCardNo);
        }
    }
}