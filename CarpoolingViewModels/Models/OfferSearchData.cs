using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarPooling.Models
{
    public class OfferSearchData
    {
        public string startingPoint { get; set; }
        public string endingPoint { get; set; }
        public int seatsNeeded { get; set; }
        public string userId { get; set; }
        public DateTime date { get; set; }
        public string time { get; set; }
    }
}