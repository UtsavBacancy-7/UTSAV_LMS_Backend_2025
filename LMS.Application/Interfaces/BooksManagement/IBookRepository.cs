using LMS_Backend.LMS.Application.DTOs.BookManagement;
using Microsoft.AspNetCore.JsonPatch;

namespace LMS_Backend.LMS.Application.Interfaces.BooksManagement
{
    public interface IBookRepository
    {
        Task<BookDTO> GetBookByIdQuery(int id);
        Task<IEnumerable<BookDTO>> GetAllBooksQuery();
        Task<bool> AddBookQuery(BookDTO book, int createdBy);
        Task<bool> PatchBookQuery(int id, JsonPatchDocument<BookDTO> patchDoc, int updatedBy);
        Task<bool> UpdateBookQuery(int id, BookDTO bookDto, int updatedBy);
        Task<bool> DeleteBookQuery(int id, int deletedBy);
    }
}