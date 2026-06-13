using GymManagementAPI.DTOs;

namespace GymManagementAPI.Services
{
    public interface IAuthService
    {
        Task RegisterAsync(RegisterDto dto);

        Task<string?> LoginAsync(LoginDto dto);
    }
}
