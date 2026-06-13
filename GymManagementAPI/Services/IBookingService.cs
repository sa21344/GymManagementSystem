using GymManagementAPI.DTOs;

namespace GymManagementAPI.Services
{
    public interface IBookingService
    {
        Task CreateBookingAsync(BookingCreateDto dto);

        Task<IEnumerable<BookingReadDto>> GetAllBookingsAsync();
    }
}
