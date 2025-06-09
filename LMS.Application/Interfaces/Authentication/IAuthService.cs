using LMS_Backend.LMS.Application.DTOs.Authentication;
using LMS_Backend.LMS.Domain.Entities;

namespace LMS_Backend.LMS.Application.Interfaces.Authentication
{
    public interface IAuthRepository
    {
        Task<string> LoginAsync(LoginDTO userLogin);
        Task<string> RegisterAsync(RegisterDTO register);
        Task<bool> ResetPassword(ResetPwdDTO resetPwd);
        Task<string> SendOtpToEmail(ForgotPwdDTO dto);
    }
}