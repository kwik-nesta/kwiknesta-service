using System.ComponentModel;

namespace KwikNesta.Shared.Models.Enumerations.Infra
{
    public enum EAuditAction
    {
        [Description("Logged In")]
        Login,
        [Description("Changed Password")]
        ChangedPassword,
        [Description("Deactivated Account")]
        DeactivatedAccount,
        [Description("Suspended Account")]
        SuspendedAccount
    }
}