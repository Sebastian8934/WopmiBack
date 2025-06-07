using Application.Models;

namespace Application.Interface
{
    public interface IAuthService
    {
        Task<AuthResult> LoginAsync(string email, string password);
        Task<AuthResult> RegisterAsync(string email, string password);
        Task LogoutAsync();
        Task<string> GenerateToken(string userId);
    }
}
