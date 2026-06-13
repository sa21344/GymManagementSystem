namespace GymManagementAPI.DTOs
{
    public class FitnessClassReadDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Instructor { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;

        public DateTime ScheduledDate { get; set; }

        public int DurationMinutes { get; set; }

        public int Capacity { get; set; }

        public int AvailableSpots { get; set; }
    }
}
