using KwikNesta.Mediator.Cores.Abstractions;
using KwikNesta.Shared.Responses;
using KwikNestaIdentity.Domain.Enums;

namespace KwikNestaIdentity.Application.Commands
{
    public class ResendOtpCommand : IKNRequest<Response<string>>
    {
        public string Email { get; set; } = default!;
        public EOtpType Type { get; set; }
    }
}