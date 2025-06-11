using LMS_Backend.LMS.Application.DTOs.GenreManagement;
using LMS_Backend.LMS.Domain.Entities;

namespace LMS_Backend.LMS.Application.Interfaces.GenreManagement
{
    public interface IGenreRepository
    {
        Task<IEnumerable<GenreDTO>> GetAllGenresQuery();
        Task<GenreDTO?> GetGenreByIdQuery(int id);
        Task<int> AddGenreQuery(CreateGenreDTO genre, int createdBy);
        Task<int> UpdateGenreQuery(UpdateGenreDTO genre, int updatedBy);
        Task<bool> DeleteGenreQuery(int id);
    }
}