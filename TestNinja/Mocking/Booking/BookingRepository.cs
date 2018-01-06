using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Mocking.Booking
{
    public class BookingRepository : IBookingRepository
    {
        private IUnitOfWork _unitOfWork;

        public BookingRepository(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public IQueryable<Booking> GetActiveBookings(int? excludedBookingId = null)
        {
            var bookings = _unitOfWork.Query<Booking>()
                .Where(b => b.Id != excludedBookingId && b.Status != "Cancelled");

            if (excludedBookingId.HasValue)
                bookings = bookings.Where(b => b.Id != excludedBookingId.Value);
            
            return bookings;
        }
    }
}
