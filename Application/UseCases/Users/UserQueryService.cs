using Application.DTOs;
using Application.Interface;
using Domain.Ports;

namespace Application.UseCases.Users
{
    public class UserQueryService
    {
        private readonly IUserQueryService _userQueryService;
        public UserQueryService(IUserQueryService userQueryService)
        {
            _userQueryService = userQueryService;
        }

        public async Task<UserDto> GetUserWithRoleByEmailAsync(string email)
        {
           return await _userQueryService.GetUserWithRoleByEmailAsync(email);
        }
    }
}
