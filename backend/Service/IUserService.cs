using Core.Models;

namespace Service
{
    public interface IUserService
    {
        Task<UserProfileModel> GetUserByIdAsync(int userId);
        Task<UserProfileModel> GetUserByAdObjIdAsync(string adObjId);
        Task AddUserAsync(UserProfileModel user);
        Task UpdateUserAsync(UserProfileModel user);
        Task DeleteUserAsync(int userId);
    }
}
