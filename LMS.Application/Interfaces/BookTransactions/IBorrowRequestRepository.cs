using LMS_Backend.LMS.Application.DTOs.BookTransaction;
using LMS_Backend.LMS.Application.DTOs.User;
using LMS_Backend.LMS.Domain.Entities;
using Microsoft.AspNetCore.JsonPatch;

namespace LMS_Backend.LMS.Application.Interfaces.BookTransactions
{
    public interface IBorrowRequestRepository
    {
        Task<IEnumerable<BorrowResponseDTO>> GetAllBorrowRequestsQuery();
        Task<BorrowResponseDTO?> GetBorrowRequestByIdQuery(int id);
        Task<bool> AddBorrowRequestQuery(BorrowRequestCreateDTO request, int createdBy);
        Task<bool> PatchBorrowRequestQuery(int id, JsonPatchDocument<BorrowRequestUpdateStatusDTO> patchDoc,int updatedBy);
        Task<bool> DeleteBorrowRequestQuery(int id, int deletedBy);
    }
}