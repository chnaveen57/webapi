
using CarPooling.Models;
using System.Collections.Generic;

namespace CarPoolingServices.IServices
{
    public interface IBookingServices
    {
        List<BookingViewModel> GetBookings();
        List<BookingViewModel> GetOfferBookings(string offerId);
        bool UpdateBooking(BookingViewModel booking);
        List<string> GetOfferBookingIds(string offerId);
        BookingViewModel BookingById(string bookingId);
        bool AddBooking(BookingViewModel booking);
        List<BookingViewModel> GetUserBookings(string userId);
        bool DeleteOfferRides(string offerId);
        bool DeleteBookingById(string bookingId);
    }
}
