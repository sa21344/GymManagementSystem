using AutoMapper;
using GymManagementAPI.DTOs;
using GymManagementAPI.Models;
using GymManagementAPI.Repositories;

namespace GymManagementAPI.Services
{
    public class FitnessClassService : IFitnessClassService
    {
        private readonly IFitnessClassRepository _repository;
        private readonly IMapper _mapper;

        public FitnessClassService(
            IFitnessClassRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FitnessClassReadDto>> GetAllAsync()
        {
            var classes = await _repository.GetAllAsync();

            return _mapper.Map<IEnumerable<FitnessClassReadDto>>(classes);
        }

        public async Task<FitnessClassReadDto?> GetByIdAsync(int id)
        {
            var fitnessClass = await _repository.GetByIdAsync(id);

            if (fitnessClass == null)
                return null;

            return _mapper.Map<FitnessClassReadDto>(fitnessClass);
        }

        public async Task<FitnessClassReadDto> CreateAsync(FitnessClassCreateDto dto)
        {
            if (dto.Capacity <= 0)
                throw new Exception("Capacity must be greater than zero.");

            if (dto.ScheduledDate <= DateTime.UtcNow)
                throw new Exception("Scheduled date must be in the future.");

            var fitnessClass = _mapper.Map<FitnessClass>(dto);

            await _repository.CreateAsync(fitnessClass);

            return _mapper.Map<FitnessClassReadDto>(fitnessClass);
        }

        public async Task UpdateAsync(int id, FitnessClassCreateDto dto)
        {
            var fitnessClass = await _repository.GetByIdAsync(id);

            if (fitnessClass == null)
                throw new Exception("Fitness class not found.");

            fitnessClass.Name = dto.Name;
            fitnessClass.Instructor = dto.Instructor;
            fitnessClass.Category = dto.Category;
            fitnessClass.ScheduledDate = dto.ScheduledDate;
            fitnessClass.DurationMinutes = dto.DurationMinutes;
            fitnessClass.Capacity = dto.Capacity;

            await _repository.UpdateAsync(fitnessClass);
        }

        public async Task DeleteAsync(int id)
        {
            var fitnessClass = await _repository.GetByIdAsync(id);

            if (fitnessClass == null)
                throw new Exception("Fitness class not found.");

            await _repository.DeleteAsync(fitnessClass);
        }
    }
}
