using System;
using Babylon.Domain;
using Xunit;

namespace BabylonTest.DomainTest
{
    public class PassengerFacts
    {
        [Fact]
        public void should_add_a_passenger_when_have_left_tickets()
        {
            var aTrip = new Trip("Z162", "WuHan", "Beijing", DateTime.UtcNow, DateTime.UtcNow, 1);
            var aPassenger = new Passenger("id card no");

            aTrip.AddPassenger(aPassenger);

            Assert.True(aPassenger.HasTrip(aTrip));
        }

        [Fact]
        public void should_not_add_the_passenger_when_have_no_left_tickets()
        {
            var aTrip = new Trip("Z162", "WuHan", "Beijing", DateTime.UtcNow, DateTime.UtcNow, 0);
            var aPassenger = new Passenger("id card no");

            aTrip.AddPassenger(aPassenger);

            Assert.False(aPassenger.HasTrip(aTrip));
        }
    }
}