using GymManagementAPI.DTOs;

namespace GymManagementAPI.Services
{
    public interface IFitnessClassService
    {
        Task<IEnumerable<FitnessClassReadDto>> GetAllAsync();

        Task<FitnessClassReadDto?> GetByIdAsync(int id);

        Task<FitnessClassReadDto> CreateAsync(FitnessClassCreateDto dto);

        Task UpdateAsync(int id, FitnessClassCreateDto dto);

        Task DeleteAsync(int id);
    }
}