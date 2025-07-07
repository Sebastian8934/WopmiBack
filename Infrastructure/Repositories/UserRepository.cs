using Domain.Entities;
using Domain.Ports;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<AppUser> _userManager;

        public UserRepository(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<User?> GetByIdAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return user == null ? null : Map(user);
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return user == null ? null : Map(user);
        }

        public Task<List<User>> GetAllAsync()
        {
            return Task.FromResult(_userManager.Users.Select(Map).ToList());
        }

        public async Task<bool> UpdateFullNameAsync(string id, string fullName)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return false;

            user.FullName = fullName;
            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return false;

            var result = await _userManager.DeleteAsync(user);
            return result.Succeeded;
        }

        private static User Map(AppUser user) => new()
        {
            Id = user.Id,
            Email = user.Email,
            FullName = user.FullName
        };
    }
}
