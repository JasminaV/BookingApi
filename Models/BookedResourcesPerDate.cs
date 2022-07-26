using System;
using System.Collections.Generic;

namespace BookingApi.Models
{
    public partial class BookedResourcesPerDate
    {
        public long Id { get; set; }
        public long ResourceId { get; set; }
        public DateTime Date { get; set; }
        public long Quantity { get; set; }
    }
}
