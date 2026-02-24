using System.Security.Claims;

namespace KwikNesta.Shared.Extensions
{
    public static class ClaimContextExtension
    {
        public static string? GetLoggedInUserId(this ClaimsPrincipal user)
        {
            return user?
                .FindFirst(ClaimTypes.NameIdentifier)?
                .Value;
        }

        public static string? GetLoggedInUserEmail(this ClaimsPrincipal user)
        {
            return user?
                .FindFirst(ClaimTypes.Name)?
                .Value;
        }
    }
}
