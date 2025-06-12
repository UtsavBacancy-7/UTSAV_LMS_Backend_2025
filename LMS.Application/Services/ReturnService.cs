using LMS_Backend.LMS.Application.Interfaces.BookTransactions;
using LMS_Backend.LMS.Domain.Entities;

namespace LMS_Backend.LMS.Application.Services
{
    public class ReturnService : IReturnService
    {
        public Task<ReturnRequest> ApproveReturnRequestAsync(int returnRequestId, int approverId)
        {
            throw new NotImplementedException();
        }

        public Task<ReturnRequest> CreateReturnRequestAsync(int borrowRequestId, int requestedBy)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ReturnRequest>> GetAllReturnRequestsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ReturnRequest>> GetReturnRequestsForUserAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<ReturnRequest> RejectReturnRequestAsync(int returnRequestId, int approverId)
        {
            throw new NotImplementedException();
        }
    }
}
