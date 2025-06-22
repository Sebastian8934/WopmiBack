using Domain.Entities;

namespace Domain.Ports
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(string id);
        Task<User?> GetByEmailAsync(string email);
        Task<List<User>> GetAllAsync();
        Task<bool> UpdateFullNameAsync(string id, string fullName);
        Task<bool> DeleteAsync(string id);
    }
}
