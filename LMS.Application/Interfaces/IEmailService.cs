namespace LMS_Backend.LMS.Application.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(string toEmail, string subject, string body);
        Task SendUserRegistrationEmailAsync(string toEmail, string password);
        Task SendStudentRegistrationEmailAsync(string toEmail, string studentName);
    }
}