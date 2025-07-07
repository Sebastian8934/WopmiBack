using Application.DTOs;
using Application.Interface;
using Domain.Ports;

namespace Application.UseCases.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IRoleRepository _repositoryRole;

        public UserService(IUserRepository repository, IRoleRepository repositoryRole)
        {
            _repository = repository;
            _repositoryRole = repositoryRole;
        }

        public async Task<UserDto?> GetUserByIdAsync(string id)
        {
            var user = await _repository.GetByIdAsync(id);
            return user == null ? null : Map(user);
        }

        public async Task<UserDto?> GetUserByEmailAsync(string email)
        {
            var user = await _repository.GetByEmailAsync(email);
            return user == null ? null : Map(user);
        }

        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            var users = await _repository.GetAllAsync();
            return users.Select(Map).ToList();
        }

        public Task<bool> UpdateFullNameAsync(string id, string fullName) =>
            _repository.UpdateFullNameAsync(id, fullName);

        public Task<bool> DeleteUserAsync(string id) =>
            _repository.DeleteAsync(id);

        private static UserDto Map(Domain.Entities.User user) => new()
        {
            Id = user.Id,
            Email = user.Email,
            FullName = user.FullName
        };

    }
}

