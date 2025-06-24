using Application.Shared;

namespace Application.Interface
{
    public interface IRoleService
    {
        Task<bool> CreateAsync(string name);
        Task<List<RoleDto>> GetAllAsync();
        Task<RoleDto?> GetByIdAsync(string id);
        Task<bool> UpdateAsync(string id, string newName);
        Task<bool> DeleteAsync(string id);
    }
}
