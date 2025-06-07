namespace LMS_Backend.LMS.Domain.Enums
{
    public enum BorrowRequestStatus
    {
        Pending = 0,
        Approved = 1,
        Rejected = 2,
        Issued = 3,
        Returned = 4,
        Overdue = 5
    }
}