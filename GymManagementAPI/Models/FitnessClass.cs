using System.ComponentModel.DataAnnotations;

namespace GymManagementAPI.Models
{
    public class FitnessClass
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Instructor { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string Category { get; set; } = string.Empty;

        public DateTime ScheduledDate { get; set; }

        public int DurationMinutes { get; set; }

        public int Capacity { get; set; }

        public ICollection<Booking>? Bookings { get; set; }
    }
}
