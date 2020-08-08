using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarPooling.Models;
using CarpoolingDB;
using CarPoolingServices.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarPooling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserServices UserRequest;
        public UserController(IUserServices userServices)
        {
            UserRequest = userServices;
        }
        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(UserRequest.GetUsers());
        }
        [HttpGet("{id}")]
        public IActionResult GetUserById(string id)
        {
            return Ok(UserRequest.GetUserById(id));
        }
        [HttpGet("name/{userid}")]
        public IActionResult GetUserName(string userid)
        {
            return Ok(UserRequest.GetUserName(userid));
        }
        [HttpPut]
        public IActionResult UpdateUser(UserViewModel user)
        {
            bool IsBalanceUpdated;
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");
            else
                IsBalanceUpdated = UserRequest.UpdateUser(user);
            if (IsBalanceUpdated)
                return Ok();
            else
                return BadRequest("User is not UPdated");
        }
        [HttpPost]
        public IActionResult PostUser(UserViewModel user)
        {
            bool IsUserPosted = false;
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");
            else
            {
                IsUserPosted = UserRequest.AddUser(user);
            }
            if (IsUserPosted)
                return Ok();
            else
                return BadRequest("Unable to add User");
        }
    }
}