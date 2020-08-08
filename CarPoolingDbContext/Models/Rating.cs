using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarPooling.Models
{
    public class Rating
    {
        public int RatingID { get; set; }
        public double RideRating { get; set; }
        public string Comment { get; set; }
        public string BookingID { get; set; }
        public Booking Booking { get; set; }
    }
}
