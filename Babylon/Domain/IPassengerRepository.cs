namespace Babylon.Domain
{
    public interface IPassengerRepository
    {
        void Save(Passenger aPassenger);
        Passenger FindPassenger(string idCardNo);
    }
}