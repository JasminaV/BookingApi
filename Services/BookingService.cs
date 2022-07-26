using BookingApi.Data;
using BookingApi.Interfaces;
using BookingApi.Models;
//using Microsoft.EntityFrameworkCore;
using BookingApi.Helpers;


namespace BookingApi.Services;
public class BookingService : IBookingService
{
    private readonly BookingContext _bookingContext;
    public BookingService(BookingContext bookingContext)
    {
        _bookingContext = bookingContext;
    }

    public async Task<int> SaveBookingAsync(Booking booking)
    {
        if (CheckAvailability(booking))
        {
            _bookingContext.Bookings.Add(booking);
            // inserts data  in to BookedResourcesPerDate table
            foreach (DateTime day in HelperFunctions.EachDay(booking.DateFrom, booking.DateTo))
            {
                BookedResourcesPerDate? bookedResourcesPerDate = new BookedResourcesPerDate();
                bookedResourcesPerDate = _bookingContext.BookedResourcesPerDates.Where(x => x.Date == day.Date && x.ResourceId == booking.ResourceId).Select(o => new BookedResourcesPerDate { Id=o.Id, ResourceId = o.ResourceId, Date = o.Date, Quantity = o.Quantity }).FirstOrDefault();
                if (bookedResourcesPerDate == null)
                {
                    bookedResourcesPerDate = new BookedResourcesPerDate();
                    bookedResourcesPerDate.ResourceId = booking.ResourceId;
                    bookedResourcesPerDate.Date = day.Date;
                    bookedResourcesPerDate.Quantity = booking.BookedQuantity;
                    _bookingContext.BookedResourcesPerDates.Add(bookedResourcesPerDate);
                }
                else
                {
                    bookedResourcesPerDate.Quantity = bookedResourcesPerDate.Quantity + booking.BookedQuantity;
                    _bookingContext.BookedResourcesPerDates.Update(bookedResourcesPerDate);
                } 
            }
        }
        else
        {
             throw new ApplicationException("There is no available resources at this moment.");
        }
       return await  _bookingContext.SaveChangesAsync();
    }

    public bool CheckAvailability(Booking booking)
    {
        bool flag = true;
        var resource = _bookingContext.Resources.Find(booking.ResourceId);
        if (resource != null && booking.BookedQuantity>0)
        {
            foreach (DateTime day in HelperFunctions.EachDay(booking.DateFrom, booking.DateTo))
            {
                var bookedresource = _bookingContext.BookedResourcesPerDates.Where(x => x.ResourceId == booking.ResourceId && x.Date == day.Date).Select(x => new BookedResourcesPerDate() { Quantity = x.Quantity }).FirstOrDefault(); ;

                if (bookedresource != null)
                {
                    if ((resource.Quantity - bookedresource.Quantity) < booking.BookedQuantity)
                    {
                        flag = false;
                        break;
                    }
                }
                else
                {
                    flag=(resource.Quantity>booking.BookedQuantity) ? true:false;
                }
            }
        }
        else
        {
            flag=false;
        }
        return flag;
    }

}