namespace GymManagementAPI.DTOs
{
    public class BookingReadDto
    {
        public int Id { get; set; }

        public string UserName { get; set; } = string.Empty;

        public DateTime BookingDate { get; set; }
    }
}
