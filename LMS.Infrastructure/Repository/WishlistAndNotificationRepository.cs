using LMS_Backend.LMS.Application.DTOs.WishListAndNotification;
using LMS_Backend.LMS.Application.Interfaces;
using LMS_Backend.LMS.Application.Interfaces.WishListAndNotification;
using LMS_Backend.LMS.Common.Exceptions;
using LMS_Backend.LMS.Domain.Entities;
using LMS_Backend.LMS.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace LMS_Backend.LMS.Infrastructure.Repository
{
    public class WishlistAndNotificationRepository : GenericRepository<WishList>, IWishlistAndNotificationRepository
    {
        private readonly IEmailService _emailService;
        public WishlistAndNotificationRepository(ApplicationDBContext context, IEmailService emailService): base(context)
        {
            _emailService = emailService;
        }

        public async Task<bool> AddToWishlistQuery(int userId, int bookId)
        {
            var existingRecords = await _context.WishLists.FirstOrDefaultAsync(s => s.UserId == userId && s.BookId == bookId && !s.IsAvailable);

            if (existingRecords != null)
                throw new AlreadyExistsException<string>($"Book is already in Wishlist.");

            var wishlist = new WishList
            {
                UserId = userId,
                BookId = bookId,
                CreatedAt = DateTime.UtcNow
            };

            await _context.WishLists.AddAsync(wishlist);
            return await _context.SaveChangesAsync() > 0;
        }

        public Task<bool> CheckBookInWishlistQuery(int userId, int bookId)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetUnreadNotificationCountQuery(int userId)
        {
            return await _context.Notifications.CountAsync(n => n.UserId == userId && !n.IsRead);
        }

        public Task<IEnumerable<NotificationDTO>> GetUserNotificationsQuery(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<WishlistResponseDTO>> GetUserWishlistQuery(int userId)
        {
            var wishList = await _context.WishLists.Include(s => s.Book)
                                                   .Where(s => s.UserId == userId && !s.IsAvailable)
                                                   .Select(s => new WishlistResponseDTO
                                                   {    
                                                       WishListId = s.WishListId,
                                                       Title = s.Book.Title,
                                                       Author = s.Book.Author,
                                                   }).ToListAsync();

            return wishList;
        }

        public async Task MarkNotificationAsReadQuery(int notificationId)
        {
            var notification = await _context.Notifications.FindAsync(notificationId);
            if (notification != null)
            {
                notification.IsRead = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task ProcessReturnedBookNotificationsQuery(int bookId)
        {
            var wishlistEntries = await _context.WishLists
                            .Include(w => w.Book)
                            .Include(w => w.User)
                            .Where(w => w.BookId == bookId && !w.Notified)
                            .ToListAsync();

            var book = await _context.Books.FindAsync(bookId);
            if (book == null || book.AvailableCopies <= 0) return;

            foreach (var entry in wishlistEntries)
            {
                entry.Notified = true;
                entry.IsAvailable = true;
                _context.WishLists.Update(entry);

                // Create notification
                var notification = new Notification
                {
                    UserId = entry.UserId,
                    Message = $"The book '{entry.Book.Title}' you wished for is now available!",
                    Type = Domain.Enums.NotificationType.Email,
                    IsRead = false,
                    CreatedAt = DateTime.UtcNow
                };
                await _context.Notifications.AddAsync(notification);

                await _emailService.SendWishlistAvailableEmailAsync(
                    entry.User.Email,
                    $"{entry.User.FirstName} {entry.User.LastName}",
                    entry.Book.Title,
                    book.AvailableCopies
                );
            }

            await _context.SaveChangesAsync();
        }

        public async Task<bool> RemoveFromWishlistQuery(int wishlistId)
        {
            var wishlist = await _context.WishLists.FindAsync(wishlistId);
            if (wishlist == null) return false;

            wishlist.DeletedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }

        public Task SendWishlistNotificationQuery(int bookId)
        {
            throw new NotImplementedException();
        }
    }
}
