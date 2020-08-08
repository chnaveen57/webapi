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
    public class WalletController : ControllerBase
    {
        IWalletServices WalletRequest;
        public WalletController(IWalletServices walletServices)
        {
            WalletRequest = walletServices;
        }
        [HttpGet]
        public IActionResult GetWallets()
        {
            return Ok(WalletRequest.GetWallets());
        }
        [HttpGet("{id}")]
        public IActionResult GetWalletByUserID(string id)
        {
            return Ok(WalletRequest.GetUserWallet(id));
        }
        [HttpPost]
        public IActionResult PostWallet(WalletViewModel wallet)
        {
            bool IsWalletAdded;
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");
            else
            {
                IsWalletAdded = WalletRequest.AddWallet(wallet);
            }
            if (IsWalletAdded)
                return Ok();
            else
                return BadRequest("Unable to add Wallet");
        }
        [HttpPut]
        public IActionResult UpdateBalance(WalletViewModel wallet)
        {
            bool IsBalanceUpdated;
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");
            else
                IsBalanceUpdated = WalletRequest.UpdateBalance(wallet);
            if (IsBalanceUpdated)
                return Ok();
            else
                return BadRequest("Balance is not UPdated");
        }
        [HttpGet("balance/{UserId}")]
        public IActionResult GetUserBalance(string UserId)
        {
            return Ok(WalletRequest.GetBalance(UserId));
        }
    }
}