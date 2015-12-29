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
            SeatPool = new SeatPool(train.Seats);
        }

        public string Id { get; private set; }
        public Train Train { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        private SeatPool SeatPool { get; set; } 

        public int? AddPassenger(Passenger passenger)
        {
            if (LeftTickets() == 0)
            {
                return null;
            }

            passenger.AddTrip(this);
            return SeatPool.AssigneeFor(passenger.IdCardNo);
        }

        public int LeftTickets()
        {
            return SeatPool.FreeSeats();
        }
    }
}