using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarPooling.Models
{
    public class RentalOffer
    {
        public string RentalOfferID { get; set; }
        public string StartingPoint { get; set; }
        public string EndingPoint { get; set; }
        public string ViaPoints { get; set; }
        public int SeatsAvailable { get; set; }
        public decimal MoneyRecieved { get; set; }
        public bool IsClosed { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public decimal OfferPrice { get; set; }
        public string UserID { get; set; }
        public User User { get; set; }
        public string VehicleID { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}



