using LMS_Backend.LMS.Application.DTOs.Authentication;
using LMS_Backend.LMS.Domain.Entities;

namespace LMS_Backend.LMS.Application.Interfaces.Authentication
{
    public interface IAuthService
    {
        Task<User> GetUserByEmailAsync(string email);
        string GenerateResetToken();
        Task<bool> CheckUserExistsAsync(string email);
        Task<bool> UpdatePasswordDB(string newPassword, User user);
        Task<string> GenerateAndSendOtpAsync(string email);
    }
}