using System.ComponentModel.DataAnnotations;

namespace LMS_Backend.LMS.Application.DTOs.BookTransaction
{
    public class ReturnRequestCreateDTO
    {
        [Required(ErrorMessage = "Borrow request ID is required.")]
        public int BorrowRequestId { get; set; }

        [Required(ErrorMessage = "User ID is required.")]
        public int RequestedBy { get; set; }
    }
}