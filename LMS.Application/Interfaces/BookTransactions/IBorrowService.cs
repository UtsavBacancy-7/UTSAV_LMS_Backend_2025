using LMS_Backend.LMS.Application.DTOs.BookTransaction;
using LMS_Backend.LMS.Application.DTOs.User;
using LMS_Backend.LMS.Domain.Entities;
using Microsoft.AspNetCore.JsonPatch;

namespace LMS_Backend.LMS.Application.Interfaces.BookTransactions
{
    public interface IBorrowService
    {
        Task<IEnumerable<BorrowResponseDTO>> GetAllBorrowRequestsAsync();
        Task<BorrowResponseDTO?> GetBorrowRequestByIdAsync(int id);
        Task<bool> AddBorrowRequestAsync(BorrowRequestCreateDTO request, int createdBy);
        Task<bool> PatchBorrowRequestAsync(int id, JsonPatchDocument<BorrowRequestUpdateStatusDTO> patchDoc, int updatedBy);
        Task<bool> DeleteBorrowRequestAsync(int id, int deletedBy);
    }
}