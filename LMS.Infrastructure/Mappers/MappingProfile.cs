using AutoMapper;
using LMS_Backend.LMS.Application.DTOs.BookManagement;
using LMS_Backend.LMS.Application.DTOs.GenreManagement;
using LMS_Backend.LMS.Application.DTOs.NewFolder;
using LMS_Backend.LMS.Application.DTOs.User;
using LMS_Backend.LMS.Application.DTOs.UserManagement;
using LMS_Backend.LMS.Domain.Entities;

namespace LMS_Backend.LMS.Infrastructure.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookDTO>()
                .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.BookId))
                .ReverseMap()
                .ForMember(dest => dest.BookId, opt => opt.Ignore());

            CreateMap<Book, GetBookDTO>()
                .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.BookId))
                .ForMember(dest => dest.GenreName, opt => opt.MapFrom(src => src.Genre.GenreName)) 
                .ReverseMap()
                .ForMember(dest => dest.BookId, opt => opt.Ignore());

            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role != null ? src.Role.RoleName : string.Empty));

            CreateMap<User, UserDataDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.RoleName))
                .ReverseMap()
                .ForMember(dest => dest.UserId, opt => opt.Ignore())
                .ForMember(dest => dest.Role, opt => opt.Ignore());

            CreateMap<User, GetUserDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role != null ? src.Role.RoleName : string.Empty));

            CreateMap<Genre, GenreDTO>();
            CreateMap<CreateGenreDTO, Genre>();
            CreateMap<UpdateGenreDTO, Genre>();
        }
    }
}