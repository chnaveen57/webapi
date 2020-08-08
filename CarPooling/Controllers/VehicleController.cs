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
    public class VehicleController : ControllerBase
    {
        IVehicleServices vehicleRequest;
        public VehicleController(IVehicleServices vehicleServices)
        {
            vehicleRequest = vehicleServices;
        }
        [HttpGet]
        public IActionResult GetCars()
        {
            return Ok(vehicleRequest.GetAllCars());
        }
        [HttpGet("{id}")]
        public IActionResult GetVehicleById(string id)
        {
            return Ok(vehicleRequest.GetVehicleById(id));
        }
        [HttpGet("user/{userID}")]
        public IActionResult GetUSerCars(string userID)
        {
            return Ok(vehicleRequest.GetUserCars(userID));
        }
        [HttpPost]
        public IActionResult PostVehicle(VehicleViewModel vehicle)
        {
            bool IsVehicleAdded;
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");
            else
            {
                IsVehicleAdded = vehicleRequest.AddVehicle(vehicle);
            }
            if (IsVehicleAdded)
                return Ok();
            else
                return BadRequest("Unable to add Vehicle");
        }
    }
}