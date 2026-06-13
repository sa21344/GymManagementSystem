namespace GymManagementAPI.Models
{
    public class Booking
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public User? User { get; set; }

        public int FitnessClassId { get; set; }

        public FitnessClass? FitnessClass { get; set; }

        public DateTime BookingDate { get; set; } = DateTime.UtcNow;
    }
}
