using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class RoleRepositoryAdapter : IRoleRepository
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleRepositoryAdapter(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<bool> ExistsAsync(string name) =>
            await _roleManager.RoleExistsAsync(name);

        public async Task<bool> CreateAsync(string name)
        {
            var result = await _roleManager.CreateAsync(new IdentityRole(name));
            return result.Succeeded;
        }

        public async Task<List<string>> GetAllAsync()
        {
            return _roleManager.Roles.Select(r => r.Name).ToList();
        }

        public async Task<string?> GetByIdAsync(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            return role?.Name;
        }

        public async Task<bool> UpdateAsync(string id, string newName)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null) return false;

            role.Name = newName;
            var result = await _roleManager.UpdateAsync(role);
            return result.Succeeded;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null) return false;

            var result = await _roleManager.DeleteAsync(role);
            return result.Succeeded;
        }
    }
}
