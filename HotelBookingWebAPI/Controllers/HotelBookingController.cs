/*
using HotelBookingWebAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetHotelBooking : ControllerBase
    {
        private readonly BookingDBContext _context;
        public GetHotelBooking(BookingDBContext context)
        {
            _context = context;
        }

        // GET: api/HotelBooking
        [HttpGet]
        public ActionResult<IEnumerable<Booking>> GetBooking()
        {
            return _context.Bookings;
        }

        // GET: api/HotelBooking/5
        [HttpGet("{booking_id:int}")]
        public async Task<ActionResult<Booking>> GetById(int booking_id)
        {
            var hotelBooking = await _context.Bookings.FindAsync(booking_id);

            if (hotelBooking == null)
            {
                return NotFound();
            }

            return hotelBooking;
        }

        // PUT: api/HotelBooking/5
        [HttpPut("{booking_id}")]
        public async Task<IActionResult> Update(int id, Booking booking)
        {
            if (id != booking.BookingId)
            {
                return BadRequest();
            }

            _context.Entry(booking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!HotelBookingExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        private bool HotelBookingExists(int id)
        {
            throw new NotImplementedException();
        }

        // POST: api/HotelBooking
        [HttpPost]
        public async Task<ActionResult> Create(Booking booking)
        {
            await _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // DELETE: api/HotelBooking/5
        [HttpDelete("{booking_id:int}")]
        public async Task<IActionResult> Delete(int booking_id)
        {
            var hotelBooking = await _context.Bookings.FindAsync(booking_id);
            if (hotelBooking == null)
            {
                return NotFound();
            }

            _context.Bookings.Remove(hotelBooking);
            await _context.SaveChangesAsync();
            
            return Ok();
        }

       /* private bool HotelBookingExists(int booking_id)
        {
            return _context.Bookings.Any(e => e.Id == booking_id);
        }
       
    }
}
*/

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HotelBookingWebAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelBookingController : ControllerBase
    {
        private readonly BookingDBContext _dbContext;
        public HotelBookingController(BookingDBContext bookingDBContext)
        {
            _dbContext = bookingDBContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Booking>> GetBookings()
        {
            return _dbContext.Bookings;
        }

        [HttpGet("{booking_id:int}")]
        public async Task<ActionResult<Booking>> GetById(int booking_id)
        {
            
            var booking = await _dbContext.Bookings.FindAsync(booking_id);
            if (booking == null)
            {
                return NotFound();
            }
            else
            {
                return booking;
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(Booking booking)
        {
            await _dbContext.Bookings.AddAsync(booking);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        /*
        [HttpPut("{booking_id:int}")]
        public async Task<ActionResult> Update(Booking booking)
        {
            _dbContext.Bookings.Update(booking);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
        */
        // PUT: api/HotelBooking/5
        [HttpPut("{booking_id:int}")]
        public async Task<IActionResult> Update(int booking_id, [FromBody] Booking booking)
        {
            if (booking_id != booking.BookingId)
            {
                return BadRequest("The provided booking ID does not match the booking object.");
            }

            try
            {
                var existingBooking = await _dbContext.Bookings.FindAsync(booking_id);

                if (existingBooking == null)
                {
                    return NotFound("Booking not found.");
                }

                // Update the properties of the existing booking with the new values
                existingBooking.BookingId = booking.BookingId; // Replace with actual properties to update

                // Set the modified state for the existing booking
                _dbContext.Entry(existingBooking).State = EntityState.Modified;

                // Save changes to the database
                await _dbContext.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while updating the booking: " + ex.Message);
            }
        }



        [HttpDelete("{booking_id:int}")]
        public async Task<ActionResult> Delete(int booking_id)
        {
            var booking = await _dbContext.Bookings.FindAsync(booking_id);
            _dbContext.Bookings.Remove(booking);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }


    }
}
