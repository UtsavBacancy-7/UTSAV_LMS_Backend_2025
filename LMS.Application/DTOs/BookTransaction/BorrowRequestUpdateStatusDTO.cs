using LMS_Backend.LMS.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace LMS_Backend.LMS.Application.DTOs.BookTransaction
{
    public class BorrowRequestUpdateStatusDTO
    {
        [Required(ErrorMessage = "Borrow Request ID is required.")]
        public int BorrowRequestId { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        public BorrowRequestStatus Status { get; set; }

        [Required(ErrorMessage = "Approver ID is required.")]
        public int ApprovedBy { get; set; }
    }
}