using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarPooling.Models
{
    public class Wallet
    {
        public int WalletID { get; set; }
        public decimal balance { get; set; }
        public string UserID { get; set; }
        public User User { get; set; }
    }
}
