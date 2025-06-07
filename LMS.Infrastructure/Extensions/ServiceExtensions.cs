using Microsoft.Extensions.Configuration.UserSecrets;

namespace LMS_Backend.LMS.Infrastructure.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            //services.AddScoped<IAuthRepository, AuthRepository>();
            //services.AddScoped<IUserRepository, UserRepository>();
            //services.AddScoped<ITimeSheetRepository, TimeSheetRepository>();
            //services.AddScoped<ILeaveRepository, LeaveRepository>();
            //services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            //services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            //services.AddScoped<IReportRepository, ReportRepository>();
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            //services.AddScoped<IUserService, UserService>();
            //services.AddScoped<ILeaveService, LeaveService>();
            //services.AddScoped<ITimeSheetService, TimeSheetService>();
            //services.AddScoped<IDepartmentService, DepartmentService>();
            //services.AddScoped<IReportService, ReportAnalyticsService>();
            //services.AddScoped<IEmployeeService, EmployeeService>();
            //services.AddScoped<IAuthService, AuthHelper>();
            //services.AddScoped<IEmailService, EmailHelper>();
            //services.AddScoped<JWTTokenHelper>();

            return services;
        }
    }
}
