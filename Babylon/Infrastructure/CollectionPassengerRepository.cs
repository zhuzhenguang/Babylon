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

        public void Save(Passenger newPassenger)
        {
            if (OfCardNo(newPassenger.IdCardNo) == null)
            {
                _passengers.Add(newPassenger);
            }
            else
            {
                var ids = _passengers.Select(p => p.IdCardNo).ToList();
                var index = ids.IndexOf(newPassenger.IdCardNo);
                _passengers[index] = newPassenger;
            }
        }

        public Passenger OfCardNo(string idCardNo)
        {
            return _passengers.SingleOrDefault(passenger => passenger.IdCardNo == idCardNo);
        }
    }
}