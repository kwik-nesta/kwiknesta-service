using System.ComponentModel;

namespace KwikNestaIdentity.Domain.Enums
{
    public enum EOtpType
    {
        [Description("Account Verification")]
        AccountVerification,
        [Description("Password Reset")]
        PasswordReset,
        [Description("Account Reactivation")]
        AccountReactivation
    }
}
