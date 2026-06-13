using GymManagementAPI.Data;
using GymManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GymManagementAPI.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly AppDbContext _context;

        public BookingRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Booking>> GetAllAsync()
        {
            return await _context.Bookings
                .Include(b => b.User)
                .Include(b => b.FitnessClass)
                .ToListAsync();
        }

        public async Task CreateAsync(Booking booking)
        {
            await _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(
            int userId,
            int fitnessClassId)
        {
            return await _context.Bookings.AnyAsync(
                b => b.UserId == userId &&
                     b.FitnessClassId == fitnessClassId);
        }
    }
}
