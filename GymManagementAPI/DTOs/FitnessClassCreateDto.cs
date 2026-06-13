namespace GymManagementAPI.DTOs
{
    public class FitnessClassCreateDto
    {
        public string Name { get; set; } = string.Empty;

        public string Instructor { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;

        public DateTime ScheduledDate { get; set; }

        public int DurationMinutes { get; set; }

        public int Capacity { get; set; }
    }
}
