
using LMS_Backend.LMS.Domain.Entities;

namespace LMS_Backend.LMS.Application.Interfaces.SystemConfiguration
{
    public interface ISystemConfigRepository
    {
        Task<string?> GetConfigValueByKeyQuery(string key);
        Task<decimal> GetPenaltyPerDayQuery();
        Task<int> GetMaxBorrowPeriodQuery();
        Task<int> GetMaxBorrowLimitQuery();
        Task<IEnumerable<SystemConfig>> GetAllConfigsQuery();
        Task UpdateSystemConfigQuery(SystemConfig config, int updatedBy);
    }
}