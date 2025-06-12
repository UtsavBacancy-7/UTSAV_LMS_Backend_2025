using LMS_Backend.LMS.Domain.Entities;

namespace LMS_Backend.LMS.Application.Interfaces.SystemConfiguration
{
    public interface ISystemConfigService
    {
        Task<string?> GetConfigValueByKeyAsync(string key);
        Task<decimal> GetPenaltyPerDayAsync();
        Task<int> GetMaxBorrowPeriodAsync();
        Task<int> GetMaxBorrowLimitAsync();
        Task<IEnumerable<SystemConfig>> GetAllConfigsAsync();
        Task UpdateSystemConfigAsync(SystemConfig config, int updatedBy);
    }
}
