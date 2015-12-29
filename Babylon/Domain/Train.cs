namespace Babylon.Domain
{
    public class Train
    {
        public Train(string trainNo, string @from, string to, int seats)
        {
            TrainNo = trainNo;
            From = @from;
            To = to;
            Seats = seats;
        }

        public string TrainNo { get; private set; }
        public string From { get; private set; }
        public string To { get; private set; }
        public int Seats { get; private set; }
    }
}