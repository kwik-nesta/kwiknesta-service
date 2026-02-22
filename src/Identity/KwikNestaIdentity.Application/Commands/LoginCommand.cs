using KwikNesta.Mediator.Cores.Abstractions;
using KwikNesta.Shared.Responses;
using KwikNestaIdentity.Application.DTOs;

namespace KwikNestaIdentity.Application.Commands
{
    public class LoginCommand : IKNRequest<Response<LoginResponseDto>>
    {
        public string UserName { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}