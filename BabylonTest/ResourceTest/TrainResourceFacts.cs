using Babylon.Application;
using Babylon.Resource;
using Babylon.Resource.Request;
using Xunit;

namespace BabylonTest.ResourceTest
{
    public class TrainResourceFacts : TestBase
    {
        private readonly TripApplicationService _tripApplicationService;
        private readonly TripStatisticsApplicationService _tripStatisticsApplicationService;

        public TrainResourceFacts()
        {
            _tripApplicationService = new TripApplicationService(TripRepository);
            _tripStatisticsApplicationService = new TripStatisticsApplicationService(TripRepository);
        }

        [Fact]
        public void should_get_the_train_details_by_train_number()
        {
            var expectedTrip = PrepareTripData(1, "Z162", "WuHan", "Beijing");
            var tripResource = new TripResource(_tripApplicationService, _tripStatisticsApplicationService);

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