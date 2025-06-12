using LMS_Backend.LMS.Domain.Entities;

namespace LMS_Backend.LMS.Application.Interfaces.BookTransactions
{
    public interface IBorrowRequestRepository
    {
        Task<IEnumerable<BorrowRequest>> GetAllBorrowRequestsQuery();
        Task<BorrowRequest?> GetBorrowRequestByIdQuery(int id);
        Task<BorrowRequest> AddBorrowRequestQuery(BorrowRequest request, int createdBy);
        Task<BorrowRequest> UpdateBorrowRequestQuery(BorrowRequest request, int updatedBy);
        Task<bool> DeleteBorrowRequestQuery(int id, int deletedBy);
    }
}