using Application.DTOs;

namespace Application.Interface
{
    public interface IUserQueryService
    {
        Task<UserDto> GetUserWithRoleByEmailAsync(string email);
    }
}
