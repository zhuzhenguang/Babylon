using Babylon.Application;
using Babylon.Resource;
using Babylon.Resource.Request;
using Xunit;

namespace BabylonTest.ResourceTest
{
    public class TrainResourceFacts : TestBase
    {
        private readonly TripApplicationService _tripApplicationService;

        public TrainResourceFacts()
        {
            _tripApplicationService = new TripApplicationService(TripRepository);
        }

        [Fact]
        public void should_get_the_train_details_by_train_number()
        {
            var expectedTrip = PrepareTripData(1);
            var tripResource = new TripResource(_tripApplicationService);

            var trip = tripResource.GetByTrainNo(new TripQueryRequest
            {
                From = expectedTrip.From,
                To = expectedTrip.To,
                StartTime = expectedTrip.StartTime,
                TrainNo = expectedTrip.TrainNo
            });

            Assert.Equal(expectedTrip, trip);
        }
    }
}