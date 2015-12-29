using System;

namespace Babylon.Domain
{
    public class Trip
    {
        public Trip(Train train, DateTime startTime, DateTime endTime)
        {
            Id = Guid.NewGuid().ToString();
            Train = train;
            StartTime = startTime;
            EndTime = endTime;
            Passengers = 0;
        }

        public string Id { get; private set; }
        public Train Train { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        private int Passengers { get; set; }

        public bool AddPassenger(Passenger passenger)
        {
            if (LeftTickets() <= 0)
            {
                return false;
            }

            passenger.AddTrip(this);
            Passengers++;
            return true;
        }

        public int LeftTickets()
        {
            return Train.Seats - Passengers;
        }
    }
}