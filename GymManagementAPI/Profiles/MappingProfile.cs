using AutoMapper;
using GymManagementAPI.DTOs;
using GymManagementAPI.Models;

namespace GymManagementAPI.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<FitnessClassCreateDto, FitnessClass>();

            CreateMap<FitnessClass, FitnessClassReadDto>()
                .ForMember(
                    dest => dest.AvailableSpots,
                    opt => opt.MapFrom(src =>
                        src.Capacity - src.Bookings.Count));

            CreateMap<Booking, BookingReadDto>()
                .ForMember(
                    dest => dest.UserName,
                    opt => opt.MapFrom(src =>
                        src.User.FullName));
        }
    }
}