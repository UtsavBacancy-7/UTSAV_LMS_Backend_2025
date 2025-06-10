using System.Collections.Concurrent;

namespace LMS_Backend.LMS.Infrastructure.Helpers
{
    public static class OtpStore
    {
        public static ConcurrentDictionary<string, (int Otp, DateTime Expiry)> UserOtps = new();
    }
}