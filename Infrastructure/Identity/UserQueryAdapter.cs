using Application.DTOs;
using Application.Interface;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class UserQueryAdapter : IUserQueryService
    {
        private readonly UserManager<AppUser> _userManager;

        public UserQueryAdapter(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<UserDto> GetUserWithRoleByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) return null;

            var roles = await _userManager.GetRolesAsync(user);
            var firstRole = roles.FirstOrDefault() ?? "";

            return new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                FullName = user.FullName,
                Role = firstRole
            };
        }
    }
}
