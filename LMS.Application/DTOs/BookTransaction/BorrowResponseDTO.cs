using LMS_Backend.LMS.Domain.Enums;

namespace LMS_Backend.LMS.Application.DTOs.BookTransaction
{
    public class BorrowResponseDTO
    {
        public int BorrowRequestId { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public RequestStatus Status { get; set; }
        public DateOnly RequestDate { get; set; }
        public int? ApprovedBy { get; set; }
        public DateOnly? ApprovedDate { get; set; }
        public DateOnly? DueDate { get; set; }
        public DateOnly? ReturnDate { get; set; }
    }
}