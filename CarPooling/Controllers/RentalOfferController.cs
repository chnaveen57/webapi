using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarPooling.Models;
using CarPoolingServices.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarPooling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalOfferController : ControllerBase
    {
        IRentalOfferServices RentalRequest;
        public RentalOfferController(IRentalOfferServices rentalOfferServices)
        {
            RentalRequest = rentalOfferServices;
        }
        [HttpGet]
        public IActionResult GetAllRentalOffers()
        {
            return Ok(RentalRequest.GetAllRentalOffers());
        }
        [HttpGet("{OfferId}")]
        public IActionResult GetRentalOffer(string OfferId)
        {
            return Ok(RentalRequest.GetRentalOffer(OfferId));
        }
        [HttpPut]
        public IActionResult UpdateRentalOffer(RentalOfferViewModel rentalOffer)
        {
            bool IsRentalOfferUpdated;
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");
            else
                IsRentalOfferUpdated = RentalRequest.UpdateRentalOffer(rentalOffer);
            if (IsRentalOfferUpdated)
                return Ok();
            else
                return BadRequest("RentalOffer  is not UPdated");
        }
        [HttpPost]
        public IActionResult PostRentalOffer(RentalOfferViewModel RentalOffer)
        {
            bool IsRentalOfferAdded;
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");
            else
            {
                IsRentalOfferAdded = RentalRequest.AddRentalOffer(RentalOffer);
            }
            if (IsRentalOfferAdded)
                return Ok();
            else
                return BadRequest("Unable to add RentalOffer");
        }
        [HttpDelete("{OfferId}")]
        public IActionResult DeleteRentalOffer(string OfferId)
        {
            bool IsOfferDeleted = RentalRequest.RemoveRentalOffer(OfferId);
            if (IsOfferDeleted)
                return Ok();
            else
                return BadRequest("Unable to delete RentalOffer");
        }
        [HttpGet("user/{UserId}")]
        public IActionResult GetUserRentalOffer(string UserId)
        {
            return Ok(RentalRequest.UserRentalOffers(UserId));
        }
        [HttpGet("AvailableRentalOffer/{jsonData}")]
        public IActionResult GetAvailabeRentalOffers(string jsonData)
        {
            var data = JsonConvert.DeserializeObject<OfferSearchData>(jsonData);
            return Ok(RentalRequest.GetAvailabeRentalOffers(data.startingPoint, data.endingPoint, data.seatsNeeded, data.userId, data.date, data.time));
        }
    }
}