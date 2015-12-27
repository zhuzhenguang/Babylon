namespace Babylon.Domain
{
    public interface IPassengerRepository
    {
        void Save(Passenger newPassenger);
        Passenger OfCardNo(string idCardNo);
    }
}