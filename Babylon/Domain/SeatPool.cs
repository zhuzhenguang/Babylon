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

        public int? AssignFor(string passengerId)
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

        public int FreeSeatsCount()
        {
            return _pool.Count(p => p.Value == string.Empty);
        }

        public IList<int> FreeSeats()
        {
            return _pool.Where(v => v.Value == string.Empty).Select(v => v.Key).ToList();
        }

        public int BookedSeatsCount()
        {
            return _pool.Count(p => p.Value != string.Empty);
        }

        public IDictionary<int, string> BookedSeats()
        {
            return _pool.Where(v => v.Value != string.Empty).ToDictionary(v => v.Key, v => v.Value);
        }
    }
}