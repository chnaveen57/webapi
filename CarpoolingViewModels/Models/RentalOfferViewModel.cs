using System;
using System.Collections.Generic;

namespace CarPooling.Models
{
    public class RentalOfferViewModel
    {
        public string ID { get; set; }
        public string UserID { get; set; }
        public string VehicleID { get; set; }
        public string StartingPoint { get; set; }
        public string EndingPoint { get; set; }
        public string ViaPoints { get; set; }
        public int SeatsAvailable { get; set; }
        public decimal MoneyRecieved { get; set; }
        public bool IsClosed { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public decimal OfferPrice { get; set; }
    }
}
