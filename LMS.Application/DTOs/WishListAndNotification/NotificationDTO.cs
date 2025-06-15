namespace LMS_Backend.LMS.Application.DTOs.WishListAndNotification
{
    public class NotificationDTO
    {
        public int NotificationId { get; set; }
        public int UserId { get; set; }
        public string Message { get; set; }
        public string Type { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? BookId { get; set; }
        public string BookTitle { get; set; }
    }
}