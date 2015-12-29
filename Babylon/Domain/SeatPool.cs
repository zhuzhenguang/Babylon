using System.Collections.Generic;
using System.Linq;

namespace Babylon.Domain
{
    public class SeatPool
    {
        private readonly IDictionary<int, string> _pool;

        public SeatPool(int seats)
        {
            _pool = new Dictionary<int, string>(seats);
            for (var i = 0; i < seats; i++)
            {
                _pool.Add(i, string.Empty);
            }
        }

        public int? AssigneeFor(string passengerId)
        {
            var seatNo = NextSeatNo();
            if (!seatNo.HasValue)
            {
                return null;
            }

            _pool[seatNo.Value] = passengerId;
            return seatNo.Value;
        }



        private int? NextSeatNo()
        {
            return _pool.FirstOrDefault(el => el.Value != string.Empty).Key;
        }

        public int FreeSeats()
        {
            return _pool.Count(p => p.Value == string.Empty);
        }
    }
}