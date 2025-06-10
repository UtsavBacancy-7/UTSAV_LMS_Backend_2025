using LMS_Backend.LMS.Application.DTOs.Authentication;

namespace LMS_Backend.LMS.Application.Interfaces.Authentication
{
    public interface IAuthRepository
    {
        Task<object> LoginAsync(LoginDTO userLogin);
        Task<string> RegisterAsync(RegisterDTO register);
        Task<bool> ResetPassword(ResetPwdDTO resetPwd);
        Task<int> SendOtpToEmail(ForgotPwdDTO dto);
    }
}