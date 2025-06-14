using LMS_Backend.LMS.Application.DTOs.BookTransaction;
using LMS_Backend.LMS.Domain.Entities;
using Microsoft.AspNetCore.JsonPatch;

namespace LMS_Backend.LMS.Application.Interfaces.BookTransactions
{
    public interface IReturnRequestRepository
    {
        Task<ReturnResponseDTO?> GetReturnRequestByIdQuery(int id);
        Task<IEnumerable<ReturnResponseDTO>> GetAllReturnRequestsQuery();
        Task<IEnumerable<ReturnResponseDTO>> GetReturnRequestsByUserIdQuery(int userId);
        Task<bool> AddReturnRequestQuery(ReturnRequestCreateDTO request, int createdBy);
        Task<bool> PatchReturnRequestQuery(int id, JsonPatchDocument<ReturnRequestUpdateStatusDTO> patchDoc, int updatedBy);
        Task<bool> DeleteReturnRequestQuery(int id, int deletedBy);
    }
}