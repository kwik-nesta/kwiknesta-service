using System.ComponentModel;

namespace KwikNestaIdentity.Domain.Enums
{
    public enum ESystemRoles
    {
        None,
        [Description("SuperAdmin")]
        SuperAdmin,
        [Description("Admin")]
        Admin,
        [Description("LandLord")]
        LandLord,
        [Description("Tenant")]
        Tenant,
        [Description("Agent")]
        Agent
    }
}
