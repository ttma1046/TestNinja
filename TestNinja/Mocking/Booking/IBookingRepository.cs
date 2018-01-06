using System.Linq;

namespace TestNinja.Mocking.Booking
{
    public interface IBookingRepository
    {
        IQueryable<Booking> GetActiveBookings(int? excludedBookingId = default(int?));
    }
}