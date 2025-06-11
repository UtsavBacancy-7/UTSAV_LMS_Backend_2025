using LMS_Backend.LMS.Application.DTOs.GenreManagement;

namespace LMS_Backend.LMS.Application.Interfaces.GenreManagement
{
    public interface IGenreService
    {
        Task<IEnumerable<GenreDTO>> GetAllGenresAsync();
        Task<GenreDTO?> GetGenreByIdAsync(int id);
        Task<int> AddGenreAsync(CreateGenreDTO createGenreDto, int createdBy);
        Task<int> UpdateGenreAsync(UpdateGenreDTO updateGenreDto, int updatedBy);
        Task<bool> DeleteGenreAsync(int id);
    }
}