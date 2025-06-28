using Application.DTOs;

namespace Application.Interface
{
    public interface IUserService
    {
        Task<UserDto?> GetUserByIdAsync(string userId);
        Task<UserDto?> GetUserByEmailAsync(string email);
        Task<List<UserDto>> GetAllUsersAsync();
        Task<bool> UpdateFullNameAsync(string userId, string fullName);
        Task<bool> DeleteUserAsync(string userId);
    }
}
