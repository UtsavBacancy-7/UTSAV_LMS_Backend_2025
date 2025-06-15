using LMS_Backend.LMS.Application.DTOs.WishListAndNotification;

namespace LMS_Backend.LMS.Application.Interfaces.WishListAndNotification
{
    public interface IWishlistAndNotificationRepository
    {
        public Task<bool> AddToWishlistQuery(int userId, int bookId);
        public Task<bool> RemoveFromWishlistQuery(int wishlistId);
        public Task<IEnumerable<WishlistResponseDTO>> GetUserWishlistQuery(int userId);
        public Task<bool> CheckBookInWishlistQuery(int userId, int bookId);
        public Task SendWishlistNotificationQuery(int bookId);
        public Task<IEnumerable<NotificationDTO>> GetUserNotificationsQuery(int userId);
        public Task MarkNotificationAsReadQuery(int notificationId);
        public Task<int> GetUnreadNotificationCountQuery(int userId);
        public Task ProcessReturnedBookNotificationsQuery(int bookId);
    }
}