using System;
using System.Collections.Generic;

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
            if (FreeSeatsCount() == 0)
            {
                return null;
            }

            passenger.AddTrip(this);
            var seatNo = SeatPool.AssignFor(passenger.IdCardNo);
            return seatNo;
        }

        public int FreeSeatsCount()
        {
            return SeatPool.FreeSeatsCount();
        }

        public IList<int> FreeSeats()
        {
            return SeatPool.FreeSeats();
        }

        public int BookedSeatsCount()
        {
            return SeatPool.BookedSeatsCount();
        }

        public IDictionary<int, string> BookedSeats()
        {
            return SeatPool.BookedSeats();
        }
    }
}