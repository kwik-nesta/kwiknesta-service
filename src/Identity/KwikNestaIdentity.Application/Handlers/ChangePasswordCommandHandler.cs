using KwikNesta.Mediator.Cores.Abstractions;
using KwikNesta.Shared.Implementations;
using KwikNesta.Shared.Models.Enumerations.Infra;
using KwikNesta.Shared.Responses;
using KwikNesta.Shared.ServiceCommands.Identity;
using KwikNestaIdentity.Application.Validations;
using KwikNestaIdentity.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace KwikNestaIdentity.Application.Handlers
{
    public class ChangePasswordCommandHandler : IKNRequestHandler<ChangePasswordCommand, Response<string>>
    {
        private readonly UserManager<User> _userManager;

        public ChangePasswordCommandHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Response<string>> HandleAsync(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var validator = new ChangePasswordCommandValidator().Validate(request);
            if (!validator.IsValid)
            {
                return Response<string>.Fail(validator.Errors.FirstOrDefault()?.ErrorMessage ?? 
                    IdentityResponse.InvalidRequest, 400);
            }

            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user == null)
            {
                return Response<string>.Fail(IdentityResponse.AccessDenied, 403);
            }

            var result = await _userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);
            if (!result.Succeeded)
            {
                return Response<string>.Fail($"{result.Errors.FirstOrDefault()?.Description}", 401);
            }

            //// Notify the user
            //await _pubSub.PublishAsync(NotificationMessage.Initialize(user.Email!, user.FirstName,
            //    EmailType.PasswordResetNotification),
            //    routingKey: MQRoutingKey.AccountEmail.GetDescription());

            //// Log action
            AppAudit.Write(user.Id,
                        user.Email!,
                        EAuditAction.ChangedPassword,
                        EAuditDomain.UserAccount,
                        user.Id,
                        request.UserIpAddress);

            return Response<string>.Ok(IdentityResponse.PasswordChanged);
        }
    }
}