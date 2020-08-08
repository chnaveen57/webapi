using CarPooling.Models;
using System.Collections.Generic;

namespace CarPoolingServices.IServices
{
    public interface IRatingServices
    {
         bool AddRating(RatingViewModel rating);
         double GetRatingofRentalOffer(List<string> bookingIds);
         double GetUserRating(string userId);
        List<RatingViewModel> GetAllRatings();
        double GetBookingRating(string id);
        bool DeleteRatingById(string id);
    }
}
