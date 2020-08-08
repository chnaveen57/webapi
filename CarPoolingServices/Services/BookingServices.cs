using AutoMapper;
using CarPooling.Models;
using CarpoolingDB;
using CarPoolingServices.IServices;
using CarPoolingServices.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
namespace CarPooling.Services
{
    public class BookingServices : IBookingServices
    {
        private readonly CarpoolingContext _context;
        private readonly IMapper _mapper;
        public BookingServices(CarpoolingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<BookingViewModel> GetBookings()
        {
            return _context.Bookings.Select(b => _mapper.Map<BookingViewModel>(b)).ToList<BookingViewModel>();
        }
        public List<BookingViewModel> GetOfferBookings(string offerId)
        {
            var offerBookings = _context.Bookings.Where(x => x.RentalOfferID == offerId).Select(x => _mapper.Map<BookingViewModel>(x)).ToList<BookingViewModel>();
            return offerBookings;
        }
        public bool UpdateBooking(BookingViewModel booking)
        {
            try
            {
                    var existingBooking = _context.Bookings.Where(w => w.BookingID == booking.ID)
                                                        .FirstOrDefault<Booking>();
                    if (existingBooking != null)
                    {
                        existingBooking.Cost = booking.Cost;
                        existingBooking.EndingPoint = booking.EndingPoint;
                        existingBooking.IsAccepted = booking.IsAccepted;
                        existingBooking.RentalOfferID = booking.RentalOfferID;
                        existingBooking.SeatsNeeded = booking.SeatsNeeded;
                        existingBooking.StartingPoint = booking.StartingPoint;
                        existingBooking.UserID = booking.UserID;
                        existingBooking.Date = booking.Date;
                        existingBooking.Time = booking.Time;
                        existingBooking.IsRejected = booking.IsRejected;
                        _context.SaveChanges();
                    }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<string> GetOfferBookingIds(string offerId)
        {
            var offerBookingIds = _context.Bookings.Where(x => x.RentalOfferID == offerId).Select(x => x.BookingID).ToList<string>();
            return offerBookingIds;
        }
        public BookingViewModel BookingById(string bookingId)
        {
            return _mapper.Map<BookingViewModel>(_context.Bookings.FirstOrDefault(x => x.BookingID == bookingId));
            
        }
        public bool AddBooking(BookingViewModel booking)
        {
            try
            {
                _context.Bookings.Add(_mapper.Map<Booking>(booking));

                    _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public List<BookingViewModel> GetUserBookings(string userId)
        {
            return _context.Bookings.Where(x => x.UserID == userId).Select(x => _mapper.Map<BookingViewModel>(x)).ToList<BookingViewModel>();
            
        }
        public bool DeleteOfferRides(string offerId)
        {
            try
            {
                    var bookings = GetOfferBookings(offerId);
                    foreach (var bookingView in bookings)
                    {
                        var booking = _context.Bookings.Where(s => s.RentalOfferID == bookingView.RentalOfferID).FirstOrDefault();
                        _context.Remove(booking);
                        _context.SaveChanges();
                    }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool DeleteBookingById(string bookingId)
        {
            try
            {
                var booking = _context.Bookings.Where(s => s.BookingID == bookingId).FirstOrDefault();
                _context.Remove(booking);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

    }
}
