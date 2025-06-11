using LMS_Backend.LMS.Application.DTOs.NewFolder;
using LMS_Backend.LMS.Application.DTOs.User;
using LMS_Backend.LMS.Application.DTOs.UserManagement;
using LMS_Backend.LMS.Domain.Entities;
using Microsoft.AspNetCore.JsonPatch;

namespace LMS_Backend.LMS.Application.Interfaces.UserManagement
{
    public interface IUserRepository
    {
        Task<GetUserDTO?> GetUserByIdQuery(int id);
        Task<IEnumerable<GetUserDTO>> GetAllUsersQuery();
        Task<IEnumerable<GetUserDTO>> GetUsersByRoleQuery(string role);
        Task<int> AddUserQuery(UserDataDTO userDto, int createdBy);
        Task<bool> UpdateUserQuery(UserDataDTO userDto, int updatedBy);
        Task<bool> PatchUserQuery(int id, JsonPatchDocument<UserDataDTO> patchDoc, int updatedBy);
        Task<bool> DeleteUserQuery(int id, int deletedBy);
    }
}