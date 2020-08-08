using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarPooling.Models
{
    public class Vehicle
    {
        public string VehicleID { get; set; }
        public string Model { get; set; }
        public string Number { get; set; }
        public int Capacity { get; set; }
        public string UserID { get; set; }
        public User User { get; set; }
        public ICollection<RentalOffer> RentalOffer { get; set; }
    }
}
