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
            var expectedTrip = PrepareTripData(1, "Z162", "WuHan", "Beijing");
            var tripResource = new TripResource(_tripApplicationService);

            var trip = tripResource.GetByTrainNo(new TripQueryRequest
            {
                From = "WuHan",
                To = "Beijing",
                StartTime = expectedTrip.StartTime,
                TrainNo = "Z162"
            });

            Assert.Equal(expectedTrip, trip);
        }
    }
}