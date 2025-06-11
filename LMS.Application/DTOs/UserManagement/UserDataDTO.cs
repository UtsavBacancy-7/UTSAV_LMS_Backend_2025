using LMS_Backend.LMS.Application.DTOs.NewFolder;

namespace LMS_Backend.LMS.Application.DTOs.User
{
    public class UserDataDTO : UserDTO
    {
        public string MobileNo { get; set; }
        public bool IsActive { get; set; }
        public string PasswordHash { get; set; }
    }
}