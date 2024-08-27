using Core.Entities;
using Core.Models;
using Data;

namespace Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // UserProfile related methods
        public async Task<UserProfileModel> GetUserByIdAsync(int userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            return user != null ? MapToUserProfileModel(user) : null;
        }

        public async Task<UserProfileModel> GetUserByAdObjIdAsync(string adObjId)
        {
            var user = await _userRepository.GetUserByAdObjIdAsync(adObjId);
            return user != null ? MapToUserProfileModel(user) : null;
        }

        public async Task AddUserAsync(UserProfileModel userModel)
        {
            var user = MapToUserProfileEntity(userModel);
            await _userRepository.AddUserAsync(user);
            userModel.UserId = user.UserId; // Return the new UserId
        }

        public async Task UpdateUserAsync(UserProfileModel userModel)
        {
            var user = MapToUserProfileEntity(userModel);
            await _userRepository.UpdateUserAsync(user);
        }

        public async Task DeleteUserAsync(int userId)
        {
            await _userRepository.DeleteUserAsync(userId);
        }

        // Mapping methods
        private UserProfileModel MapToUserProfileModel(UserProfile user)
        {
            return new UserProfileModel
            {
                UserId = user.UserId,
                DisplayName = user.DisplayName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                AdObjId = user.AdObjId
            };
        }

        private UserProfile MapToUserProfileEntity(UserProfileModel userModel)
        {
            var userProfile =  new UserProfile
            {
                UserId = userModel.UserId,
                DisplayName = userModel.DisplayName,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Email = userModel.Email,
                AdObjId = userModel.AdObjId                
            };

            return userProfile;
        }
    }

}
