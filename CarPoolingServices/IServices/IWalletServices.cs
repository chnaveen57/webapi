using CarPooling.Models;
using System.Collections.Generic;

namespace CarPoolingServices.IServices
{
    public interface IWalletServices
    {
         List<WalletViewModel> GetWallets();
         bool UpdateBalance(WalletViewModel wallet);
        WalletViewModel GetUserWallet(string userId);
         decimal GetBalance(string userId);
        bool AddWallet(WalletViewModel wallet);
    }
}
