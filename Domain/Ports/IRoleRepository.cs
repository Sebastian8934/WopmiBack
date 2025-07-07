namespace Domain.Ports
{
    public interface IRoleRepository
    {
        Task<bool> ExistsAsync(string name);
        Task<bool> CreateAsync(string name);
        Task<List<string>> GetAllAsync();
        Task<string?> GetByIdAsync(string id);
        Task<bool> UpdateAsync(string id, string newName);
        Task<bool> DeleteAsync(string id);
    }
}
