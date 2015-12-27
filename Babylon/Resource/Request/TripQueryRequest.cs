using System;

namespace Babylon.Resource.Request
{
    public class TripQueryRequest
    {
        public string TrainNo { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime StartTime { get; set; }
    }
}