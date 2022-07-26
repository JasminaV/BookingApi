using System;
using System.Collections.Generic;

namespace BookingApi.Models
{
    public partial class Resource
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public long Quantity { get; set; }
    }
}
