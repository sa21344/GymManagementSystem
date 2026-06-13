using GymManagementAPI.Models;

namespace GymManagementAPI.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email);

        Task CreateAsync(User user);
    }
}
