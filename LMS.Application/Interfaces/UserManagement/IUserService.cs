using LMS_Backend.LMS.Application.DTOs.NewFolder;
using LMS_Backend.LMS.Application.DTOs.User;
using LMS_Backend.LMS.Application.DTOs.UserManagement;
using Microsoft.AspNetCore.JsonPatch;

namespace LMS_Backend.LMS.Application.Interfaces.UserManagement
{
    public interface IUserService
    {
        Task<GetUserDTO?> GetUserByIdAsync(int id);
        Task<IEnumerable<GetUserDTO>> GetAllUsersAsync();
        Task<IEnumerable<GetUserDTO>> GetUsersByRoleAsync(string role);
        Task<int> AddUserAsync(UserDataDTO userDto, int createdBy);
        Task<bool> UpdateUserAsync(UserDataDTO userDto, int updatedBy);
        Task<bool> PatchUserAsync(int id, JsonPatchDocument<UserDataDTO> patchDoc, int updatedBy);
        Task<bool> DeleteUserAsync(int id, int deletedBy);
    }
}