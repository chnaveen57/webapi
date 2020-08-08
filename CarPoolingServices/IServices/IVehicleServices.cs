using CarPooling.Models;
using System.Collections.Generic;

namespace CarPoolingServices.IServices
{
    public interface IVehicleServices
    {
        List<VehicleViewModel> GetAllCars();
        List<VehicleViewModel> GetUserCars(string userId);
        bool AddVehicle(VehicleViewModel vehicle);
        VehicleViewModel GetVehicleById(string vehicleId);
    }
}
