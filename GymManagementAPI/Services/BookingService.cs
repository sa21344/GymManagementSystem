using AutoMapper;
using GymManagementAPI.DTOs;
using GymManagementAPI.Models;
using GymManagementAPI.Repositories;

namespace GymManagementAPI.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IFitnessClassRepository _fitnessClassRepository;
        private readonly IMapper _mapper;

        public BookingService(
            IBookingRepository bookingRepository,
            IFitnessClassRepository fitnessClassRepository,
            IMapper mapper)
        {
            _bookingRepository = bookingRepository;
            _fitnessClassRepository = fitnessClassRepository;
            _mapper = mapper;
        }

        public async Task CreateBookingAsync(BookingCreateDto dto)
        {
            var fitnessClass =
                await _fitnessClassRepository.GetByIdAsync(dto.FitnessClassId);

            if (fitnessClass == null)
                throw new Exception("Fitness class not found.");

            if (fitnessClass.ScheduledDate <= DateTime.UtcNow)
                throw new Exception("Cannot book a past class.");

            var alreadyBooked =
                await _bookingRepository.ExistsAsync(
                    dto.UserId,
                    dto.FitnessClassId);

            if (alreadyBooked)
                throw new Exception("User already booked this class.");

            if (fitnessClass.Bookings.Count >= fitnessClass.Capacity)
                throw new Exception("Class is full.");

            var booking = new Booking
            {
                UserId = dto.UserId,
                FitnessClassId = dto.FitnessClassId,
                BookingDate = DateTime.UtcNow
            };

            await _bookingRepository.CreateAsync(booking);
        }

        public async Task<IEnumerable<BookingReadDto>> GetAllBookingsAsync()
        {
            var bookings = await _bookingRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<BookingReadDto>>(bookings);
        }
    }
}
