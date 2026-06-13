using GymManagementAPI.Models;

namespace GymManagementAPI.Repositories
{
    public interface IFitnessClassRepository
    {
        Task<IEnumerable<FitnessClass>> GetAllAsync();

        Task<FitnessClass?> GetByIdAsync(int id);

        Task CreateAsync(FitnessClass fitnessClass);

        Task UpdateAsync(FitnessClass fitnessClass);

        Task DeleteAsync(FitnessClass fitnessClass);
    }
}
