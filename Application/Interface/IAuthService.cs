using Application.Shared;

namespace Application.Interface
{
    public interface IAuthService
    {
        Task<AuthResultDto> LoginAsync(string email, string password);
        Task<AuthResultDto> RegisterAsync(string email, string password);
        Task LogoutAsync();
        Task<(string token, int expiresIn)> GenerateToken(string userId);
    }
}
