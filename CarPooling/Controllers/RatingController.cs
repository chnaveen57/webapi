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
    public class RatingController : ControllerBase
    {
        IRatingServices ratingRequest;
        public RatingController(IRatingServices ratingServices)
        {
            ratingRequest = ratingServices;
        }
        [HttpGet]
        public IActionResult GetAllRatings()
        {
            return Ok(ratingRequest.GetAllRatings());
        }
        [HttpPost]
        public IActionResult PostRating(RatingViewModel rating)
        {
            bool IsRatingAdded;
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");
            else
            {
                IsRatingAdded = ratingRequest.AddRating(rating);
            }
            if (IsRatingAdded)
                return Ok();
            else
                return BadRequest("Unable to add Rating");
        }
        [HttpGet("{id}")]
        public IActionResult GetBookingRating(string id)
        {
            return Ok(ratingRequest.GetBookingRating(id));
        }
        [HttpGet("user/{UserId}")]
        public IActionResult GetUserRating(string UserId)
        {
            return Ok(ratingRequest.GetUserRating(UserId));
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteRating(string id)
        {
            bool IsRideDeleted = ratingRequest.DeleteRatingById(id);
            if (IsRideDeleted)
                return Ok();
            else
                return BadRequest("Unable to delete Booking");
        }
    }
}