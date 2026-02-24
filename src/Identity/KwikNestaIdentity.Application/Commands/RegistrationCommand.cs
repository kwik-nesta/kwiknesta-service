using KwikNesta.Mediator.Cores.Abstractions;
using KwikNesta.Shared.Responses;
using KwikNestaIdentity.Application.DTOs;
using KwikNestaIdentity.Domain.Enums;

namespace KwikNestaIdentity.Application.Commands
{
    public class RegistrationCommand : IKNRequest<Response<RegistrationDto>>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? MiddleName { get; set; }
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
        public EGender Gender { get; set; }
        public ESystemRoles Role { get; set; }
    }
}
