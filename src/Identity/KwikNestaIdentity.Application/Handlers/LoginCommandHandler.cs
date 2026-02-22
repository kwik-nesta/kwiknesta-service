using KwikNesta.Mediator.Cores.Abstractions;
using KwikNesta.Shared.Implementations;
using KwikNesta.Shared.Responses;
using KwikNestaIdentity.Application.Commands;
using KwikNestaIdentity.Application.DTOs;

namespace KwikNestaIdentity.Application.Handlers
{
    public class LoginCommandHandler : IKNRequestHandler<LoginCommand, Response<LoginResponseDto>>
    {
        public LoginCommandHandler()
        {
            
        }

        public async Task<Response<LoginResponseDto>> HandleAsync(LoginCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            Notifications.SendEmail("ojotobar@gmail.com", "Hello KwikNesta", "<p>kwiknesta.com is live and direct!!! We are getting somewhere greater than ever</p>");
            return Response<LoginResponseDto>.Ok(new LoginResponseDto("", ""));
        }
    }
}