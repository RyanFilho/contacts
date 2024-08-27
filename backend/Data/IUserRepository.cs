using Core.Entities;

namespace Data
{
    public interface IUserRepository
    {
        Task<UserProfile> GetUserByIdAsync(int userId);
        Task AddUserAsync(UserProfile user);
        Task UpdateUserAsync(UserProfile user);
        Task DeleteUserAsync(int userId);
        Task<UserProfile> GetUserByAdObjIdAsync(string adObjId);
    }

}
