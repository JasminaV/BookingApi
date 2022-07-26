using BookingApi.Data;
using BookingApi.Interfaces;
using BookingApi.Models;
using Microsoft.EntityFrameworkCore;


namespace BookingApi.Services;
public class ResourceService : IResourceService
{
       private readonly BookingContext _bookingContext;
       public ResourceService(BookingContext bookingContext)
       {
          _bookingContext=bookingContext;
       }

        public async Task<IEnumerable<Resource>> GetAllResources()
        {
        return await _bookingContext.Resources
            .Select(resource => new Resource{
            Id = resource.Id,
            Name = resource.Name,
            Quantity=resource.Quantity
                                            })
        .ToListAsync();
       }

}