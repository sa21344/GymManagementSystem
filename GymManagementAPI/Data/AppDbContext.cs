using Microsoft.EntityFrameworkCore;
using GymManagementAPI.Models;

namespace GymManagementAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<FitnessClass> FitnessClasses { get; set; }

        public DbSet<Booking> Bookings { get; set; }
    }
}