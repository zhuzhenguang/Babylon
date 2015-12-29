using System;
using Babylon.Domain;
using Xunit;

namespace BabylonTest.DomainTest
{
    public class PassengerFacts
    {
        [Fact]
        public void should_add_a_passenger_when_have_free_tickets()
        {
            var aTrain = PrepareTrain(1);
            var aTrip = new Trip(aTrain, DateTime.UtcNow, DateTime.UtcNow);
            var aPassenger = new Passenger("id card no");

            var seatNo = aTrip.AddPassenger(aPassenger);

            Assert.Equal(0, seatNo);
            Assert.True(aPassenger.HasTrip(aTrip));
            Assert.Equal(0, aTrip.FreeSeatsCount());
        }

        [Fact]
        public void should_not_add_the_passenger_when_have_no_free_tickets()
        {
            var aTrain = PrepareTrain(0);
            var aTrip = new Trip(aTrain, DateTime.UtcNow, DateTime.UtcNow);
            var aPassenger = new Passenger("id card no");

            var seatNo = aTrip.AddPassenger(aPassenger);

            Assert.Null(seatNo);
            Assert.False(aPassenger.HasTrip(aTrip));
        }

        private static Train PrepareTrain(int seats)
        {
            return new Train("Z162", "WuHan", "Beijing", seats);
        }
    }
}