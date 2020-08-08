using System.Collections.Generic;

namespace CarPooling.Models
{
    public class User
    {
        public string UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }
        public ICollection<RentalOffer> RentalOffers { get; set; }
        public ICollection<Booking> Bookings { get; set; }
        public ICollection<Wallet> Wallet { get; set; }
    }
}
