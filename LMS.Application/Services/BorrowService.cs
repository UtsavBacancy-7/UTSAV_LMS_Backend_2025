using LMS_Backend.LMS.Application.Interfaces.BookTransactions;
using LMS_Backend.LMS.Domain.Entities;

namespace LMS_Backend.LMS.Application.Services
{
    public class BorrowService : IBorrowService
    {
        private readonly IBorrowRequestRepository _borrowRequestRepository;

        public BorrowService(IBorrowRequestRepository borrowRequestRepository)
        {
            _borrowRequestRepository = borrowRequestRepository;
        }

        public async Task<BorrowRequest> AddBorrowRequestAsync(BorrowRequest request, int createdBy)
        {
            return await _borrowRequestRepository.AddBorrowRequestQuery(request, createdBy);
        }

        public async Task<bool> DeleteBorrowRequestAsync(int id, int deletedBy)
        {
            return await _borrowRequestRepository.DeleteBorrowRequestQuery(id, deletedBy);
        }

        public async Task<IEnumerable<BorrowRequest>> GetAllBorrowRequestsAsync()
        {
            return await _borrowRequestRepository.GetAllBorrowRequestsQuery();
        }

        public async Task<BorrowRequest?> GetBorrowRequestByIdAsync(int id)
        {
            return await _borrowRequestRepository.GetBorrowRequestByIdQuery(id);
        }

        public async Task<BorrowRequest> UpdateBorrowRequestAsync(BorrowRequest request, int updatedBy)
        {
            return await _borrowRequestRepository.UpdateBorrowRequestQuery(request, updatedBy);
        }
    }
}
