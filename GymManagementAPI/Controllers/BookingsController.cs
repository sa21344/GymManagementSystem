using GymManagementAPI.DTOs;
using GymManagementAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _service;

        public BookingsController(IBookingService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingReadDto>>> GetAll()
        {
            var bookings = await _service.GetAllBookingsAsync();

            return Ok(bookings);
        }

        [Authorize(Roles = "Member,Admin")]
        [HttpPost]
        public async Task<ActionResult> Create(BookingCreateDto dto)
        {
            await _service.CreateBookingAsync(dto);

            return Ok("Booking created successfully.");
        }
    }
}
