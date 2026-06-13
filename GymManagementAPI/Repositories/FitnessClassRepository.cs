using GymManagementAPI.Data;
using GymManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GymManagementAPI.Repositories
{
    public class FitnessClassRepository : IFitnessClassRepository
    {
        private readonly AppDbContext _context;

        public FitnessClassRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FitnessClass>> GetAllAsync()
        {
            return await _context.FitnessClasses
                .Include(f => f.Bookings)
                .ToListAsync();
        }

        public async Task<FitnessClass?> GetByIdAsync(int id)
        {
            return await _context.FitnessClasses
                .Include(f => f.Bookings)
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task CreateAsync(FitnessClass fitnessClass)
        {
            await _context.FitnessClasses.AddAsync(fitnessClass);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(FitnessClass fitnessClass)
        {
            _context.FitnessClasses.Update(fitnessClass);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(FitnessClass fitnessClass)
        {
            _context.FitnessClasses.Remove(fitnessClass);
            await _context.SaveChangesAsync();
        }
    }
}