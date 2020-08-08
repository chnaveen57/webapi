using AutoMapper;
using CarPooling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPooling
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<User, UserViewModel>().ForMember(dest => dest.ID, act => act.MapFrom(src => src.UserID)).ReverseMap();
            CreateMap<Vehicle, VehicleViewModel>().ForMember(dest => dest.ID, act => act.MapFrom(src => src.VehicleID)).ReverseMap();
            CreateMap<Wallet, WalletViewModel>().ForMember(dest => dest.ID, act => act.MapFrom(src => src.UserID)).ReverseMap();
            CreateMap<Booking, BookingViewModel>().ForMember(dest => dest.ID, act => act.MapFrom(src => src.BookingID)).ReverseMap();
            CreateMap<RentalOffer, RentalOfferViewModel>().ForMember(dest => dest.ID, act => act.MapFrom(src => src.RentalOfferID)).ReverseMap();
            CreateMap<Rating, RatingViewModel>().ReverseMap();
        }
    }
}
