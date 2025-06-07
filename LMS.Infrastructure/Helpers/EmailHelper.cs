using System.Net.Mail;
using System.Net;

namespace LMS_Backend.LMS.Infrastructure.Helpers
{
    public class EmailHelper
    {
        private readonly IConfiguration _configuration;

        public EmailHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // email sending logic
        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            try
            {
                using var smtpClient = new SmtpClient(_configuration["EmailSettings:SmtpServer"])
                {
                    Port = int.Parse(_configuration["EmailSettings:SmtpPort"]),
                    Credentials = new NetworkCredential(
                        _configuration["EmailSettings:SenderEmail"],
                        _configuration["EmailSettings:SenderPassword"]
                    ),
                    EnableSsl = true
                };

                using var mailMessage = new MailMessage
                {
                    From = new MailAddress(_configuration["EmailSettings:SenderEmail"], _configuration["EmailSettings:SenderName"]),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                };

                mailMessage.To.Add(toEmail);

                await smtpClient.SendMailAsync(mailMessage);
                Console.WriteLine($"Email sent successfully to {toEmail}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Email Error: {ex.Message}");
            }
        }

        private const string ContainerEnd = @"
                <div style='text-align: center; margin-top: 30px;'>
                    <p style='color: #7f8c8d; font-size: 14px;'>Best Regards,</p>
                    <p style='color: #2c3e50; font-size: 16px; font-weight: bold;'>Bacancy - EMS Team</p>
                    <img src='https://drive.google.com/uc?export=view&id=1J-OM4zr7GXGMuI6Hzl6pT8HOsAL98z5n' alt='Bacancy Logo' style='width: 60%; margin-top: 10px;' />
                </div>
            </div>";

        public async Task SendUserRegistrationEmailAsync(string toEmail, string? password)
        {
            string emailSubject = "Welcome to Readify - Your Digital Library Account";
            string emailBody = $@"
                        <h2 style='color: #2c3e50; text-align: center;'>Welcome to Readify.</h2>
                        <p style='font-size: 18px; color: #34495e; text-align: center;'>
                            Your account has been successfully created in our Library Management System.
                        </p>
                        <div style='background-color: #ffffff; padding: 20px; border-radius: 8px; 
                                    box-shadow: 0 2px 8px rgba(0, 0, 0, 0.1); text-align: center;'>
                            <p style='font-size: 16px;'><strong>Email:</strong> {toEmail}</p>
                            <p style='font-size: 16px;'><strong>Temporary Password:</strong> {password}</p>
                            <p style='color: #e74c3c; font-size: 14px;'><em>We recommend updating your password after first login for security.</em></p>
                        </div>
                        <div style='text-align: center; margin-top: 20px;'>
                            <a href='https://yourdomain.com/login' 
                               style='background-color: #248f24; color: #ffffff; padding: 12px 24px; 
                                      text-decoration: none; border-radius: 5px; font-size: 16px; font-weight: bold;'>
                                Login to Readify
                            </a>
                        </div>
                        {ContainerEnd}";

            await SendEmailAsync(toEmail, emailSubject, emailBody);
        }
    }
}