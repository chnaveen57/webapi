using System;

namespace CarPooling.Models
{
    public class BookingViewModel
    {
        public string ID { get; set; }
        public string UserID { get; set; }
        public string RentalOfferID { get; set; }
        public string StartingPoint { get; set; }
        public string EndingPoint { get; set; }
        public int SeatsNeeded { get; set; }
        public bool IsAccepted { get; set; }
        public bool IsRejected { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public decimal Cost { get; set; }
    }
}
