using Babylon.Application;
using Babylon.Domain;
using Babylon.Infrastructure;
using Babylon.Resource;
using Xunit;

namespace BabylonTest.ResourceTest
{
    public class PassengerResourceFacts : TestBase
    {
        private readonly PassengerApplicationService _passengerApplicationService;
        private readonly IPassengerRepository _passengerRepository;

        public PassengerResourceFacts()
        {
            _passengerRepository = new CollectionPassengerRepository();
            _passengerApplicationService = new PassengerApplicationService(
                TripRepository,
                _passengerRepository);
        }

        [Fact]
        public void should_book_tickets_when_have_left_tickets()
        {
            var expectedTrip = PrepareTripData(1);
            var expectedPassenger = PreparePassengerData();
            var passengerResource = new PassengerResource(_passengerApplicationService);

            passengerResource.BookTicket(expectedTrip.Id, expectedPassenger.IdCardNo);

            var passenger = passengerResource.OfCardId(expectedPassenger.IdCardNo);
            Assert.True(passenger.HasTrip(expectedTrip));
        }

        [Fact]
        public void should_not_book_tickets_when_have_no_left_tickets()
        {
            var expectedTrip = PrepareTripData(0);
            var expectedPassenger = PreparePassengerData();
            var passengerResource = new PassengerResource(_passengerApplicationService);

            passengerResource.BookTicket(expectedTrip.Id, expectedPassenger.IdCardNo);

            var passenger = passengerResource.OfCardId(expectedPassenger.IdCardNo);
            Assert.False(passenger.HasTrip(expectedTrip));

        }

        private Passenger PreparePassengerData()
        {
            var newPassenger = new Passenger("user card id no");
            _passengerRepository.Save(newPassenger);
            return newPassenger;
        }
    }
}