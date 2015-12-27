using System;
using Babylon.Application;
using Babylon.Domain;
using Moq;
using Xunit;

namespace BabylonTest.ApplicationTest
{
    public class PassengerApplicationServiceFacts
    {
        [Theory]
        [InlineData(1)]
        [InlineData(0)]
        public void should_book_train_when_have_left_tickets_and_not_book_train_when_have_no_left_tickets(int leftTickets)
        {
            var expectedTrip = new Trip("Z162", "WuHan", "Beijing", DateTime.UtcNow, DateTime.UtcNow, leftTickets);
            var tripMocker = new Mock<ITripRepository>();
            tripMocker.Setup(repository => repository.FindTrip(expectedTrip.Id)).Returns(expectedTrip);
            var tripRepository = tripMocker.Object;

            var expectedPassenger = new Passenger("passenger id card no");
            var passengerMocker = new Mock<IPassengerRepository>();
            var passengerRepository = passengerMocker.Object;
            passengerMocker.Setup(repository => repository.OfCardNo(expectedPassenger.IdCardNo)).Returns(expectedPassenger);
            passengerMocker.Setup(repository => repository.Save(expectedPassenger));

            var passengerApplicationService = new PassengerApplicationService(tripRepository, passengerRepository);
            passengerApplicationService.BookTicket(expectedTrip.Id, expectedPassenger.IdCardNo);

            var times = leftTickets == 1 ? Times.Once() : Times.Never();
            passengerMocker.Verify(repository => repository.Save(expectedPassenger), times);
        }
    }
}