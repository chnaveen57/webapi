using CarPooling.Models;
using System;
using System.Collections.Generic;

namespace CarPoolingServices.IServices
{
    public interface IRentalOfferServices
    {
        List<RentalOfferViewModel> GetAllRentalOffers();
        RentalOfferViewModel GetRentalOffer(string offerId);
        bool UpdateRentalOffer(RentalOfferViewModel rentalOffer);
        bool AddRentalOffer(RentalOfferViewModel rentalOffer);
        bool RemoveRentalOffer(string rentalOfferId);
        List<RentalOfferViewModel> UserRentalOffers(string userId);
        List<string> UserRentalOfferIds(string userId);
        List<RentalOfferViewModel> GetAvailabeRentalOffers(string startingPoint, string endingPoint, int seatsNeeded, string userId,DateTime date,string time);
    }
}
