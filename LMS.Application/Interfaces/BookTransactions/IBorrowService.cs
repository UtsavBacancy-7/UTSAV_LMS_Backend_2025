using LMS_Backend.LMS.Domain.Entities;

namespace LMS_Backend.LMS.Application.Interfaces.BookTransactions
{
    public interface IBorrowService
    {
        Task<IEnumerable<BorrowRequest>> GetAllBorrowRequestsAsync();
        Task<BorrowRequest?> GetBorrowRequestByIdAsync(int id);
        Task<BorrowRequest> AddBorrowRequestAsync(BorrowRequest request, int createdBy);
        Task<BorrowRequest> UpdateBorrowRequestAsync(BorrowRequest request, int updatedBy);
        Task<bool> DeleteBorrowRequestAsync(int id, int deletedBy);
    }
}