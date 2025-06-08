using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LMS_Backend.LMS.Domain.Enums;

namespace LMS_Backend.LMS.Domain.Entities
{
    public class ReturnRequest : BaseEntity, IValidatableObject
    {
        [Key]
        public int ReturnRequestId { get; set; }

        [Required(ErrorMessage = "Borrow ID is required")]
        public int BorrowRequestId { get; set; }

        [Required(ErrorMessage = "RequestedBy is required")]
        public int RequestedBy { get; set; }

        [Required(ErrorMessage = "RequestedAt date is required")]
        public DateTime RequestedAt { get; set; }

        public int? ApprovedBy { get; set; }

        public DateTime? ApprovedAt { get; set; }

        [Required(ErrorMessage = "Status is required")]
        public ReturnRequestStatus Status { get; set; }

        public bool? PenaltyFinlized { get; set; }

        public DateTime? DeletedAt { get; set; }
        public int? DeletedBy { get; set; }

        // Navigation properties
        public BorrowRequest BorrowRequest { get; set; }

        // Custom date validations
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var now = DateTime.UtcNow;

            if (RequestedAt > now)
            {
                yield return new ValidationResult(
                    "Requested date cannot be in the future",
                    new[] { nameof(RequestedAt) });
            }

            if (ApprovedAt.HasValue)
            {
                if (ApprovedAt.Value < RequestedAt)
                {
                    yield return new ValidationResult(
                        "Approved date cannot be before requested date",
                        new[] { nameof(ApprovedAt) });
                }

                if (ApprovedAt.Value > now)
                {
                    yield return new ValidationResult(
                        "Approved date cannot be in the future",
                        new[] { nameof(ApprovedAt) });
                }
            }
        }
    }
}