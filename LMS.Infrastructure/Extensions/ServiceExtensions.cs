using LMS_Backend.LMS.Application.Interfaces;
using LMS_Backend.LMS.Application.Interfaces.Authentication;
using LMS_Backend.LMS.Application.Interfaces.BooksManagement;
using LMS_Backend.LMS.Application.Interfaces.GenreManagement;
using LMS_Backend.LMS.Application.Interfaces.UserManagement;
using LMS_Backend.LMS.Application.Services;
using LMS_Backend.LMS.Infrastructure.Helpers;
using LMS_Backend.LMS.Infrastructure.Repository;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace LMS_Backend.LMS.Infrastructure.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<IEmailService, EmailHelper>();
            services.AddScoped<JwtTokenHelper>();

            return services;
        }
    }
}
