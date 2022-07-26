using BookingApi.Data;
using BookingApi.Models;
using Microsoft.AspNetCore.Mvc;
using BookingApi.Interfaces;

namespace BookingApi.Controllers;
[ApiController]
 [Route("api/[controller]")]
public class BookingController : ControllerBase
{

    private readonly BookingContext _bookingContext;
    private readonly IBookingService _bookingService;

    public BookingController(BookingContext bookingContext,IBookingService bookingService)
    {
        _bookingContext= bookingContext;
        _bookingService=bookingService;
    }

// POST: api/Booking
    [HttpPost]
    public async Task<ActionResult<Booking>> PostBooking(Booking booking)
    {
        try
        {
            await _bookingService.SaveBookingAsync(booking);; //simulation for the data base access
            Console.WriteLine(String.Format("EMAIL SENT TO admin@admin.com FOR CREATED BOOKING WITH ID {0} ", booking.Id ));
            return CreatedAtAction("PostBooking", new { id = booking.Id }, booking);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Internal server error:" + ex.Message);
        }
    }

}
