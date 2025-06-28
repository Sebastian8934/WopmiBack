using Application.DTOs;
using Application.Interface;
using Domain.Interfaces;

namespace Application.UseCases.Roles
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _repository;

        public RoleService(IRoleRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> CreateAsync(string name)
        {
            if (await _repository.ExistsAsync(name))
                return false;

            return await _repository.CreateAsync(name);
        }

        public async Task<List<RoleDto>> GetAllAsync()
        {
            var roles = await _repository.GetAllAsync();
            return roles.Select((r, i) => new RoleDto { Id = $"#{i}", Name = r }).ToList();
        }

        public async Task<RoleDto?> GetByIdAsync(string id)
        {
            var name = await _repository.GetByIdAsync(id);
            return name == null ? null : new RoleDto { Id = id, Name = name };
        }

        public async Task<bool> UpdateAsync(string id, string newName)
        {
            return await _repository.UpdateAsync(id, newName);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            return await _repository.DeleteAsync(id);
        }

    }
}
