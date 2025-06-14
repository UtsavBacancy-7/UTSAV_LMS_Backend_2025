using LMS_Backend.LMS.Application.DTOs.BookTransaction;
using LMS_Backend.LMS.Domain.Entities;
using Microsoft.AspNetCore.JsonPatch;

namespace LMS_Backend.LMS.Application.Interfaces.BookTransactions
{
    public interface IReturnService
    {
        Task<ReturnResponseDTO?> GetReturnRequestByIdAsync(int id);
        Task<IEnumerable<ReturnResponseDTO>> GetAllReturnRequestsAsync();
        Task<IEnumerable<ReturnResponseDTO>> GetReturnRequestsByUserIdAsync(int userId);
        Task<bool> AddReturnRequestAsync(ReturnRequestCreateDTO request, int createdBy);
        Task<bool> PatchReturnRequestAsync(int id, JsonPatchDocument<ReturnRequestUpdateStatusDTO> patchDoc, int updatedBy);
        Task<bool> DeleteReturnRequestAsync(int id, int deletedBy);
    }
}