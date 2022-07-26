using BookingApi.Models;

namespace BookingApi.Interfaces;
public interface IBookingService
{   
   Task<int> SaveBookingAsync(Booking booking);
   bool CheckAvailability(Booking booking);
}