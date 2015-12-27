using System;

namespace Babylon.Domain
{
    public class Trip
    {
        public string Id { get; private set; }
        public string TrainNo { get; private set; }
        public string From { get; private set; }
        public string To { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public int LeftTickets { get; private set; }

        public Trip(string trainNo, string from, string to, DateTime startTime, DateTime endTime, int leftTickets)
        {
            Id = Guid.NewGuid().ToString();
            TrainNo = trainNo;
            From = @from;
            To = to;
            StartTime = startTime;
            EndTime = endTime;
            LeftTickets = leftTickets;
        }

        public bool AddPassenger(Passenger passenger)
        {
            if (LeftTickets <= 0)
            {
                return false;
            }

            passenger.AddTrip(this);
            return true;
        }
    }
}