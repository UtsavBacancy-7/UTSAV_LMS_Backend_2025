using LMS_Backend.LMS.Application.DTOs.BookManagement;
using Microsoft.AspNetCore.JsonPatch;

namespace LMS_Backend.LMS.Application.Interfaces.BooksManagement
{
    public interface IBookService
    {
        Task<GetBookDTO> GetBookByIdAsync(int id);
        Task<IEnumerable<GetBookDTO>> GetAllBooksAsync();
        Task<bool> AddBookAsync(BookDTO book, int createdBy);
        Task<bool> PatchBookAsync(int id, JsonPatchDocument<BookDTO> patchDoc, int updatedBy);
        Task<bool> UpdateBookAsync(int id, BookDTO bookDto, int updatedBy);
        Task<bool> DeleteBookAsync(int id, int deletedBy);

    }
}