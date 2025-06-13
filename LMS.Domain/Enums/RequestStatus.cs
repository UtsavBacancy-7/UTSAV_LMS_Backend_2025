using System.ComponentModel;

namespace LMS_Backend.LMS.Domain.Enums
{
    public enum RequestStatus
    {
        [Description("Pending")]
        Pending,

        [Description("Approved")]
        Approved,

        [Description("Rejected")]
        Rejected,

        [Description("Returned")]
        Returned,

        [Description("Completed")]
        Completed
    }
}