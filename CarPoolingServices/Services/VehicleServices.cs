using AutoMapper;
using CarPooling.Models;
using CarpoolingDB;
using CarPoolingServices.IServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CarPoolingServices.Services
{
    public class VehicleServices:IVehicleServices
    {
        private readonly CarpoolingContext _context;
        private readonly IMapper _mapper;
        public VehicleServices(CarpoolingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<VehicleViewModel> GetAllCars()
        {
            return _context.Vehicles.Select(v => _mapper.Map<VehicleViewModel>(v)).ToList<VehicleViewModel>();
        }
        public List<VehicleViewModel> GetUserCars(string userId)
        {
            var userCars = _context.Vehicles.Where(x => x.UserID == userId).Select(x => _mapper.Map<VehicleViewModel>(x)).ToList<VehicleViewModel>();
            return userCars;
        }
        public bool AddVehicle(VehicleViewModel vehicle)
        {
            try
            {
                _context.Vehicles.Add(_mapper.Map<Vehicle>(vehicle));
                    _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public VehicleViewModel GetVehicleById(string vehicleId)
        {
            var car = _mapper.Map<VehicleViewModel>(_context.Vehicles.FirstOrDefault(x => x.VehicleID == vehicleId));
            return car;
        }
    }
}
