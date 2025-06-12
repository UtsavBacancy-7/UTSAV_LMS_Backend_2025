using LMS_Backend.LMS.Domain.Entities;

namespace LMS_Backend.LMS.Application.Interfaces.BookTransactions
{
    public interface IReturnRequestRepository
    {
        Task<ReturnRequest?> GetReturnRequestByIdQuery(int id);
        Task<IEnumerable<ReturnRequest>> GetAllReturnRequestsQuery();
        Task<IEnumerable<ReturnRequest>> GetReturnRequestsByUserIdQuery(int userId);
        Task<IEnumerable<ReturnRequest>> GetPendingReturnRequestsQuery();
        Task<ReturnRequest?> GetReturnRequestWithBorrowQuery(int id);

        Task AddReturnRequestQuery(ReturnRequest request);
        Task UpdateReturnRequestQuery(ReturnRequest request);
    }
}