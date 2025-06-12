using LMS_Backend.LMS.Application.Interfaces.BookTransactions;
using LMS_Backend.LMS.Domain.Entities;
using LMS_Backend.LMS.Infrastructure.Context;

namespace LMS_Backend.LMS.Infrastructure.Repository
{
    public class BorrowRequestRepository : GenericRepository<BorrowRequest>, IBorrowRequestRepository
    {
        public BorrowRequestRepository(ApplicationDBContext context) : base(context){}

        public Task<BorrowRequest> AddBorrowRequestQuery(BorrowRequest request, int createdBy)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteBorrowRequestQuery(int id, int deletedBy)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BorrowRequest>> GetAllBorrowRequestsQuery()
        {
            throw new NotImplementedException();
        }

        public Task<BorrowRequest?> GetBorrowRequestByIdQuery(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BorrowRequest> UpdateBorrowRequestQuery(BorrowRequest request, int updatedBy)
        {
            throw new NotImplementedException();
        }
    }
}
