using System.Linq;

namespace TestNinja.Mocking.Booking
{
    public static class BookingHelper
    {
        public static string OverlappingBookingsExist(Booking booking, IBookingRepository bookingRepository)
        {
            if (booking.Status == "Cancelled")
                return string.Empty;

            var bookings = bookingRepository.GetActiveBookings(booking.Id);
            
            /*
            var overlappingBooking =
                bookings.FirstOrDefault(
                    b =>
                        booking.ArrivalDate >= b.ArrivalDate
                        && booking.ArrivalDate < b.DepartureDate
                        || booking.DepartureDate > b.ArrivalDate
                        && booking.DepartureDate <= b.DepartureDate
                        || booking.ArrivalDate < b.ArrivalDate
                        && booking.DepartureDate > b.DepartureDate);
            */
            
            var overlappingBooking =
                bookings.FirstOrDefault(
                    b => booking.ArrivalDate < b.DepartureDate &&  
                    booking.DepartureDate > b.ArrivalDate);
            
            return overlappingBooking == null ? string.Empty : overlappingBooking.Reference;
        }
    }
}