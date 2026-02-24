using KwikNesta.Mediator.Cores.Abstractions;
using KwikNesta.Shared.Responses;
using KwikNestaIdentity.Application.DTOs;

namespace KwikNestaIdentity.Application.Queries
{
    public class LoggedInUserQuery : IKNRequest<Response<CurrentUserDto>>
    {
        public string UserId { get; set; } = default!;
    }
}