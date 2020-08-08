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
    public class RentalOfferServices : IRentalOfferServices
    {
        IVehicleServices vehicleRequest;
        IBookingServices bookingRequest;
        private readonly CarpoolingContext _context;
        private readonly IMapper _mapper;
        public RentalOfferServices(IVehicleServices vehicleServices,IBookingServices bookingServices, CarpoolingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            vehicleRequest = vehicleServices;
            bookingRequest = bookingServices;
        }
        public List<RentalOfferViewModel> GetAllRentalOffers()
        {
            return _context.RentalOffers.Select(r => _mapper.Map<RentalOfferViewModel>(r)).ToList<RentalOfferViewModel>();
        }
        public RentalOfferViewModel GetRentalOffer(string offerId)
        {
            return _mapper.Map<RentalOfferViewModel>(_context.RentalOffers.First(x => x.RentalOfferID == offerId));
        }
        public bool UpdateRentalOffer(RentalOfferViewModel rentalOffer)
        {
            try
            {
                    var existingRentalOffer = _context.RentalOffers.Where(r => r.RentalOfferID == rentalOffer.ID)
                                                        .FirstOrDefault<RentalOffer>();
                    if (existingRentalOffer != null)
                    {
                        existingRentalOffer.EndingPoint = rentalOffer.EndingPoint;
                        existingRentalOffer.IsClosed = rentalOffer.IsClosed;
                        existingRentalOffer.MoneyRecieved = rentalOffer.MoneyRecieved;
                        existingRentalOffer.SeatsAvailable = rentalOffer.SeatsAvailable;
                        existingRentalOffer.StartingPoint = rentalOffer.StartingPoint;
                        existingRentalOffer.Date = rentalOffer.Date;
                        existingRentalOffer.Time = rentalOffer.Time;
                        existingRentalOffer.UserID = rentalOffer.UserID;
                        existingRentalOffer.VehicleID = rentalOffer.VehicleID;
                        existingRentalOffer.OfferPrice = rentalOffer.OfferPrice;
                        existingRentalOffer.ViaPoints = rentalOffer.ViaPoints;
                        _context.SaveChanges();
                    }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool AddRentalOffer(RentalOfferViewModel rentalOffer)
        {
            try
            {
                _context.RentalOffers.Add(_mapper.Map<RentalOffer>(rentalOffer));
                    _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool RemoveRentalOffer(string rentalOfferId)
        {
            try
            {
                    var rentalOffer = _context.RentalOffers.Where(s => s.RentalOfferID == rentalOfferId).FirstOrDefault();
                _context.Remove(rentalOffer);
                    _context.SaveChanges();
                var IsSucess = bookingRequest.DeleteOfferRides(rentalOfferId);
                return IsSucess;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public List<RentalOfferViewModel> UserRentalOffers(string userId)
        {
            var rentalOffer = _context.RentalOffers.Where(x => x.UserID == userId).Select(x => _mapper.Map<RentalOfferViewModel>(x)).ToList<RentalOfferViewModel>();
            return rentalOffer;
        }

        public List<string> UserRentalOfferIds(string userId)
        {
            return _context.RentalOffers.Where(x => x.UserID == userId).Select(x => x.RentalOfferID).ToList<string>();
        }
        public List<RentalOfferViewModel> GetAvailabeRentalOffers(string startingPoint, string endingPoint, int seatsNeeded, string userId,DateTime date,string time)
        {
            List<RentalOfferViewModel> rentaloffers = new List<RentalOfferViewModel>();
            List<RentalOfferViewModel> rentalOffers = GetAllRentalOffers();
            foreach (RentalOfferViewModel offer in rentalOffers)
            {
                if (offer.UserID != userId)
                {
                    if (IsSuitableOffer(offer, startingPoint, endingPoint, seatsNeeded,date,time))
                    {
                        rentaloffers.Add(GetRentalOffer(offer.ID));
                    }
                }
            }
            return rentaloffers;
        }
        public bool IsSuitableOffer(RentalOfferViewModel offer, string startingPoint, string endingPoint, int seats,DateTime date,string time)
        {
            List<string> Route=new List<string>();
            if (seats > offer.SeatsAvailable)
                return false;
            else
            {
                Route.Add(offer.StartingPoint);
                Route.AddRange(offer.ViaPoints.Split(',').ToList<string>());
                Route.Add(offer.EndingPoint);
                int startIndex = Route.FindIndex(x => x == startingPoint);
                int endIndex = Route.FindIndex(x => x == endingPoint);
                if (startIndex < endIndex && offer.Time == time && offer.Date == date)
                     return true;
                else
                    return false;
            }
        }
    }
}
