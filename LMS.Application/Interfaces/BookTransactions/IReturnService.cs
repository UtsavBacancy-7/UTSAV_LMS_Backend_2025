using LMS_Backend.LMS.Domain.Entities;

namespace LMS_Backend.LMS.Application.Interfaces.BookTransactions
{
    public interface IReturnService
    {
        Task<ReturnRequest> CreateReturnRequestAsync(int borrowRequestId, int requestedBy);
        Task<ReturnRequest> ApproveReturnRequestAsync(int returnRequestId, int approverId);
        Task<ReturnRequest> RejectReturnRequestAsync(int returnRequestId, int approverId);
        Task<IEnumerable<ReturnRequest>> GetReturnRequestsForUserAsync(int userId);
        Task<IEnumerable<ReturnRequest>> GetAllReturnRequestsAsync();
    }
}