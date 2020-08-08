using AutoMapper;
using CarPooling.Models;
using CarPooling.Services;
using CarpoolingDB;
using CarPoolingServices.IServices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarPoolingServices.Services
{
    public class WalletServices : IWalletServices
    {
        IUserServices userRequest;
        private readonly CarpoolingContext _context;
        private readonly IMapper _mapper;
        public WalletServices(IUserServices userServices, CarpoolingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            userRequest = userServices;
        }
        public List<WalletViewModel> GetWallets()
        {
            return _context.Wallets.Select(w => _mapper.Map<WalletViewModel>(w)).ToList<WalletViewModel>();
        }
        public bool UpdateBalance(WalletViewModel wallet)
        {
            try
            {
                var existingWallet = _context.Wallets.Where(w => w.User.UserID == wallet.ID)
                                                    .FirstOrDefault<Wallet>();
                if (existingWallet != null)
                {
                    existingWallet.balance += wallet.balance;
                    _context.SaveChanges();
                }
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
        public WalletViewModel GetUserWallet(string userId)
        {
            return _mapper.Map<WalletViewModel>(_context.Wallets.FirstOrDefault(x => x.UserID == userId));
        }
        public decimal GetBalance(string userId)
        {
            return GetUserWallet(userId).balance;
        }
        public bool AddWallet(WalletViewModel wallet)
        {
            User user = new User { UserID = wallet.ID };
            try
            {
                _context.Wallets.Add(_mapper.Map<Wallet>(wallet));
                _context.SaveChanges();
                return true;
        }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
