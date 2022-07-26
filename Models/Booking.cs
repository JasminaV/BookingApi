using System;
using System.Collections.Generic;

namespace BookingApi.Models
{
    public partial class Booking
    {
        public long Id { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public long BookedQuantity { get; set; }
        public long ResourceId { get; set; }
    }
}
