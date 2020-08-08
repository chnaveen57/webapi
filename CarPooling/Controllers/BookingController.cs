using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarPooling.Models;
using CarPoolingServices.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarPooling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        IBookingServices bookingRequest;
        public BookingController(IBookingServices bookingServices)
        {
            bookingRequest = bookingServices;
        }
        [HttpGet]
        public IActionResult GetAllBookings()
        {
            return Ok(bookingRequest.GetBookings());
        }
        [HttpGet("{bookingId}")]
        public IActionResult GetBookingById(string bookingId)
        {
            return Ok(bookingRequest.BookingById(bookingId));
        }
        [HttpGet("user/{userID}")]
        public IActionResult GetUserBookings(string userID)
        {
            return Ok(bookingRequest.GetUserBookings(userID));
        }
        [HttpGet("BookingsByOffer/{OfferID}")]
        public IActionResult GetOfferBookings(string OfferID)
        {
            return Ok(bookingRequest.GetOfferBookings(OfferID));
        }

        [HttpPut]
        public IActionResult UpdateBooking(BookingViewModel booking)
        {
            bool IsBookingUpdated;
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");
            else
                IsBookingUpdated = bookingRequest.UpdateBooking(booking);
            if (IsBookingUpdated)
                return Ok();
            else
                return BadRequest("Booking  is not UPdated");
        }

        [HttpGet("OfferBookingIds/{OfferID}")]
        public IActionResult GetOfferBookingIds(string OfferId)
        {
            return Ok(bookingRequest.GetOfferBookingIds(OfferId));
        }
        [HttpPost]
        public IActionResult PostBooking(BookingViewModel booking)
        {
            bool IsBookingAdded;
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");
            else
            {
                IsBookingAdded = bookingRequest.AddBooking(booking);
            }
            if (IsBookingAdded)
                return Ok();
            else
                return BadRequest("Unable to add Booking");
        }
        [HttpDelete("OfferBookings/{offerID}")]
        public IActionResult DeleteOfferRides(string offerID)
        {
            bool IsRidesDeleted = bookingRequest.DeleteOfferRides(offerID);
            if (IsRidesDeleted)
                return Ok();
            else
                return BadRequest("Unable to delete rides");
        }
        [HttpDelete("{bookingID}")]
        public IActionResult DeleteBooing(string bookingID)
        {
            bool IsRideDeleted = bookingRequest.DeleteBookingById(bookingID);
            if (IsRideDeleted)
                return Ok();
            else
                return BadRequest("Unable to delete Booking");
        }
    }
}