using System;
using Babylon.Application;
using Babylon.Domain;
using Moq;
using Xunit;

namespace BabylonTest.ApplicationTest
{
    public class TripApplicationServiceFacts
    {
        [Fact]
        public void should_query_train_details_by_train_no()
        {
            var expectedTrip = new Trip("Z162", "WuHan", "Beijing", DateTime.UtcNow, DateTime.UtcNow, 1);
            var mocker = new Mock<ITripRepository>();
            mocker
                .Setup(repository => repository.FindTrip("Z162", "WuHan", "Beijing", expectedTrip.StartTime))
                .Returns(expectedTrip);
            var tripRepository = mocker.Object;
            var tripApplicationService = new TripApplicationService(tripRepository);

            var train = tripApplicationService.FindTrip("Z162", "WuHan", "Beijing", expectedTrip.StartTime);

            Assert.Equal(expectedTrip, train);
        }
    }
}