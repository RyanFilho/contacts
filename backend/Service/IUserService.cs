using Core.Models;

namespace Service
{
    public interface IUserService
    {
        Task<UserProfileModel> GetUserByIdAsync(int userId);
        Task AddUserAsync(UserProfileModel user);
        Task UpdateUserAsync(UserProfileModel user);
        Task DeleteUserAsync(int userId);
    }
}
