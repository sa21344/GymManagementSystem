using GymManagementAPI.Models;

namespace GymManagementAPI.Repositories
{
    public interface IBookingRepository
    {
        Task<IEnumerable<Booking>> GetAllAsync();

        Task CreateAsync(Booking booking);

        Task<bool> ExistsAsync(int userId, int fitnessClassId);
    }
}
