using AutoMapper;
using CarPooling.Models;
using CarPooling.Services;
using CarpoolingDB;
using CarPoolingServices.IServices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarPoolingServices.Services
{
    public class RatingServices : IRatingServices
    {
        IRentalOfferServices rentalOfferRequest;
        IBookingServices bookingRequest;
        private readonly CarpoolingContext _context;
        private readonly IMapper _mapper;
        public RatingServices(IBookingServices bookingServices,IRentalOfferServices rentalOfferServices, CarpoolingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            bookingRequest = bookingServices;
            rentalOfferRequest = rentalOfferServices;
        }
        public List<RatingViewModel> GetAllRatings()
        {
            return _context.Ratings.Select(r => _mapper.Map<RatingViewModel>(r)).ToList<RatingViewModel>();
        }
        public bool AddRating(RatingViewModel rating)
        {
            try
            {
                _context.Ratings.Add(_mapper.Map<Rating>(rating));

                    _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public double GetBookingRating(string id)
        {
                var rating=_context.Ratings.Where(x=>x.BookingID==id).FirstOrDefault();
                if (rating == null)
                {
                    return 0;
                }
                else
                {
                    return rating.RideRating;
                }
        }
        public double GetRatingofRentalOffer(List<string> bookingIds)

        {
            double ratingValue = 0;
            foreach (string bookingId in bookingIds)
            {
                var rating = _context.Ratings.FirstOrDefault(x => x.BookingID == bookingId);
                if (rating != null)
                    ratingValue += rating.RideRating;
            }
            return ratingValue / bookingIds.Count;
        }
        public double GetUserRating(string userId)
        {
            double ratingValue = 0;
            List<string> offerIds = rentalOfferRequest.UserRentalOfferIds(userId);
            foreach (string offerId in offerIds)
            {
                List<string> bookingIds = bookingRequest.GetOfferBookingIds(offerId);
                if (bookingIds.Count != 0)
                    ratingValue += GetRatingofRentalOffer(bookingIds);
            }
            if (offerIds.Count != 0)
                return ratingValue / offerIds.Count;
            else
                return ratingValue;
        }
        public bool DeleteRatingById(string id)
        {
            try
            {
                var rating = _context.Ratings.Where(s => s.BookingID == id).FirstOrDefault();
                _context.Remove(rating);
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
