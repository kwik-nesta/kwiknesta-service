using System.ComponentModel;

namespace KwikNestaIdentity.Domain.Enums
{
    public enum EUserStatus
    {
        [Description("Pending Verification")]
        PendingVerification,
        [Description("Active")]
        Active,
        [Description("Deactivated")]
        Deactivated,
        [Description("Suspended")]
        Suspended
    }
}