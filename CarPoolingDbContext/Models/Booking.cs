using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarPooling.Models
{
    public class Booking
    {
        public string BookingID { get; set; }
        public string RentalOfferID { get; set; }
        public string StartingPoint { get; set; }
        public string EndingPoint { get; set; }
        public int SeatsNeeded { get; set; }
        public bool IsAccepted { get; set; }
        public decimal Cost { get; set; }
        public DateTime Date { get; set; }
        public bool IsRejected { get; set; }
        public string Time { get; set; }
        public string UserID { get; set; }
        public User User { get; set; }
        public ICollection<Rating> Rating { get; set; }
    }
}
