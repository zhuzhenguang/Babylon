using System.Collections.Generic;

namespace Babylon.Domain
{
    public class Passenger
    {
        private readonly IList<string> _tripIds;

        public Passenger(string idCardNo)
        {
            IdCardNo = idCardNo;
            _tripIds = new List<string>();
        }

        public bool HasTrip(Trip aTrip)
        {
            return _tripIds.Contains(aTrip.Id);
        }

        public void AddTrip(Trip aTrip)
        {
            _tripIds.Add(aTrip.Id);
        }

        public string IdCardNo { get; private set; }
    }
}