using Application.DTOs;
using Application.Interface;
using Domain.Ports;

namespace Application.UseCases.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;

        public UserService(IUserRepository repo)
        {
            _repo = repo;
        }

        public async Task<UserDto?> GetUserByIdAsync(string id)
        {
            var user = await _repo.GetByIdAsync(id);
            return user == null ? null : Map(user);
        }

        public async Task<UserDto?> GetUserByEmailAsync(string email)
        {
            var user = await _repo.GetByEmailAsync(email);
            return user == null ? null : Map(user);
        }

        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            var users = await _repo.GetAllAsync();
            return users.Select(Map).ToList();
        }

        public Task<bool> UpdateFullNameAsync(string id, string fullName) =>
            _repo.UpdateFullNameAsync(id, fullName);

        public Task<bool> DeleteUserAsync(string id) =>
            _repo.DeleteAsync(id);

        private static UserDto Map(Domain.Entities.User user) => new()
        {
            Id = user.Id,
            Email = user.Email,
            FullName = user.FullName
        };

    }
}

